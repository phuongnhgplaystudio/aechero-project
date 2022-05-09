using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int damage;
    public float bulletSpeed;

    public ParticleSystem bulletImpactEffect;
    [SerializeField] private Transform pfDamagePopup; 
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

        SoundController.instance.PlayThisSoundOneShot("127560__romulofs__lighter", 1f);

        int calculateDamage = damage + Random.Range(-3, 3);
        DamagePopup.Create(other.transform.position + new Vector3(0, .8f, 0), calculateDamage, shootDir.normalized.x, false);

        damageable.TakeDamage(calculateDamage);
        Destroy(this.gameObject);
    }

    public void Setup(Vector3 shootDir)
    {
        this.shootDir = shootDir;
        //Debug.Log(shootDir + " | " + HutpeeCalculations.GetAngleFromVectorFloat(shootDir));
        transform.eulerAngles = new Vector3(0, 0, HutpeeCalculations.GetAngleFromVectorFloat(shootDir));
    }
}
