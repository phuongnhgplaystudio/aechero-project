using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    private int health;
    [SerializeField] private int maxHealth;

    protected int Health { get => health; set => health = value; }
    protected int MaxHealth { get => maxHealth; set => maxHealth = value; }

    protected virtual void TakeDamage(int amount){
        if(Health - amount <= 0)
        {
            Health = 0;
            return;
        }
        Health -= amount;
    }

    protected void Death()
    { 
        DeathEffect();

    }

    protected virtual void DeathEffect()
    {

    }

    private void CreateHealhBar()
    {

    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if(player != null)
        {
            player.TakeDamage(10);
        }
    }
}
