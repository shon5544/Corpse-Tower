using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RandomUPDOWN", menuName = "Passive/RandomUPDOWN")]
public class RandomUPDOWN : Passive
{
    delegate void Mydelegate();
    

    public override void Effect()
    {
        Mydelegate attackRelated = new Mydelegate(Attack);
        Mydelegate defenseRelated = new Mydelegate(Defense);
        Mydelegate speedRelated = new Mydelegate(Speed);

        Mydelegate[] list =
        {
            attackRelated,
            defenseRelated,
            speedRelated
        };

        list[Random.Range(0, 3)]();
    }

    void Attack()
    {
        float value = Random.Range(-1f, 1f);

        if (Player.Attack + value <= 0)
        {
            Player.Attack = 0.1f;
        }
        else
        {
            Player.Attack = (Player.Attack + value);
        }
    }

    void Defense()
    {
        float value = Random.Range(-1f, 1f);

        if(Player.Defense + value <= 0)
        {
            Player.Defense = 0;
        } else
        {
            Player.Defense = (Player.Defense + value);
        }
    }

    void Speed()
    {
        float value = Random.Range(-3f, 3f);

        if (Player.Speed + value <= 0)
        {
            Player.Speed = 3f;
        } else
        {
            Player.Speed = (Player.Speed + value);
        }
    }
}
