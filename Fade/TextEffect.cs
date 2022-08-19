using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextEffect : MonoBehaviour
{
    //public Dialogue scripts;

    //Message message;
    //Color textColor;

    /*
    private void Start()
    {
        //message = scripts.messages[0];
        //textColor = gameObject.GetComponent<TextMesh>().mater;
    }*/

    private void OnTriggerExit2D(Collider2D collision)
    {
        //textColor.DOColor;
        //gameObject.GetComponent<MeshRenderer>().material.DOFade(1, 0.5f);
        //DOTween.To(gameObject.GetComponent<TextMesh>().color.a, (x)=> gameObject.GetComponent<TextMesh>().color.a = x, 0, 0.5);
        gameObject.GetComponent<MeshRenderer>().material.DOFade(0, 0.5f);
        //Debug.Log("충돌은 정상 처리");
    }
}
