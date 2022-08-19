using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TextFadeInOut : MonoBehaviour
{
    public float InSecond;
    public float OutSecond;

    private void Start()
    {
        StartCoroutine(FadeInOut());
    }

    IEnumerator FadeInOut()
    {
        yield return new WaitForSeconds(InSecond);
        gameObject.GetComponent<Text>().DOFade(1f, InSecond);
        yield return new WaitForSeconds(OutSecond);
        gameObject.GetComponent<Text>().DOFade(0f, OutSecond);
    }
}
