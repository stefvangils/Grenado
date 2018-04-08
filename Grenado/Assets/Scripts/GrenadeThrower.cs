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
        
    }

    void Update () {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if(gameController.buildmode <= 0 && gameController.throwLeft > 0)
        //    {
        //        ThrowGrenade();
        //    }
           
        //}  
        
        if(Input.GetMouseButton(0) && gameController.buildmode <= 0 && gameController.throwLeft > 0)
        {
            timer += Time.deltaTime;
            Loadbar.fillAmount = timer / 4;
            
        }
        if(Input.GetMouseButtonUp(0) && gameController.buildmode <= 0 && gameController.throwLeft > 0)
        {
            force = (throwForce / 2) * timer;
            if(force >= 95)
            {
                force = 95;
            }
            timer = 0;
            Loadbar.fillAmount = timer;            
            Debug.Log(force);
            ThrowGrenade();
        }
    }

    void ThrowGrenade()
    {
        GameObject grenadeObj = Instantiate(grenadePrefab, transform.position + transform.forward * 1, transform.rotation);
        grenade grenadeScript = grenadeObj.GetComponent<grenade>();
        grenadeScript.gameController = gameController;
        Rigidbody rb = grenadeObj.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
        force = 0;
        gameController.Thrower();
        
    }
}
