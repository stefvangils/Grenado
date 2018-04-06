using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public Text Player1Lives;
    public Text Player2Lives;

    public int PlayerOneLives;
    public int PlayerTwoLives;
    public int throws;
    int throwLeft;

    public GameObject player1;
    public GameObject player2;

    bool playerTurn = true;
    
    // Use this for initialization
    void Start () {
        throwLeft = throws;
    }
	
	// Update is called once per frame
	void Update () {
        Player1Lives.text = "Player 1 Lives: " + PlayerOneLives.ToString();
        Player2Lives.text = "Player 2 Lives: " + PlayerTwoLives.ToString();       
    }

    public void SubtractLives()
    {
        if(playerTurn == true)
        {
            PlayerOneLives = PlayerOneLives - 1;
            if (PlayerOneLives <= 0)
            {
                Debug.Log("player 2 wins");
            }
        }

        else
        {
            PlayerTwoLives = PlayerTwoLives - 1;
            if (PlayerTwoLives <= 0)
            {
                Debug.Log("player 1 wins");
            }
        }
        
    }

    public void Thrower()
    {
        throwLeft = throwLeft - 1;
        Debug.Log(throwLeft);
        if (throwLeft <= 0)
        {
            
            if (playerTurn == true)
            {
                player1.SetActive(false);
                player2.SetActive(true);
                throwLeft = throws;
                playerTurn = false;
            }
            else
            {
                player1.SetActive(true);
                player2.SetActive(false);
                throwLeft = throws;
                playerTurn = true;
            }
            
        }
    }

}
