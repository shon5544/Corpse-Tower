using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Shotgun", menuName = "Weapon/Shotgun")]
public class Shotgun : Weapon
{
    public GameObject Bullet_Shotgun;
    public GameObject Explosion_Shotgun;
    public GameObject Vampire_Shotgun;

    static int ammo = 2;
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
    
    public int maxAmmo = 2;

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
        //GameObject.Find("BulletSpawner").GetComponent<BulletSpawner>().BulletSpawn2();

        GameObject.Find("Shotgun_Fire").GetComponent<AudioSource>().Play();

        BulletSpawner = GameObject.Find("BulletSpawner").GetComponent<Transform>();

        if(Player.CurrentState == "BOOM")
        {
            Instantiate(Explosion_Shotgun, BulletSpawner.position, Quaternion.identity);
            Instantiate(Explosion_Shotgun, BulletSpawner.position, Quaternion.identity);
            Instantiate(Explosion_Shotgun, BulletSpawner.position, Quaternion.identity);
            Instantiate(Explosion_Shotgun, BulletSpawner.position, Quaternion.identity);
            Instantiate(Explosion_Shotgun, BulletSpawner.position, Quaternion.identity);
            Instantiate(Explosion_Shotgun, BulletSpawner.position, Quaternion.identity);
            Instantiate(Explosion_Shotgun, BulletSpawner.position, Quaternion.identity);
        }
        else if (Player.CurrentState == "VAMP")
        {
            Instantiate(Vampire_Shotgun, BulletSpawner.position, Quaternion.identity);
            Instantiate(Vampire_Shotgun, BulletSpawner.position, Quaternion.identity);
            Instantiate(Vampire_Shotgun, BulletSpawner.position, Quaternion.identity);
            Instantiate(Vampire_Shotgun, BulletSpawner.position, Quaternion.identity);
            Instantiate(Vampire_Shotgun, BulletSpawner.position, Quaternion.identity);
            Instantiate(Vampire_Shotgun, BulletSpawner.position, Quaternion.identity);
            Instantiate(Vampire_Shotgun, BulletSpawner.position, Quaternion.identity);
        }
        else
        {
            Instantiate(Bullet_Shotgun, BulletSpawner.position, Quaternion.identity);
            Instantiate(Bullet_Shotgun, BulletSpawner.position, Quaternion.identity);
            Instantiate(Bullet_Shotgun, BulletSpawner.position, Quaternion.identity);
            Instantiate(Bullet_Shotgun, BulletSpawner.position, Quaternion.identity);
            Instantiate(Bullet_Shotgun, BulletSpawner.position, Quaternion.identity);
            Instantiate(Bullet_Shotgun, BulletSpawner.position, Quaternion.identity);
            Instantiate(Bullet_Shotgun, BulletSpawner.position, Quaternion.identity);
        }
        

        ammo -= 1;
        GameObject.Find("Ammo").GetComponent<Text>().text = ammo.ToString();
        
    }

    public override float ReturnCoolTime()
    {
        return 2.5f;
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
