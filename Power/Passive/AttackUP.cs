using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackUP", menuName = "Passive/AttackUP")]
public class AttackUP : Passive
{
    public override void Effect()
    {
        Player.Attack = (Player.Attack + 0.5f);
    }
}
