using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUP : MonoBehaviour
{
    // �� ��ũ��Ʈ�� �Ⱦ� ������ ���� ��.
    public int Plus_Amount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player.Life = Plus_Amount;
            Destroy(gameObject);
        }
    }
}
