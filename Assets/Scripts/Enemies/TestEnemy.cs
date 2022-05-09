using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestEnemy : MonoBehaviour, IDamageable
{
    public GameObject bulletPrefab;
    public float moveSpeed;
    private bool canAttack = true;

    public int maxHealth;
    public Image healthBarFill;
    private int health = 100;

    void Start()
    {
        xCenter = transform.position.x;
        health = maxHealth;
        StartCoroutine(Movement());
    }

    void Update()
    {
        canAttack = true;
        healthBarFill.fillAmount = (float)health / maxHealth;
    }

    //IDamagebale interface's method
    public void TakeDamage(int amount)
    {
        if (health <= amount)
        {
            health = 0;
            Destroy(this.gameObject);
        }
        else
        {
            health -= amount;
        }
    }
    float xCenter;
    private void FixedUpdate()
    {
        //TEST
        var hight = 3;
        transform.position = new Vector3(xCenter + Mathf.PingPong(Time.time * 2, hight) - hight / 2f, transform.position.y, transform.position.z);
    }

    private void ShootPlayer()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        Vector3 shootDir = (player.transform.position - transform.position).normalized;
        var bulletGO = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bulletGO.GetComponent<Bullet>().Setup(shootDir);
    }

    private IEnumerator Movement()
    {
        while(this.gameObject.activeInHierarchy){
            Vector2 randomPosition = new Vector2(Random.Range(-4, 4), Random.Range(0, -15));
            //yield return StartCoroutine(SmoothLerp(randomPosition));
            yield return new WaitForSeconds(0.3f);
            ShootPlayer();
            yield return new WaitForSeconds(1f);
        }
    }

    /*private IEnumerator SmoothLerp(Vector2 target)
    {
        Vector2 startingPos = transform.position;
        Vector2 finalPos = target;
        float elapsedTime = 0;
        var time = Vector2.Distance(startingPos, target) / moveSpeed;
        while (elapsedTime < time)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.MovePosition(rb.position + finalPos);
            //transform.position = Vector2.Lerp(startingPos, finalPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }*/
}
