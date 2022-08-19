using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class ElevatorManager : MonoBehaviour
{
    Image FadeEffect;

    public GameObject GuideText;

    private void Start()
    {
        FadeEffect = GameObject.Find("FadeEffect").GetComponent<Image>();
    }

    /*static string[] sceneName = { 
        "Lobby",
        "Tower1",
        "Tower2",
        "Tower3",
        "Tower4",
        "Tower5",
    };*/

    public string RoomName;

    //static int roomNum;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(MoveScene());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GuideText.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GuideText.SetActive(false);
    }

    IEnumerator MoveScene()
    {
        FadeEffect.DOFade(1, 2f);

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(RoomName);

        //roomNum += 1;
    }
}
