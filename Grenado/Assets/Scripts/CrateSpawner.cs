using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSpawner : MonoBehaviour {

    public GameObject cratePrefab;

    public GameController gameController;

    bool canSpawnCrate = true;
    GameObject player;
    int playerturn;

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            if(gameController.buildmode > 0 && canSpawnCrate == true)
            {
                spawnCrate();
                gameController.buildmode = gameController.buildmode - 1;
                StartCoroutine(Pause());
                
            }
            
        }
    }

    IEnumerator Pause()
    {
        canSpawnCrate = false;
        yield return new WaitForSeconds(2);
        if (gameController.playerTurn == true)
        {
            gameController.player1.SetActive(false);
            gameController.player2.SetActive(true);
            gameController.playerTurn = false;
            canSpawnCrate = true;
        }
        else
        {
            gameController.player1.SetActive(true);
            gameController.player2.SetActive(false);
            gameController.playerTurn = true;
            canSpawnCrate = true;
        }
    }

    void spawnCrate()
    {
        GameObject crate = Instantiate(cratePrefab, transform.position + transform.forward * 5 + transform.up * 5, transform.rotation);        
        if (gameController.playerTurn == true)
        {
            crate.GetComponent<crate>().player = 1;
            
        }
        else
        {
            crate.GetComponent<crate>().player = 2;
        }
        
    }
}
