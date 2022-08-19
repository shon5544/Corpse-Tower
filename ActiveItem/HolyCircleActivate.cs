using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HolyCircle", menuName = "ActiveItem/HolyCircle")]
public class HolyCircleActivate : ActiveItem
{
    public GameObject HolyCicle;
    public override void Execute()
    {
        //GameObject hiddenCircle;
        //hiddenCircle = GameObject.Find("Player").GetComponentInChildren<GameObject>(true); // GameObject 컴포넌트가 MonoBehavior에  속해있지 않기 때문에 오류남.

        //hiddenCircle.SetActive(true);
        Instantiate(HolyCicle, GameObject.Find("Player").GetComponent<Transform>().position + new Vector3(0,0,-5), Quaternion.identity);
    }
}
