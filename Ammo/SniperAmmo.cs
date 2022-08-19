using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SniperAmmo : MonoBehaviour
{
    public int ammo;
    //public Player player;
    //public AudioSource reloadSound; ������Ʈ�� ������� �Ҹ��� �ȳ�.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Sniper.ExtraAmmo = ammo;
            //reloadSound.Play();
            if (collision.GetComponent<Player>().currentWeapon.name == "Sniper")
            {
                GameObject.Find("ExtraAmmo").GetComponent<Text>().text = Sniper.ExtraAmmo.ToString();
            }

            Destroy(gameObject);
        }
    }
}
