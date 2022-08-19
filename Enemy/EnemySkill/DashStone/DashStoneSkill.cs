using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashStoneSkill : MonoBehaviour, IEnemySkill
{
    public float Speed;

    Vector3 PlayerPos;
    Vector3 Dir;

    Rigidbody2D rigid;

    public virtual void WeakSkill()
    {
        PlayerPos = GameObject.Find("Player").GetComponent<Transform>().position;
        Dir = (PlayerPos - transform.position);

        rigid.AddForce(Dir.normalized * Time.deltaTime * Speed, ForceMode2D.Impulse);
    }

    public virtual void MiddleSkill() 
    {

    }

    public virtual void SpecialMove()
    {

    }



    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        StartCoroutine(Dash());
    }

    IEnumerator Dash()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            WeakSkill();
            
        }
    }
    
}
