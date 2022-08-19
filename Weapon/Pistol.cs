using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Pistol", menuName = "Weapon/Pistol")]
public class Pistol : Weapon
{
    public GameObject Bullet;
    public GameObject ExplosionBullet;
    public GameObject VampireBullet;

    Transform BulletSpawner;

    static int ammo = 7;
    public static int Ammo
    {
        get
        {
            return ammo;
        }

        set
        {
            ammo = value;
        }
    }

    public override void Shoot()
    {
        //player = GameObject.Find("Player").GetComponent<Transform>();
        //GameManager.Instance.StartCoroutine(SpawnBullet()); // 나는 개 병신입니다.
        /*
         내가 개 병신이 된 이유:
        여기서 보면 게임 매니저의 인스턴스 싱글톤을 이용해 모노비해비어의 스타트코루틴을 가져오는데,
        인스턴스 싱글톤을 보면 인스턴스가 null인 경우 하이어라키에 있는 게임 매니저를 찾아서 그것을 인스턴스로 한다.

        그러나 나는 하이어라키에 아직 게임 매니저 오브젝트를 비치해두지 않았고, 이를 찾으려던 스크립트가 계속 에러를 내던 것이었다

        이런 실수 없게 좀 생각을 해보자
         */


        //Debug.Log("여기까지는 괜찮다 이말이야,,ㅠ;;");

        //GameObject.Find("BulletSpawner").GetComponent<BulletSpawner>().BulletSpawn();
        BulletSpawner = GameObject.Find("BulletSpawner").GetComponent<Transform>();

        if(Player.CurrentState == "BOOM")
        {
            Instantiate(ExplosionBullet, BulletSpawner.position, Quaternion.identity);
        } else if(Player.CurrentState == "VAMP")
        {
            Instantiate(VampireBullet, BulletSpawner.position, Quaternion.identity);
        }
        else
        {
            Instantiate(Bullet, BulletSpawner.position, Quaternion.identity);
        }
        
        ammo -= 1;
        GameObject.Find("Ammo").GetComponent<Text>().text = ammo.ToString();

    }

    public override float ReturnCoolTime()
    {
        return 1.0f;
    }

    public override void Reload()
    {
        ammo = 7;
        GameObject.Find("Ammo").GetComponent<Text>().text = ammo.ToString();
    }

    public override int ReturnAmmo()
    {
        //int currentAmmo = ammo;
        return ammo;
    }

}
