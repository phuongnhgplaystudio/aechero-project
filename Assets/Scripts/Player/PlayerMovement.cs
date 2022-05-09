using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ThirteenPixels.Soda;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GlobalVector2 input;

    public Transform topBound;
    public Transform leftBound;
    public Transform bottomBound;
    public Transform rightBound;
    public float moveSpeed;
    private Vector3 direction;

    private float trailCountdown = 0;

    private Animator _animator;
    private Rigidbody2D rigidbody;
    private SpriteRenderer _spriteRenderer;
    private float originLocalScaleX;
    private int currentFaceDirection = 1; //Storage current player's face direction, -1 is left, 1 is right
    private int lastFaceDirection = 1; //Storage last player's face direction, -1 is left, 1 is right

    public bool isMoving = false;

    public int CurrentFaceDirection { get => currentFaceDirection; set => currentFaceDirection = value; }

    private void Awake()
    {
        CacheComponents();
    }
    private void CacheComponents()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        originLocalScaleX = transform.localScale.x;
    }

    private void OnEnable()
    {
        input.onChange.AddResponse(ChangeDirection);
    }

    private void OnDisable()
    {
        input.onChange.RemoveResponse(ChangeDirection);
    }

    void Update()
    {
        //UpdatePlayerSpriteSortingLayer();
        CreateTrailEffect();
    }

    private void FixedUpdate()
    {
        ClampPlayerOnMap();

        RigidbodyMove();
    }

    private void ChangeDirection(Vector2 input)
    {
        //float temp = Mathf.Max(Mathf.Abs(input.x), Mathf.Abs(input.y));
        input.Normalize();
        //input *= temp;
        direction = new Vector3(input.x, input.y, 0);

        //Face transform local scale
        if(direction.x == 0)
        {
            if (lastFaceDirection == -1) FaceTo(-1);
            else FaceTo(1);
        }
        else if (direction.x < 0) FaceTo(-1);
        else FaceTo(1);
        
        //Set animator "RUN"
        if(direction != Vector3.zero)
        {
            _animator.SetBool("isRun", true);
            isMoving = true;
        }
        else
        {
            _animator.SetBool("isRun", false);
            isMoving = false;
        }
    }

    private void RigidbodyMove()
    {
        rigidbody.velocity = direction * moveSpeed;
    }

    private void TransformMove()
    {
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += Vector3.left;
            FaceTo(-1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDirection += Vector3.right;
            FaceTo(1);
        }
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += Vector3.up;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveDirection += Vector3.down;
        }
        moveDirection.Normalize();
        transform.Translate(moveDirection * moveSpeed * Time.fixedDeltaTime);
        if (Input.anyKey)
        {
            _animator.SetBool("isRun", true);
            isMoving = true;
        }
        else
        {
            _animator.SetBool("isRun", false);
            isMoving = false;
        }
    }

    private void UpdatePlayerSpriteSortingLayer()
    {
        var currentY = transform.position.y;
        _spriteRenderer.sortingOrder = 3 - (int)currentY;
    }

    private void ClampPlayerOnMap()
    {
        if(transform.position.x < leftBound.position.x)
        {
            var tempPosition = transform.position;
            tempPosition.x = leftBound.position.x;
            transform.position = tempPosition;
        }
        if (transform.position.x > rightBound.position.x)
        {
            var tempPosition = transform.position;
            tempPosition.x = rightBound.position.x;
            transform.position = tempPosition;
        }
        if (transform.position.y > topBound.position.y)
        {
            var tempPosition = transform.position;
            tempPosition.y = topBound.position.y;
            transform.position = tempPosition;
        }
        if (transform.position.y < bottomBound.position.y)
        {
            var tempPosition = transform.position;
            tempPosition.y = bottomBound.position.y;
            transform.position = tempPosition;
        }
    }

    public void FaceTo(int sign)
    {
        lastFaceDirection = (transform.localScale.x < 0) ? -1 : 1;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x = (float)sign * originLocalScaleX;
        transform.localScale = tempLocalScale;
        CurrentFaceDirection = sign;
    }

    private void CreateTrailEffect()
    {
        if (isMoving)
        {
            if(trailCountdown <= 0)
            {
                Instantiate(GameAssets.Instance.circlePrefab, transform.position, Quaternion.identity);
                trailCountdown = .2f;
            }
            trailCountdown -= Time.deltaTime;
        }
    }
}
