using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeThrower : MonoBehaviour {

    public Image Loadbar;
    public float throwForce;
    public GameObject grenadePrefab;

    public GameController gameController;
    float timer;
    float force;
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update () {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if(gameController.buildmode <= 0 && gameController.throwLeft > 0)
        //    {
        //        ThrowGrenade();
        //    }
           
        //}  
        if(Input.GetKey(KeyCode.G) && gameController.buildmode <= 0 && gameController.throwLeft > 0)
        {
            timer += Time.deltaTime;
            Loadbar.fillAmount = timer / 4;
            
        }
        if(Input.GetKeyUp(KeyCode.G) && gameController.buildmode <= 0 && gameController.throwLeft > 0)
        {
            force = (throwForce / 2) * timer;
            timer = 0;
            Loadbar.fillAmount = timer;            
            Debug.Log(force);
            ThrowGrenade();
        }
    }

    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position + transform.forward * 1, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
        force = 0;
        gameController.Thrower();
        
    }
}
