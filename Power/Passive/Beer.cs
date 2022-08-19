using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Beer", menuName = "Passive/Beer")]
public class Beer : Passive
{
    public override void Effect()
    {
        Player.Life = 50;
    }
}
