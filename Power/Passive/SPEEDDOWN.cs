using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SPEEDDOWN", menuName = "Passive/SPEEDDOWN")]
public class SPEEDDOWN : Passive
{
    public override void Effect()
    {
        Player.Speed = (Player.Speed - 3f);
    }
}
