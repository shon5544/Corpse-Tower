using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    void Shoot();

    float ReturnCoolTime();

    int ReturnAmmo();

    int ReturnExtraAmmo();


    void Reload();
}
