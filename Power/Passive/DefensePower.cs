using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DefensePower", menuName = "Passive/DefensePower")]
public class DefensePower : Passive
{
    public override void Effect()
    {
        Player.Defense = (Player.Defense + 5f);
    }
}
