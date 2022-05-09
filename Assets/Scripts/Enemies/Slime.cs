using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Monster
{
    public LayerMask obstacleLayerMask;
    [SerializeField] private float moveSpeed;

    private Vector2 moveDirection;
    private Vector2 toPlayerDirection;
    private Rigidbody2D rigidbody;

    BoxCollider2D boxCollider2D;

    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        toPlayerDirection = GlobalGameObjects.Instance.Player.transform.position - transform.position;
        toPlayerDirection.Normalize();

        moveDirection = ObstacleAvoidance() + toPlayerDirection;

        Debug.DrawRay(transform.position + new Vector3(-boxCollider2D.bounds.extents.x, 0, 0), new Vector3(moveDirection.x, moveDirection.y) * 3f, Color.green);
        Debug.DrawRay(transform.position + new Vector3(boxCollider2D.bounds.extents.x, 0, 0), new Vector3(moveDirection.x, moveDirection.y) * 3f, Color.green);
        Debug.DrawRay(transform.position + new Vector3(0, - boxCollider2D.bounds.extents.y, 0), new Vector3(moveDirection.x, moveDirection.y) * 3f, Color.green);
        Debug.DrawRay(transform.position + new Vector3(0, boxCollider2D.bounds.extents.y, 0), new Vector3(moveDirection.x, moveDirection.y) * 3f, Color.green);
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = moveDirection * moveSpeed * Time.fixedDeltaTime;
    }

    Vector2 ObstacleAvoidance()
    {
        float maxAvoid = 1f;
        Vector2 steering = Vector2.zero;
        RaycastHit2D hitLeft, hitRight, hitTop, hitBot;
        hitLeft = Physics2D.Raycast(transform.position + new Vector3(-boxCollider2D.bounds.extents.x, 0, 0),
            new Vector3(moveDirection.x, moveDirection.y), 3f, obstacleLayerMask);
        hitRight = Physics2D.Raycast(transform.position + new Vector3(boxCollider2D.bounds.extents.x, 0, 0),
            new Vector3(moveDirection.x, moveDirection.y), 3f, obstacleLayerMask);
        hitTop = Physics2D.Raycast(transform.position + new Vector3(0, boxCollider2D.bounds.extents.y, 0),
            new Vector3(moveDirection.x, moveDirection.y), 3f, obstacleLayerMask);
        hitBot = Physics2D.Raycast(transform.position + new Vector3(0, -boxCollider2D.bounds.extents.y, 0),
            new Vector3(moveDirection.x, moveDirection.y), 3f, obstacleLayerMask);
        if (hitLeft == true || hitRight == true || hitTop == true || hitBot == true)
        {
            Debug.Log("hit!");

            RaycastHit2D tempHit = hitLeft;

            if (hitLeft == true) tempHit = hitLeft;
            if (hitRight == true) tempHit = hitRight;
            if (hitTop == true) tempHit = hitTop;
            if (hitBot == true) tempHit = hitBot;
            Vector3 diff = transform.position - tempHit.collider.gameObject.transform.position;
            steering += new Vector2(diff.x, diff.y);
        }
        steering = steering.normalized * maxAvoid;
        return steering;
    }

    private IEnumerator MovementBehaviour()
    {
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }
}
