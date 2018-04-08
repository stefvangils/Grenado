using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public Text Player1Lives;
    public Text Player2Lives;
    public Text Turn;
    public Text Grenades;
    public Text Crates;
    public Text BuildmodeActive;
    public Text Win;

    public int PlayerOneLives;
    public int PlayerTwoLives;
    public int throws;
    public int throwLeft;

    public GameObject player1;
    public GameObject player2;

    
    public bool playerTurn = true;
    public float buildmode;

    public GameObject backgroundMusic;


    bool gameFinished = false;
    // Use this for initialization
    void Start () {
        throwLeft = throws;
        Instantiate(backgroundMusic);
    }
	
	// Update is called once per frame
	void Update () {
        UpdateUI();          
    }

    public void SubtractLives(crate crateObj)
    {
        int player = crateObj.GetComponent<crate>().player;
        if (player == 1)
        {
            PlayerOneLives = PlayerOneLives - 1;
            if (PlayerOneLives <= 0 && gameFinished == false)
            {
                Win.gameObject.SetActive(true);
                Win.text = "player 2 wins";
                gameFinished = true;
            }
        }

        else
        {
            PlayerTwoLives = PlayerTwoLives - 1;
            if (PlayerTwoLives <= 0 && gameFinished == false)
            {
                Win.gameObject.SetActive(true);
                Win.text = "player 1 wins";
                gameFinished = true;
            }
        }
        
    }

    public void Thrower()
    {
        throwLeft = throwLeft - 1;        
        if (throwLeft <= 0)
        {
            StartCoroutine(Pause());
            
            
        }
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(2);
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

    void UpdateUI()
    {
        if (playerTurn == true)
        {
            Turn.text = "Turn: Player 1";
        }
        else
        {
            Turn.text = "Turn: Player 2";
        }
        Player1Lives.text = "Player 1 Lives: " + PlayerOneLives;
        Player2Lives.text = "Player 2 Lives: " + PlayerTwoLives;
        Grenades.text = "Grenades: " + throwLeft;
        Crates.text = "Crates: " + Mathf.Ceil(buildmode / 2);
        if (buildmode > 0)
        {
            BuildmodeActive.text = "Mode: Buildmode";
        }
        else
        {
            BuildmodeActive.text = "Mode: FightMode";
        }
    }
}
