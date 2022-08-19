using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VAMP", menuName = "Passive/VAMP")]
public class VampirePower : Passive
{
    public override void Effect()
    {
        Player.CurrentState = "VAMP";
    }
}
