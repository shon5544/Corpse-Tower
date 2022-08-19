using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeOut : MonoBehaviour
{
    Image image;
    public float second;

    private void Start()
    {
        image = GetComponent<Image>();
        image.DOFade(0, second);
    }
}
