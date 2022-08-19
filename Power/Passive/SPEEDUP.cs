using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SPEEDUP", menuName = "Passive/SPEEDUP")]
public class SPEEDUP : Passive
{
    public override void Effect()
    {
        Player.Speed = (Player.Speed + 3f);
    }
}
