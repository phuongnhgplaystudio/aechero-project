using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSkill
{
    private int bulletDiagonal;
    private int bulletConsecutive;
    private int bulletFront;

    private bool bulletSpread;
    private bool bulletPierceThrough;
    private bool bulletBounceWall;

    public int BulletDiagonal { get => bulletDiagonal; set => bulletDiagonal = value; }
    public int BulletConsecutive { get => bulletConsecutive; set => bulletConsecutive = value; }
    public int BulletFront { get => bulletFront; set => bulletFront = value; }
    public bool BulletSpread { get => bulletSpread; set => bulletSpread = value; }
    public bool BulletPierceThrough { get => bulletPierceThrough; set => bulletPierceThrough = value; }
    public bool BulletBounceWall { get => bulletBounceWall; set => bulletBounceWall = value; }

    public void Setup()
    {
        BulletDiagonal = 0;
        BulletConsecutive = 1;
        BulletFront = 1;

        BulletSpread = false;
        BulletPierceThrough = false;
        BulletBounceWall = false;
    }

    public void AddBulletDiagonal()
    {
        BulletDiagonal += 2;
    }

    public void AddBulletConsecutive()
    {
        BulletConsecutive += 1;
    }

    public void AddBulletFront()
    {
        BulletFront += 1;
    }

    public void EnableBulletSpread()
    {
        BulletSpread = true;
    }

    public void EnableBulletPierceThrough()
    {
        BulletPierceThrough = true;
    }

    public void EnableBulletBounceWall()
    {
        BulletBounceWall = true;
    }
}
