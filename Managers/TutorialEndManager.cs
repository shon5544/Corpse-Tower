using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEndManager : MonoBehaviour
{
    public GameObject text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GameObject.Find("GameManager").GetComponent<GameManager>().IsFighting)
        {
            text.SetActive(true);

            /*
            Player.Attack = 1;
            Player.Defense = 0;
            Player.Speed = 12;

            Pistol.Ammo = 7;

            Shotgun.Ammo = 2;
            Rifle.Ammo = 20;
            Sniper.Ammo = 5;

            Shotgun.ExtraAmmo = -Shotgun.ExtraAmmo;
            Rifle.ExtraAmmo = -Rifle.ExtraAmmo;
            Sniper.ExtraAmmo = -Sniper.ExtraAmmo;
            */
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!GameObject.Find("GameManager").GetComponent<GameManager>().IsFighting)
        {
            text.SetActive(false);
        }
    }
}
