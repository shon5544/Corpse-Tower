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
        //hiddenCircle = GameObject.Find("Player").GetComponentInChildren<GameObject>(true); // GameObject ������Ʈ�� MonoBehavior��  �������� �ʱ� ������ ������.

        //hiddenCircle.SetActive(true);
        Instantiate(HolyCicle, GameObject.Find("Player").GetComponent<Transform>().position + new Vector3(0,0,-5), Quaternion.identity);
    }
}
