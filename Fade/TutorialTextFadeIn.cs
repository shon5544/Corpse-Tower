using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TutorialTextFadeIn : MonoBehaviour
{
    public float second;
    public GameObject gameManager;

    void Start()
    {
        StartCoroutine(TextUp());
    }

    IEnumerator TextUp()
    {
        while (true)
        {
            if (!gameManager.GetComponent<GameManager>().IsFighting)
            {
                gameObject.GetComponent<Text>().DOFade(1, 1.5f);
                yield return new WaitForSeconds(4f);
                gameObject.GetComponent<Text>().DOFade(0, 1.5f);
                yield return new WaitForSeconds(1f);

                break;
            }

            yield return null;
        }
    }
}
