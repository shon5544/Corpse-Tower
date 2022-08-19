using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropItem : MonoBehaviour
{
    public GameObject[] HpUp;
    public GameObject[] Ammo;

    //float hp;

    /*
    private void OnDestroy()
    {
        try
        {
            for (int i = 0; i < HpUp.Length; i++)
            {
                Instantiate(HpUp[Random.Range(0, HpUp.Length)], transform.position, Quaternion.identity);
            }

            for (int i = 0; i < Ammo.Length; i++)
            {
                Instantiate(Ammo[Random.Range(0, Ammo.Length)], transform.position, Quaternion.identity);
            }
        } 
        catch
        {
            
        }
        
    }*/

    public void DropItem()
    {
        for (int i = 0; i < HpUp.Length; i++)
        {
            Instantiate(HpUp[Random.Range(0, HpUp.Length)], transform.position, Quaternion.identity);
        }

        for (int i = 0; i < Ammo.Length; i++)
        {
            Instantiate(Ammo[Random.Range(0, Ammo.Length)], transform.position, Quaternion.identity);
        }
    }

    /*
    private void Update()
    {
        hp = GetComponent<EnemyHealthSystem>().HP;
    }*/


}
