using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Rifle", menuName = "Weapon/Rifle")]
public class Rifle : Weapon
{
    public GameObject Bullet_Rifle;
    public GameObject Explosion_Rifle;
    public GameObject Vampire_Rifle;
    static int ammo = 20;
    public static int Ammo
    {
        get
        {
            return ammo;
        }

        set
        {
            ammo = value;
        }
    }

    public int maxAmmo = 20;

    static int extraAmmo = 0;

    int value;

    public static int ExtraAmmo
    {
        get
        {
            return extraAmmo;
        }

        set
        {
            extraAmmo += value;
        }
    }

    Transform BulletSpawner;

    public override void Shoot()
    {
        //GameObject.Find("BulletSpawner").GetComponent<BulletSpawner>().BulletSpawn3();
        BulletSpawner = GameObject.Find("BulletSpawner").GetComponent<Transform>();

        if(Player.CurrentState == "BOOM")
        {
            Instantiate(Explosion_Rifle, BulletSpawner.position, Quaternion.identity);
        }
        else if (Player.CurrentState == "VAMP")
        {
            Instantiate(Vampire_Rifle, BulletSpawner.position, Quaternion.identity);
        }
        else
        {
            Instantiate(Bullet_Rifle, BulletSpawner.position, Quaternion.identity);
        }
        
        ammo -= 1;
        GameObject.Find("Ammo").GetComponent<Text>().text = ammo.ToString();
    }

    public override float ReturnCoolTime()
    {
        return 0.15f;
    }

    public override int ReturnAmmo()
    {
        return ammo;
    }

    public override int ReturnExtraAmmo()
    {
        return extraAmmo;
    }

    public override void Reload()
    {
        if (extraAmmo > 0)
        {
            if (extraAmmo - maxAmmo >= 0)
            {
                extraAmmo -= (maxAmmo - ammo);
                ammo = maxAmmo;

                GameObject.Find("ExtraAmmo").GetComponent<Text>().text = extraAmmo.ToString();
                GameObject.Find("Ammo").GetComponent<Text>().text = ammo.ToString();
            }
            else
            {
                value = ammo + maxAmmo + (extraAmmo - maxAmmo);
                if (value <= maxAmmo)
                {
                    ammo = value;
                    extraAmmo = 0;
                }
                else
                {
                    extraAmmo -= (maxAmmo - ammo);
                    ammo = maxAmmo; // ammo = 4, max = 5, extra = 3
                }


                GameObject.Find("ExtraAmmo").GetComponent<Text>().text = extraAmmo.ToString();
                GameObject.Find("Ammo").GetComponent<Text>().text = ammo.ToString();
            }
        }
    }
}
