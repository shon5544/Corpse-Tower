using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamTrap : MonoBehaviour
{
    public GameObject MageBullet;
    public GameObject PurpleMagicEffect;

    public int xDirection;
    public int yDirection;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Instantiate(PurpleMagicEffect, transform.position, Quaternion.identity);
            var bullet = Instantiate(MageBullet, transform.position, Quaternion.identity);
            bullet.GetComponent<MageBulletMove>().xDirection = xDirection;
            bullet.GetComponent<MageBulletMove>().yDirection = yDirection;
            bullet.GetComponent<MageBulletMove>().BornInTrap = true;
        }
    }
}
