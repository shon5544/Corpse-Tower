using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform PlayerTr;
    public float Speed = 7;

    float angle;
    Vector2 Dir;

    Rigidbody2D rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();


        if (gameObject.layer == 6)
        {
            StartCoroutine(TurnAndMove());
        }
        else
        {
            StartCoroutine(JustMove());
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerTr = GameObject.Find("Player").GetComponent<Transform>();

        //Turn();
        Dir = (PlayerTr.position - transform.position);

    }


    IEnumerator TurnAndMove()
    {
        while (true)
        {
            angle = Mathf.Atan2(Dir.y, Dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //transform.Translate(Vector3.right * Time.deltaTime * Speed);
            rigid.MovePosition(rigid.position + Dir.normalized * Time.deltaTime * Speed);

            yield return null;
        }
    }


    IEnumerator JustMove()
    {
        //MoveDir = (transform.position - PlayerTr.position);
        while (true)
        {
            //transform.Translate(Dir.normalized * Time.deltaTime * Speed);
            rigid.MovePosition(rigid.position + Dir.normalized * Time.deltaTime * Speed);
            yield return null;
        }
    }
}
