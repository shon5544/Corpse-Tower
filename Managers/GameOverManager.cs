using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    // public bool DebugMode;

    // void Update()
    // {
    //     if (DebugMode)
    //     {
    //         if (Input.GetKeyDown(KeyCode.Escape))
    //         {
    //             Application.Quit();
    //         }

    //         if (Input.GetKeyDown(KeyCode.R))
    //         {
    // Player.Life = 150 - Player.Life;

    // Player.CurrentItem = null;
    // Player.CurrentState = "";

    // Pistol.Ammo = 7;

    // Rifle.Ammo = 20;
    // Rifle.ExtraAmmo = -(Rifle.ExtraAmmo);

    // Shotgun.Ammo = 2;
    // Shotgun.ExtraAmmo = -(Shotgun.ExtraAmmo);

    // Sniper.Ammo = 5;
    // Sniper.ExtraAmmo = -(Sniper.ExtraAmmo);

    //             SceneManager.LoadScene("Tower1");
    //         }
    //     }

    // }
    [SerializeField]
    int currentMode = 0;

    // public Text Play;
    // public Text Exit;


    public GameObject zero;
    public GameObject one;

    private void Start()
    {
        // StartCoroutine(Select());
    }

    void Update()
    {
        Select();
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            if (currentMode == 0)
            {
                Player.Life = 150 - Player.Life;

                Player.CurrentItem = null;
                Player.CurrentState = "";

                Pistol.Ammo = 7;

                Rifle.Ammo = 20;
                Rifle.ExtraAmmo = -(Rifle.ExtraAmmo);

                Shotgun.Ammo = 2;
                Shotgun.ExtraAmmo = -(Shotgun.ExtraAmmo);

                Sniper.Ammo = 5;
                Sniper.ExtraAmmo = -(Sniper.ExtraAmmo);

                SceneManager.LoadScene("Lobby");
            }
            else
            {
                Application.Quit();
            }
        }
    }

    /*
    public IEnumerator Select()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                currentMode = 1;
                Play.color = Color.grey;
                Exit.color = Color.white;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                currentMode = 0;
                Play.color = Color.white;
                Exit.color = Color.grey;
            }

            yield return null;
        }
    }
    */

    public void Select()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            currentMode = 1;
            zero.SetActive(false);
            one.SetActive(true);
            // Play.color = Color.grey;
            // Exit.color = Color.white;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            currentMode = 0;
            zero.SetActive(true);
            one.SetActive(false);
            // Play.color = Color.white;
            // Exit.color = Color.grey;
        }
    }

    public void MoveScene1()
    {
        SceneManager.LoadScene("Start");
    }

    public void MoveScene2()
    {
        Application.Quit();
    }
}
