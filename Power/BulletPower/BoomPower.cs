using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Boom", menuName = "ActivePower/Boom")]
public class BoomPower : Passive
{
    public override void Effect()
    {
        Player.CurrentState = "BOOM";
    }
}
