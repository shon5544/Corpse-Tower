using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    static int killAmount;

    public int AmountToKill;

    public bool IsFighting = false;

    // 아이템 코드에서 E키를 누르면 현재 씬의 게임매니저 TimeToGo 변수를 true로 만들게 해놨다
    public bool TimeToGo = false;

    public GameObject[] Items;
    public Transform[] itemPos;

    // 가게될 방들
    public string[] RoomNames;


    // 갔었던 방에는 다시 안들어가게 하기 위해서 갔었던 방을 변수에 담아 정리한다.
    [SerializeField]
    static List<string> WentToRooms = new List<string>();


    // 뽑기해서 당첨된 방의 이름.
    string gachaRoom;

    // 스테이지 당 방 갯수. 만약 현재 돌아다닌 방 수가 스테이지 방 갯수와 같아진다면 보스전으로 보낸다.
    public int RoomCount;

    // 보스방 이름
    public string bossRoomName;

    // 현재 돌아다닌 방의 갯수
    static int currentRoomCount = 0;
    public static int CurrentRoomCount
    {
        get
        {
            return currentRoomCount;
        }
        set
        {
            currentRoomCount = value;
        }
    }

    GameObject obj_KillAmountUI;
    GameObject obj_KillUI;
    Text KillAmountUI;

    int itemIndex1;
    int itemIndex2;
    int count;

    bool exitOuterLoop = false;
    bool isExited = false;

    public static int KillAmount
    {
        get
        {
            return killAmount;
        }

        set
        {
            killAmount += value;
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<GameManager>();

            return instance;
        }
    }

    private void Start()
    {

        obj_KillAmountUI = GameObject.Find("KillAmount");
        obj_KillUI = GameObject.Find("KILL!");
        KillAmountUI = obj_KillAmountUI.GetComponent<Text>();
        killAmount = AmountToKill;

        foreach (string i in WentToRooms)
        {
            Debug.Log($"현재 {currentRoomCount}째 , 갔던 방 : {i}");
        }

        StartCoroutine(Gacha());
    }

    private void Update()
    {
        if (Player.Life <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        if (TimeToGo)
        {
            StartCoroutine(MoveRoom());
        }
    }

    IEnumerator MoveRoom()
    {
        GameObject.Find("FadeEffect").GetComponent<Image>().DOFade(1, 0.5f);
        GameObject.Find("Player").GetComponent<Player>().CanMove = false;
        //Debug.Log($"{gameObject.scene.name} / {WentToRooms.Length}");
        //WentToRooms.SetValue($"{gameObject.scene.name}", WentToRooms.Length);
        // WentToRooms[currentRoomCount] = gameObject.scene.name;
        WentToRooms.Add(gameObject.scene.name);

        // yield return null;

        StartCoroutine(CheckWentTo());

        yield return new WaitForSeconds(0.5f);
        // yield return new WaitUntil(() => isExited);

        currentRoomCount += 1;

        if (currentRoomCount == RoomCount)
        {
            Destroy(GameObject.Find("bgm"));
            SceneManager.LoadScene(bossRoomName);
        }
        else
        {
            try
            {
                DontDestroyOnLoad(GameObject.Find("bgm"));
            }
            catch
            {

            }
            SceneManager.LoadScene(gachaRoom);
        }


    }

    IEnumerator CheckWentTo()
    {
        while (true)
        {
            gachaRoom = RoomNames[Random.Range(0, RoomNames.Length)];
            count = 0;


            foreach (string i in WentToRooms)
            {
                count += 1;
                exitOuterLoop = false;

                // if (i == gachaRoom)
                // {
                //     Debug.Log("겹침");
                //     //continue;
                // } else if(count == WentToRooms.Count) {
                //     break;
                // }

                if (count != WentToRooms.Count)
                {
                    if (i == gachaRoom) // 마지막 요소 전에 겹치는 게 있을 경우
                    {
                        Debug.Log("겹침");
                        // continue;

                        // 바깥루프는 탈출하면 안됨. 다시 루프를 검사해야하므로.
                        break;
                    }
                }
                else // 마지막까지 왔을 때까지 겹침을 발견하지 못했을 때
                {
                    if (i == gachaRoom) // 마지막 요소가 뽑힌 것과 같을 때
                    {
                        Debug.Log("겹침");
                        // continue;

                        // 바깥루프는 탈출하면 안됨. 다시 루프를 검사해야하므로.
                        break;
                    }
                    else // 마지막 요소까지 겹치는게 없을 때
                    {
                        // 바깥 루프까지 탈출해야하는 상황이므로
                        exitOuterLoop = true;
                        break;
                    }
                }

                // yield return null;
            }

            // 만약 모든 루프를 다돌아도 겹침을 발견하지 못했다면
            if (exitOuterLoop)
            {
                isExited = true;
                break;
            }


            yield return null;
        }

    }


    IEnumerator Gacha()
    {
        while (true)
        {
            if (IsFighting)
            {
                KillAmountUI.text = KillAmount.ToString();
            }
            else
            {
                obj_KillUI.SetActive(false);
                obj_KillAmountUI.SetActive(false);
                itemIndex1 = Random.Range(0, Items.Length);
                itemIndex2 = Random.Range(0, Items.Length);

                if (Player.CurrentState == Items[itemIndex1].name || Player.CurrentState == Items[itemIndex2].name)
                {
                    continue;
                }

                if (itemIndex2 != itemIndex1)
                {
                    Instantiate(Items[itemIndex1], itemPos[0].position, Quaternion.identity);
                    Instantiate(Items[itemIndex2], itemPos[1].position, Quaternion.identity);
                    break;
                }
            }

            if (killAmount == 0)
            {
                IsFighting = false;
            }


            yield return null;
        }
    }

}
