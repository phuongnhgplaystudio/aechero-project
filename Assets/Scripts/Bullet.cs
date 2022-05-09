using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //
    //
    public float bulletSpeed;

    public ParticleSystem bulletImpactEffect;

    private Vector3 shootDir;
    private void FixedUpdate()
    {
        transform.position += shootDir * bulletSpeed * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Instantiate(bulletImpactEffect, this.transform.position, Quaternion.identity);
        var damageable = other.gameObject.GetComponent<IDamageable>();
        if (damageable == null) return;
        damageable.TakeDamage(10);
        Destroy(this.gameObject);
    }

    public void Setup(Vector3 shootDir)
    {
        this.shootDir = shootDir;
        //Debug.Log(shootDir + " | " + HutpeeCalculations.GetAngleFromVectorFloat(shootDir));
        transform.eulerAngles = new Vector3(0, 0, HutpeeCalculations.GetAngleFromVectorFloat(shootDir));
    }
}


