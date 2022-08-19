using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PickUpItemLifeCycle : MonoBehaviour
{
    //SpriteRenderer render;
    //Color to_color;

    private void Start()
    {
        StartCoroutine(Die());
        //render = gameObject.GetComponent<SpriteRenderer>();
        //to_color = new Color(render.color.r, render.color.g, render.color.b, 0);
    }

    IEnumerator Die()
    {
        //render.DOFade(0f, 3f);
        gameObject.GetComponent<SpriteRenderer>().DOFade(0, 7f);
        yield return new WaitForSeconds(7f);
        Destroy(gameObject);
    }
}
