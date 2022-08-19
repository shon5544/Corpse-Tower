using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Sniper", menuName = "Weapon/Sniper")]
public class Sniper : Weapon
{
    public GameObject Bullet_Sniper;
    public GameObject Explosion_Sniper;
    public GameObject Vampire_Sniper;
    static int ammo = 5;
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

    public int maxAmmo = 5;

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
        BulletSpawner = GameObject.Find("BulletSpawner").GetComponent<Transform>();

        if(Player.CurrentState == "BOOM")
        {
            Instantiate(Explosion_Sniper, BulletSpawner.position, Quaternion.identity);
        }
        else if (Player.CurrentState == "VAMP")
        {
            Instantiate(Vampire_Sniper, BulletSpawner.position, Quaternion.identity);
        }
        else
        {
            Instantiate(Bullet_Sniper, BulletSpawner.position, Quaternion.identity);
        }

        
        ammo -= 1;
        GameObject.Find("Ammo").GetComponent<Text>().text = ammo.ToString();
    }

    public override float ReturnCoolTime()
    {
        return 3f;
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
                if(value <= maxAmmo)
                {
                    ammo = value;
                    extraAmmo = 0;
                } else
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
