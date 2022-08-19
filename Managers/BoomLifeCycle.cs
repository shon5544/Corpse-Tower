using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomLifeCycle : MonoBehaviour
{
    Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
        GameObject.Find("BoomSound").GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        // 현재 Explosion 애니메이션이 진행 중이고 && 애니메이션 진행도가 100%이상일때, 게임 오브젝트 삭제
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Explosion") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            Destroy(gameObject);
        }
    }
}
