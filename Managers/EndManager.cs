using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class EndManager : MonoBehaviour
{
    private void Update()
    {
        if (!GameObject.Find("GameManager").GetComponent<GameManager>().IsFighting)
        {
            StartCoroutine(MoveScene());
        }
    }

    IEnumerator MoveScene()
    {
        GameObject.Find("Player").GetComponent<Player>().CanMove = false;
        GameObject.Find("FadeEffect").GetComponent<Image>().DOFade(1, 1f);

        yield return new WaitForSeconds(0.6f);

        GameObject.Find("Second").GetComponent<Text>().DOFade(1, 0.5f);

        GameManager.CurrentRoomCount = 0;
        Player.Life = (150 - Player.Life);

        Player.Attack = 1;
        Player.Defense = 0;
        Player.Speed = 12;

        Player.CurrentState = "";
        Player.CurrentItem = null;

        Pistol.Ammo = 7;

        Shotgun.Ammo = 2;
        Rifle.Ammo = 20;
        Sniper.Ammo = 5;

        Shotgun.ExtraAmmo = -Shotgun.ExtraAmmo;
        Rifle.ExtraAmmo = -Rifle.ExtraAmmo;
        Sniper.ExtraAmmo = -Sniper.ExtraAmmo;

        yield return new WaitForSeconds(5f);
        // GameObject.Find("FadeEffect").GetComponent<Image>().DOFade(1, 1f);
        Destroy(GameObject.Find("bgm"));
        SceneManager.LoadScene("Lobby");
    }
}
