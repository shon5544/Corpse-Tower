using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Boss4 : MonoBehaviour
{
    Vector3 playerPos;

    Vector2 Dir;
    Rigidbody2D rigid;

    public float MoveSpeed;
    public float MoveTime;

    float currentSecond;

    [SerializeField]
    public bool dashState;

    public GameObject BoomEffect;
    // public GameObject BossName;
    public GameObject Panel;


    Animator anim;
    SpriteRenderer rend;



    // MyDelegate[] Patterns;
    // List<MyDelegate> Patterns;

    // var Patterns;

    delegate IEnumerator Patterns();

    Patterns pattern1;
    Patterns pattern2;
    Patterns pattern3;

    // List<Patterns> patternList = new List<Patterns>();
    List<Patterns> patternList = new List<Patterns>()
    {
    };


    bool isFirst = true;

    /*
    왼쪽 삼각형 포지션 = -227.45, 98.333, 0
    보스 이미지 포지션 = -153, 10, 0
    오른쪽 이미지 포지션 = 131, -74, 0
    */

    int RandomIndex;

    float currentTime;

    public CameraShake camShake;
    // public GameObject Maf;

    public GameObject RightPos;
    public GameObject LeftPos;
    public GameObject BossImgPos;

    float ratioX;
    float ratioY;


    void Start()
    {
        //playerTr = GameObject.Find("Player").GetComponent<Transform>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();

        // patternList.Add(pattern(Pattern1));
        pattern1 = Pattern1;
        pattern2 = Pattern2;
        pattern3 = Pattern3;

        patternList.Add(pattern1);
        patternList.Add(pattern2);
        patternList.Add(pattern3);

        ratioX = (float)Screen.height / 800;
        ratioY = (float)Screen.width / 600;

        // patternList[0] = pattern1;

        // 패턴 랜덤 뽑기에 사용할 대리자 객체

        // patterns = new Patterns[]{
        //     Pattern1,
        //     Pattern2,
        //     Pattern3
        // };


        StartCoroutine(FightStart());
    }

    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && isFirst)
        {
            StartCoroutine(FightStart());
            isFirst = false;
        }
    }*/

    IEnumerator ChooseFunc()
    {
        // yield return null;
        Debug.Log("일단 나옴");
        StartCoroutine(patternList[Random.Range(0, 3)]());
        // Debug.Log("패턴 뽑기 지나치고 옴");

        // patternList[0]();
        yield return null;
    }

    IEnumerator FightStart()
    {
        yield return new WaitForSeconds(2f);
        anim.SetBool("Dash", true);
        GameObject.Find("Growl").GetComponent<AudioSource>().Play();
        GameObject.Find("Player").GetComponent<Player>().CanMove = false;

        yield return new WaitForSeconds(3f);
        // GameObject.Find("Growl").GetComponent<AudioSource>().Stop();
        GameObject.Find("FadeEffect").GetComponent<Image>().DOFade(1, 0.1f);

        Panel.SetActive(true);
        GameObject.Find("bgm").GetComponent<AudioSource>().Play();
        // GameObject.Find("Right").GetComponent<RectTransform>().DOMove(new Vector3(131, -74, 0), 0.5f);
        // GameObject.Find("Left").GetComponent<RectTransform>().DOMove(new Vector3(-227.45f, 98.333f, 0), 0.5f);
        // GameObject.Find("BossImg").GetComponent<RectTransform>().DOMove(new Vector3(-153, 10, 0), 0.5f);


        GameObject.Find("Right").GetComponent<RectTransform>().DOMoveX(ratioX * 950, 1f);
        GameObject.Find("Left").GetComponent<RectTransform>().DOMoveX(ratioX * 280, 1f);
        GameObject.Find("BossImg").GetComponent<RectTransform>().DOMove(new Vector3(ratioX * (400), ratioY * (163), 0), 1f);


        // RectTransform RightPos = GameObject.Find("Right").GetComponent<RectTransform>();
        // RectTransform LeftPos = GameObject.Find("Left").GetComponent<RectTransform>();
        // RectTransform BossImg = GameObject.Find("BossImg").GetComponent<RectTransform>();

        // DOTween.To(()=> GameObject.Find("Right").GetComponent<RectTransform>().position.x, (x)=> GameObject.Find("Right").GetComponent<RectTransform>().position.x = (float)x, 131, 1f);
        // DOTween.To(()=> GameObject.Find("Left").GetComponent<RectTransform>().x, (x)=> GameObject.Find("Left").GetComponent<RectTransform>().x = x, -227.45f, 1f);
        // DOTween.To(()=> GameObject.Find("BossImg").GetComponent<RectTransform>().x)



        yield return new WaitForSeconds(3f);
        Panel.SetActive(false);
        GameObject.Find("FadeEffect").GetComponent<Image>().DOFade(0, 0.5f);
        anim.SetBool("Dash", false);

        GameObject.Find("Player").GetComponent<Player>().CanMove = true;

        yield return null;

        StartCoroutine(ChooseFunc());

        yield return null;
    }

    void Update()
    {
        playerPos = GameObject.Find("Player").GetComponent<Transform>().position;

        Dir = playerPos - transform.position;
        if (Dir.x > 0)
        {
            rend.flipX = true;
        }
        else
        {
            rend.flipX = false;
        }
    }

    // 그냥 플레이어 쫄쫄 쫒아다니기
    IEnumerator Pattern1()
    {
        Debug.Log("1번 패턴 호출됨");
        while (true)
        {
            anim.SetBool("Dash", false);
            anim.SetBool("Go", false);
            currentSecond += Time.deltaTime;
            rigid.MovePosition(rigid.position + Dir.normalized * Time.deltaTime * MoveSpeed);
            // transform.position += ((Vector3)Dir.normalized * Time.deltaTime * MoveSpeed);
            if (currentSecond >= MoveTime)
            {
                break;
            }

            yield return null;
        }

        yield return null;

        StartCoroutine(ChooseFunc());

        yield return null;
    }

    // 플레이어한테 존내 돌진
    IEnumerator Pattern2()
    {
        Debug.Log("2번 패턴 호출됨");
        dashState = true;
        anim.SetBool("Dash", true); // 아직은 부들부들 상태

        yield return new WaitForSeconds(3f);

        Vector2 dir = GameObject.Find("Player").GetComponent<Transform>().position - transform.position;
        anim.SetBool("Go", true); // 부들부들 끝 > 대쉬
        yield return null;
        while (dashState)
        {
            currentTime += Time.deltaTime;
            rigid.MovePosition(rigid.position + dir.normalized * Time.deltaTime * MoveSpeed * 10);
            // transform.position += (Vector3)dir.normalized * Time.deltaTime * MoveSpeed * 10;

            if (currentTime >= 3f)
            {
                anim.SetBool("Dash", false);
                anim.SetBool("Go", false);
                dashState = false;
                break;
            }

            yield return null;
        }

        yield return null;

        anim.SetBool("Dash", false);
        anim.SetBool("Go", false);

        StartCoroutine(ChooseFunc());

        yield return null;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            GameObject.Find("WallBangSound").GetComponent<AudioSource>().Play();
            StartCoroutine(camShake.Shake(1f, 0.5f));
            dashState = false;
        }
    }

    // 폭발
    IEnumerator Pattern3()
    {
        Debug.Log("3번 패턴 호출됨");
        anim.SetBool("Dash", true);
        yield return new WaitForSeconds(3f);
        anim.SetBool("Dash", false);

        Instantiate(BoomEffect, transform.position, Quaternion.identity);
        StartCoroutine(camShake.Shake(1f, 0.5f));

        yield return null;
        StartCoroutine(ChooseFunc());

        yield return null;
    }


}
