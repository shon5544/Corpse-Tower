using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BeingGiant", menuName = "ActiveItem/BeingGiant")]
public class BeingGiant : ActiveItem
{
    public Transform PlayerTr;
    public override void Execute()
    {
        GameManager.Instance.StartCoroutine(BeingBig());
    }

    IEnumerator BeingBig()
    {

        /*while (PlayerTr.localScale.x <= 2.5f)
        {
            PlayerTr.localScale = new Vector3(PlayerTr.localScale.x + 0.1f, PlayerTr.localScale.y + 0.1f, PlayerTr.localScale.z + 0.1f);
            yield return null;
        }*/


        PlayerTr.localScale += new Vector3(2.5f, 2.5f, 2.5f);

        yield return new WaitForSeconds(10f);

        PlayerTr.localScale -= new Vector3(1, 1, 1);

        /*while (PlayerTr.transform.localScale.x > 1.0f)
        {
            PlayerTr.localScale = new Vector3(PlayerTr.localScale.x - 0.1f, PlayerTr.localScale.y - 0.1f, PlayerTr.localScale.z - 0.1f);
            yield return null;
        }*/
    }
}
