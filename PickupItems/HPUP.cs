using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPUP : MonoBehaviour
{
    // 이 스크립트는 픽업 잡템을 위한 것.
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
