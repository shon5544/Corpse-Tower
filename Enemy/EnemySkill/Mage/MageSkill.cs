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

    // 얘는 잡몹이니까 WeakSkill만 구현해야지
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
            // 왜 안되는지 모르겠는데 전부터 색깔 변경하는 스크립트는 작동을 안했다. 이거 좀 알아보자
            //render.DOColor(toColor, 3f);

            gameObject.GetComponent<SpriteRenderer>().DOColor(toColor, 3f);
            WeakSkill();
            yield return new WaitForSeconds(3f);
        }
    }
        
    
}
