using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : ScriptableObject, IWeapon
{
    public virtual void Shoot()
    {

    }

    public virtual float ReturnCoolTime()
    {
        return 0.0f;
    }

    public virtual void Reload()
    {

    }

    public virtual int ReturnAmmo()
    {
        return 0;
    }

    public virtual int ReturnExtraAmmo()
    {
        return 0;
    }
}
