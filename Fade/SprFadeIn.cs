using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SprFadeIn : MonoBehaviour
{
    SpriteRenderer image;
    public float second;

    private void Start()
    {
        image = GetComponent<SpriteRenderer>();
        image.DOFade(1, second);
    }
}
