using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayPickUpSound : MonoBehaviour
{
    AudioSource PickupAmmo;

    private void Start()
    {
        PickupAmmo = GameObject.Find("PickUpAmmo").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PickupAmmo.Play();
        }
    }
}
