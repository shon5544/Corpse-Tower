using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class DialogueDetecting : MonoBehaviour
{
    public SpriteRenderer render;
    public SpriteRenderer render2;

    public GameObject MafDialogue;
    public GameObject MyResponse;
    public GameObject SecondResponse;

    public RectTransform MafPos;
    public RectTransform ResponsePos;

    public Text MafText;
    public Text MyText;
    public Text MyText2;
    public Image MafPortrait;

    public Dialogue OurFirstTalk;

    bool isDone = false;
    bool talking = false;

    public bool isBossRoom = false;

    float waitSecond;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            render.DOFade(1, 0.6f);
            render2.DOFade(1, 1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        render.DOFade(0, 0.6f);
        render2.DOFade(0, 0.2f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!talking)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                render.DOFade(0, 0.6f);
                render2.DOFade(0, 0.2f);

                StartCoroutine(Talk());
            }
        }

    }

    IEnumerator Talk()
    {
        int index = 0;
        talking = true;

        Message currentTalk;
        //MafDialogue.transform.DOMoveY(258f - 80f, 1f);
        MafDialogue.transform.DOMove(MafPos.position, 1f);

        yield return new WaitForSeconds(1f);

        if (!isDone)
        {
            while (true)
            {
                currentTalk = OurFirstTalk.messages[index];

                if (currentTalk.responses[0].next == -1)
                {
                    MafText.DOText(currentTalk.text, 2f);
                    yield return new WaitForSeconds(2f);

                    MyText.text = currentTalk.responses[0].reply;
                    //MyResponse.transform.DOMoveY(239f - 184.86f, 1f);
                    MyResponse.transform.DOMove(ResponsePos.position, 1f);

                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));

                    MyResponse.transform.DOMoveY(142.86f - 281f, 1f);

                    MafDialogue.transform.DOMoveY(38f - 339f, 1f);

                    MyText.text = "";
                    MafText.text = "";

                    isDone = true;
                    talking = false;

                    break;
                }
                else
                {
                    if (currentTalk.responses[0].trigger == "Fast")
                    {
                        waitSecond = 2f;
                        MafText.DOText(currentTalk.text, waitSecond);
                        yield return new WaitForSeconds(waitSecond);
                    }
                    else if (currentTalk.responses[0].trigger == "Middle")
                    {
                        waitSecond = 3.5f;
                        MafText.DOText(currentTalk.text, waitSecond);
                        yield return new WaitForSeconds(waitSecond);
                    }
                    else
                    {
                        waitSecond = 5f;
                        MafText.DOText(currentTalk.text, waitSecond);
                        yield return new WaitForSeconds(waitSecond);
                    }

                    MyText.text = currentTalk.responses[0].reply;
                    MyResponse.transform.DOMove(ResponsePos.position, 1f);

                    index += currentTalk.responses[0].next;

                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
                    MafText.text = "";

                    MyResponse.transform.DOMoveY(142.86f - 281f, 1f);
                    MyText.text = "";
                }

                yield return null;
            }

            if (isBossRoom)
            {
                GameObject.Find("FadeEffect").GetComponent<Image>().DOFade(1, 1.5f);
                yield return new WaitForSeconds(1.5f);
                GameObject.Find("EndingText").GetComponent<Text>().DOFade(1, 0.5f);
                yield return new WaitForSeconds(10f);

                GameManager.CurrentRoomCount = 0;
                Player.Life = (150 - Player.Life);

                Player.Attack = 1;
                Player.Defense = 0;
                Player.Speed = 12;

                Player.CurrentState = "";

                Pistol.Ammo = 7;

                Shotgun.Ammo = 2;
                Rifle.Ammo = 20;
                Sniper.Ammo = 5;

                Shotgun.ExtraAmmo = -Shotgun.ExtraAmmo;
                Rifle.ExtraAmmo = -Rifle.ExtraAmmo;
                Sniper.ExtraAmmo = -Sniper.ExtraAmmo;

                SceneManager.LoadScene("Lobby");
            }
        }
        else
        {
            currentTalk = OurFirstTalk.messages[OurFirstTalk.messages.Length - 1];
            int next;
            while (true)
            {
                MafText.DOText(currentTalk.text, 3.5f);
                yield return new WaitForSeconds(3.5f);

                /*
                MyText.text = currentTalk.responses[0].reply;
                MyText2.text = currentTalk.responses[1].reply;

                MyResponse.transform.DOMoveY(281f - 184.86f, 1f);
                SecondResponse.transform.DOMoveY(328f - 184.86f, 1f);

                while (true)
                {
                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        next = currentTalk.responses[1].next;
                    }

                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        next = currentTalk.responses[0].next;
                    }

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        break;
                    }

                    yield return null;
                }
                */

                MyText.text = currentTalk.responses[0].reply;
                MyResponse.transform.DOMoveY(239f - 184.86f, 1f);


                //SecondResponse.transform.DOMoveY(184.86f - 328f, 1f);
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
                next = currentTalk.responses[0].next;

                MafDialogue.transform.DOMoveY(38f - 339f, 1f);
                MyResponse.transform.DOMoveY(142.86f - 281f, 1f);

                MyText.text = "";
                //MyText2.text = "";
                MafText.text = "";


                if (next == -1)
                {
                    break;
                }

                yield return null;
            }
        }

    }
}
