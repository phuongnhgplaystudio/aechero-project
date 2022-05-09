using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject selectedCirclePrefab;
    public Transform firePoint;
    public float attackSpeed;

    private GameObject target = null;
    private float attackCountdown;

    private Animator _animator;
    private PlayerMovement playerMovement;
    private void Awake()
    {
        CacheComponents();
    }

    void Start()
    {
        attackCountdown = 1f / attackSpeed;
    }

    private void CacheComponents()
    {
        _animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if(attackCountdown <= 0)
        {
            Shoot();
        }
        attackCountdown -= Time.deltaTime;
    }

    private void Shoot()
    {
        if (!playerMovement.isMoving)
        {
            FindNearestEnemy();
            if (target != null)
            {
                if (target.transform.position.x < transform.position.x)
                {
                    playerMovement.FaceTo(-1);
                }
                else
                {
                    playerMovement.FaceTo(1);
                }

                HighlightSelectedEnemy(target);

                _animator.SetTrigger("attack");
                SoundController.instance.PlayThisSoundOneShot("shoot_1", 1f);
                Vector3 shootDir = (target.transform.position - firePoint.transform.position).normalized;
                var bulletGO = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
                bulletGO.GetComponent<PlayerBullet>().Setup(shootDir);
                
                /* //Bullet Rigid
                //Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //Vector2 dir = mousePos - (Vector2)transform.position;
                Vector2 dir = target.transform.position - transform.position;
                bulletGO.GetComponent<Rigidbody2D>().AddForce(dir.normalized * 25f, ForceMode2D.Impulse);*/
                
                attackCountdown = 1f / attackSpeed;
            }
        }
    }

    private void FindNearestEnemy()
    {
        var enemiesInScene = GameObject.FindGameObjectsWithTag("Enemies");
        if(enemiesInScene != null)
        {
            float minDistance = 999999;
            foreach(var enemy in enemiesInScene)
            {
                //Debug.Log(enemy.name + Vector2.Distance(transform.position, enemy.transform.position));
                if(Vector2.Distance(transform.position, enemy.transform.position) < minDistance)
                {
                    minDistance = Vector2.Distance(transform.position, enemy.transform.position);
                    target = enemy;
                }
            }
        }
        else
        {
            target = null;
        }
    }

    private void HighlightSelectedEnemy(GameObject enemy)
    {
        var allSelectedCircles = GameObject.FindGameObjectsWithTag("Selected Circle");
        foreach(var cir in allSelectedCircles)
        {
            Destroy(cir.gameObject);
        }
        var circle = Instantiate(selectedCirclePrefab, enemy.transform.Find("shadow_circle_100").position, Quaternion.identity, enemy.transform.Find("shadow_circle_100").transform);
    
    }
}
