using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RifleAmmo : MonoBehaviour
{
    public int ammo;
    //public Player player;
    //public AudioSource reloadSound; 오브젝트가 사라져서 소리가 안남.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Rifle.ExtraAmmo = ammo;
            //reloadSound.Play();
            if (collision.GetComponent<Player>().currentWeapon.name == "Rifle")
            {
                GameObject.Find("ExtraAmmo").GetComponent<Text>().text = Rifle.ExtraAmmo.ToString();
            }

            Destroy(gameObject);
        }
    }
}
