using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class Player : MonoBehaviour
{
    // 대쉬 딜레이
    public float Delay = 0.6f;
    public float coolTime;
    public float dashSpeed = 2000;


    public AudioSource reloadSound; // 권총 장전 소리
    public AudioSource reloadSound2; // 샷건 장전 소리
    public AudioSource reloadSound3; // 라이플 장전 소리
    public AudioSource reloadSound4; // 스나이퍼 장전 소리
    public AudioSource emptyClick; // 틱틱 거리는 소리

    // 퍽퍽 터지는 소리
    public AudioSource HitSound;

    // 피 터지는 효과
    public ParticleSystem BloodEffect;

    // 총알 발사 파티클
    public ParticleSystem Fire_Effect;

    // 아야하는 소리
    public AudioSource[] Ouch;


    // 현재 무기 이 빈 객체에 아래 네가지 Weapon객체를 넣음으로써 현재 무기 상태를 표시한다.
    public Weapon currentWeapon;
    public Weapon pistol;
    public Weapon rifle;
    public Weapon shotgun;
    public Weapon sniper;

    // 무기 관련 UI
    public GameObject PistolUI;
    public GameObject ShotgunUI;
    public GameObject RifleUI;
    public GameObject SniperUI;
    private GameObject currentUI;



    // 탄약 관련 텍스트
    public Text AmmoText;
    public Text ExtraAmmoText;

    // 액티브 아이템
    [SerializeField]
    private static ActiveItem currentItem;
    public static ActiveItem CurrentItem
    {
        get
        {
            return currentItem;
        }
        set
        {
            currentItem = value;
        }
    }

    //public GameObject Fire_Effect;
    public GameObject Light;

    public ParticleSystem dashEffect;


    // references 확인하는게 더 빠를 듯
    float currentTime;
    float reloadTime;

    Vector2 Dir; // 회전에 쓰일 벡터
    Vector3 mousePos; // 마우스 벡터
    Rigidbody2D rigid; // 이동에 쓰이는 rigidbody
    Animator anim; // 애니메이션

    float x;
    float y;

    public bool CanMove = true;


    public Text ATKValue;
    public Text DEFValue;
    public Text DEXValue;

    [SerializeField]
    float InvisibleTime = 0;
    public float InvisibleCool = 2f;

    float emptyClickTime = 0f;
    float emptyClickCool = 0.7f;


    [SerializeField]
    private static float defense = 0;
    public static float Defense
    {
        get
        {
            return defense;
        }

        set
        {
            defense = value;
        }
    }

    [SerializeField]
    private static float attack = 1;
    public static float Attack
    {
        get
        {
            return attack;
        }

        set
        {
            attack = value;
        }
    }

    private static float speed = 12.0f;
    public static float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    float damage = 0;


    [SerializeField]
    float angle; // 회전에 쓰일 각도

    private static float life = 150; // HP

    // 여기저기서 쓰일 Life 싱글톤
    public static float Life
    {
        get
        {
            return life;
        }

        set
        {

            if (life != 150)
            {
                if (life + value > 150)
                {
                    life = 150;
                    //HealthUI.text = life.ToString();
                }
                else
                {
                    life += value;
                    //life = Mathf.Round(life);
                    //HealthUI.text = life.ToString();
                }
            }

        }
    }

    /*
    string[] states =
    {
        "BOOM",
        "ELEC",
        "VAMP"
    };
    */
    private static string currentState;
    public static string CurrentState
    {
        get
        {
            return currentState;
        }

        set
        {
            currentState = value;
        }
    }

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentUI = PistolUI;

        coolTime = currentWeapon.ReturnCoolTime();
        currentTime = coolTime;

        //Debug.Log($"{coolTime}");

        ATKValue.text = $"{Player.Attack}";
        DEFValue.text = $"{Player.Defense}";
        DEXValue.text = $"{Player.Speed}";

        StartCoroutine(Dash());
        StartCoroutine(Turn());
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        reloadTime += Time.deltaTime;
        InvisibleTime += Time.deltaTime;
        emptyClickTime += Time.deltaTime;

        // transform을 통한 이동은 collider에 비볐을 때 버벅이는 등 물리 효과에 적절치 않다.
        //transform.position += new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed, Input.GetAxisRaw("Vertical") * Time.deltaTime * speed, 0);

        if (CanMove)
        {
            x = Input.GetAxisRaw("Horizontal");
            y = Input.GetAxisRaw("Vertical");
        }

        Shoot();
        Reload();
        WeaponChange();
        ExecuteItem();
    }


    private void FixedUpdate()
    {
        Dir = new Vector2(x, y);
        //rigid.position + Dir * Time.deltaTime * speed
        //rigid.velocity = new Vector2(Dir.x * Time.deltaTime * speed, Dir.y * Time.deltaTime * speed);

        rigid.MovePosition(rigid.position + Dir * Time.deltaTime * speed);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ActiveItem")
        {
            currentItem = collision.GetComponent<HavingItem>().Item;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            PlayerDamaged(collision.gameObject);

        }

        /*
        if(collision.tag == "Enemy")
        {
            HitSound.Play();
            BloodEffect.Play();
            Ouch[Random.Range(0, 2)].Play();
            life -= collision.GetComponent<Damage>().damage;
        }*/

        //Debug.Log($"{collision.gameObject.name}");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            PlayerDamaged(collision.gameObject);
        }
    }


    void Shoot()
    {
        /*
        
        
        if (currentTime >= coolTime)
        {
            if (!anim.GetBool("IsReloading"))
            {
                if (Input.GetMouseButton(0))
                {
                    
                    if (currentWeapon.ReturnAmmo() > 0)
                    {
                        StartCoroutine(FireEffect());
                        currentWeapon.Shoot();
                    }
                    //emptyClick.Play();
                    StartCoroutine(FireEffect());
                    currentWeapon.Shoot();
                    currentTime = 0;

                }
            }
        }
        */


        if (!anim.GetBool("IsReloading"))
        {
            if (Input.GetMouseButton(0))
            {
                if (currentWeapon.ReturnAmmo() > 0)
                {
                    if (currentTime >= coolTime)
                    {
                        StartCoroutine(FireEffect());
                        currentWeapon.Shoot();
                        currentTime = 0;
                    }
                }
                else
                {
                    if (emptyClickTime >= emptyClickCool)
                    {
                        emptyClick.Play();
                        emptyClickTime = 0;
                    }

                }
            }
        }

    }

    void PlayerDamaged(GameObject Obj)
    {
        if (InvisibleTime >= InvisibleCool)
        {
            HitSound.Play();
            BloodEffect.Play();
            Ouch[Random.Range(0, 2)].Play();
            StartCoroutine(PlayerGetWhite());

            damage = Obj.GetComponent<Damage>().damage - defense;
            if (damage > 1)
            {
                life -= damage;
            }
            else
            {
                damage = 1;
                life -= damage;
            }

            InvisibleTime = 0f;
        }
    }

    IEnumerator PlayerGetWhite()
    {
        // GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.5f);
        // yield return new WaitForSeconds(InvisibleCool);
        // GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
        int cnt = 0;
        while (cnt < 8)
        {
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0.2f);
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
            yield return new WaitForSeconds(0.1f);

            cnt += 1;

            yield return null;
        }

    }


    IEnumerator FireEffect()
    {
        /*
        Fire_Effect.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Fire_Effect.SetActive(false);
        */
        Fire_Effect.Play();
        Light.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        Light.SetActive(false);
    }


    void Reload()
    {
        if (reloadTime >= 0.6f)
        {
            anim.SetBool("IsReloading", false);
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (anim.GetInteger("GunMode") == 0)
                {
                    reloadSound.Play();
                    AmmoText.text = Pistol.Ammo.ToString();
                }
                else if (anim.GetInteger("GunMode") == 1)
                {
                    reloadSound2.Play();
                    AmmoText.text = Shotgun.Ammo.ToString();
                    ExtraAmmoText.text = Shotgun.ExtraAmmo.ToString();
                }
                else if (anim.GetInteger("GunMode") == 2)
                {
                    reloadSound3.Play();
                    AmmoText.text = Rifle.Ammo.ToString();
                    ExtraAmmoText.text = Rifle.ExtraAmmo.ToString();
                }
                else if (anim.GetInteger("GunMode") == 3)
                {
                    reloadSound4.Play();
                    AmmoText.text = Sniper.Ammo.ToString();
                    ExtraAmmoText.text = Sniper.ExtraAmmo.ToString();
                }

                currentWeapon.Reload();
                anim.SetBool("IsReloading", true);
                reloadTime = 0;
            }
        }
    }



    /*
    IEnumerator CallReloadFun()
    {
        yield return new WaitForSeconds(1.2f);
        currentWeapon.Reload();
    }*/


    void WeaponChange()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (currentWeapon != pistol)
            {
                currentWeapon = pistol;
                currentUI.SetActive(false);
                currentUI = PistolUI;
                currentUI.SetActive(true);

                AmmoText.text = Pistol.Ammo.ToString();
                ExtraAmmoText.text = "--";

                coolTime = currentWeapon.ReturnCoolTime();
                currentTime = coolTime;
                anim.SetInteger("GunMode", 0);
                reloadSound.Play();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (currentWeapon != shotgun)
            {
                currentWeapon = shotgun;
                currentUI.SetActive(false);
                currentUI = ShotgunUI;
                currentUI.SetActive(true);

                AmmoText.text = Shotgun.Ammo.ToString();
                ExtraAmmoText.text = Shotgun.ExtraAmmo.ToString();

                coolTime = currentWeapon.ReturnCoolTime();
                currentTime = coolTime;
                anim.SetInteger("GunMode", 1);
                reloadSound2.Play();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (currentWeapon != rifle)
            {
                currentWeapon = rifle;
                currentUI.SetActive(false);
                currentUI = RifleUI;
                currentUI.SetActive(true);

                AmmoText.text = Rifle.Ammo.ToString();
                ExtraAmmoText.text = Rifle.ExtraAmmo.ToString();

                coolTime = currentWeapon.ReturnCoolTime();
                currentTime = coolTime;
                anim.SetInteger("GunMode", 2);
                reloadSound3.Play();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (currentWeapon != sniper)
            {
                currentWeapon = sniper;
                currentUI.SetActive(false);
                currentUI = SniperUI;
                currentUI.SetActive(true);

                AmmoText.text = Sniper.Ammo.ToString();
                ExtraAmmoText.text = Sniper.ExtraAmmo.ToString();

                coolTime = currentWeapon.ReturnCoolTime();
                currentTime = coolTime;
                anim.SetInteger("GunMode", 3);
                reloadSound4.Play();
            }
        }
    }

    // 현재 currentItem에 들어가있는 ActiveItem 객체안의 Execute를 실행시킴
    void ExecuteItem()
    {
        if (currentItem != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentItem.Execute();
                currentItem = null;
            }
        }
    }



    IEnumerator Turn()
    {
        while (true)
        {
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            yield return null;
        }
    }

    IEnumerator Dash()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                //Dir = mousePos - transform.position;

                //transform.DOMove((transform.position + Vector3.right) * 100, 0.2f);
                speed *= dashSpeed;
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
                speed = 12f;
                //rigid.AddForce(Dir.normalized * Time.deltaTime * dashSpeed, ForceMode2D.Impulse);
                //transform.Translate(Vector3.right * Time.deltaTime * dashSpeed);

                yield return new WaitForSeconds(Delay);
            }

            yield return null;
        }
    }
}