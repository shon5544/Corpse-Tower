using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotgunAmmo : MonoBehaviour
{
    public int ammo;
    //public Player player;
    //public AudioSource reloadSound; 오브젝트가 사라져서 소리가 안남.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Shotgun.ExtraAmmo = ammo;
            //reloadSound.Play();
            if(collision.GetComponent<Player>().currentWeapon.name == "Shotgun")
            {
                GameObject.Find("ExtraAmmo").GetComponent<Text>().text = Shotgun.ExtraAmmo.ToString();
            }
            
            Destroy(gameObject);
        }
    }
}
