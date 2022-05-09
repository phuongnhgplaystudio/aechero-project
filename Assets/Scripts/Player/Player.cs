using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IDamageable
{
    public int maxHealth;
    private int health = 100;

    public RectTransform healthBarRect;
    public Image healthBarFill;
    public float healthBarLerpSpeed;
    private float healthBarOriginalScaleX;
    private float fillAmount;

    private PlayerMovement playerMovement;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();

        healthBarOriginalScaleX = Mathf.Abs(healthBarRect.localScale.x);

    }

    void Start()
    {
        health = maxHealth;
        fillAmount = health / maxHealth;
    }

    void Update()
    {
        HandleHealthBar();
    }

    //IDamagebale interface's method
    public void TakeDamage(int amount)
    {
        if(health <= amount)
        {
            health = 0;

        }
        else
        {
            health -= amount;
        }
    }

    private void HandleHealthBar()
    {
        Debug.Log(playerMovement.CurrentFaceDirection);
        
        Vector3 tempScale = healthBarRect.localScale;
        tempScale.x = playerMovement.CurrentFaceDirection * healthBarOriginalScaleX;
        healthBarRect.localScale = tempScale;

        //healthBarFill.fillAmount = (float) health / maxHealth;
        healthBarFill.fillAmount = Mathf.Lerp((float)health / maxHealth, healthBarFill.fillAmount, healthBarLerpSpeed * Time.deltaTime);
    }
}
