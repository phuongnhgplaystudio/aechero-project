using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private Weapon currentWeapon;
    private WeaponSkill weaponSkill;

    private void Awake()
    {
        
    }

    void Start()
    {
        weaponSkill.Setup();
    }

    void Update()
    {
        
    }

    public void DoAttack()
    {

    }

    /*private IEnumerator AttackCoroutine()
    {
        for(int i = 1; )
    }*/
}
