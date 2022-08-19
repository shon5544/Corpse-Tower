using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    [SerializeField]
    int currentMode = 0;

    public Text Play;
    public Text Exit;


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
                SceneManager.LoadScene("Start");
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
