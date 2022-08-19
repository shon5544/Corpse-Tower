using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageBulletMove : MonoBehaviour
{
    public float Speed;

    Vector3 PlayerPos;
    Vector3 MageBulletPos;
    Vector3 Dir;

    float angle;


    public bool BornInTrap;
    public int xDirection;
    public int yDirection;

    public GameObject MageBulletBoom;


    void Start()
    {
        StartCoroutine(IsBornInTrap());
        Destroy(gameObject, 7);
    }

    IEnumerator IsBornInTrap()
    {
        yield return null;
        if (BornInTrap)
        {
            Dir = new Vector3(xDirection, yDirection, -5);
            angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
        {
            PlayerPos = GameObject.Find("Player").GetComponent<Transform>().position;
            MageBulletPos = transform.position;

            Dir = (PlayerPos - MageBulletPos);
            angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    /*
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }*/


    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * Speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall" || other.tag == "Player")
        {
            Instantiate(MageBulletBoom, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Instantiate(MageBulletBoom, transform.position, Quaternion.identity);
        Destroy(gameObject, 0.1f);
    }
}
