using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MageSkill : MonoBehaviour, IEnemySkill
{
    public Transform StaffTr;
    public GameObject MageBullet;
    public GameObject MageParticle;

    //SpriteRenderer render;

    Color toColor = new Color(152, 34, 219);

    // ��� ����̴ϱ� WeakSkill�� �����ؾ���
    public virtual void WeakSkill()
    {
        Instantiate(MageParticle, StaffTr.position, Quaternion.identity);
        Instantiate(MageBullet, StaffTr.position, Quaternion.identity);
    }

    public virtual void MiddleSkill()
    {

    }

    public virtual void SpecialMove()
    {

    }


    void Start()
    {
        //render = GetComponent<SpriteRenderer>();
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot() {
        while (true)
        {
            // �� �ȵǴ��� �𸣰ڴµ� ������ ���� �����ϴ� ��ũ��Ʈ�� �۵��� ���ߴ�. �̰� �� �˾ƺ���
            //render.DOColor(toColor, 3f);

            gameObject.GetComponent<SpriteRenderer>().DOColor(toColor, 3f);
            WeakSkill();
            yield return new WaitForSeconds(3f);
        }
    }
        
    
}
