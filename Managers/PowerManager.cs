using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerManager : MonoBehaviour
{
    public GameObject text;

    public Passive power;
    public ActiveItem holyShit;

    Text ATKValue;
    Text DEFValue;
    Text DEXValue;

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        ATKValue = GameObject.Find("ATKValue").GetComponent<Text>();
        DEFValue = GameObject.Find("DEFValue").GetComponent<Text>();
        DEXValue = GameObject.Find("DEXValue").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            text.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
            text.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(power != null)
                {
                    power.Effect();
                } else
                {
                    //GameObject.Find("Player").GetComponent<Player>().currentItem = holyShit;
                    Player.CurrentItem = holyShit;
                }
                

                ATKValue.text = $"{Player.Attack}";
                DEFValue.text = $"{Player.Defense}";
                DEXValue.text = $"{Player.Speed}";

                gameManager.TimeToGo = true;

                Destroy(gameObject);
            }
        }
        
    }
}
