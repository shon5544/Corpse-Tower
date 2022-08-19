using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextFadeOut : MonoBehaviour
{
    Text text;
    public float second;

    private void Start()
    {
        text = GetComponent<Text>();
        text.DOFade(0, second);
    }
}
