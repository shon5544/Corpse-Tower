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
        //GameManager.Instance.StartCoroutine(SpawnBullet()); // ���� �� �����Դϴ�.
        /*
         ���� �� ������ �� ����:
        ���⼭ ���� ���� �Ŵ����� �ν��Ͻ� �̱����� �̿��� �����غ���� ��ŸƮ�ڷ�ƾ�� �������µ�,
        �ν��Ͻ� �̱����� ���� �ν��Ͻ��� null�� ��� ���̾��Ű�� �ִ� ���� �Ŵ����� ã�Ƽ� �װ��� �ν��Ͻ��� �Ѵ�.

        �׷��� ���� ���̾��Ű�� ���� ���� �Ŵ��� ������Ʈ�� ��ġ�ص��� �ʾҰ�, �̸� ã������ ��ũ��Ʈ�� ��� ������ ���� ���̾���

        �̷� �Ǽ� ���� �� ������ �غ���
         */


        //Debug.Log("��������� ������ �̸��̾�,,��;;");

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
