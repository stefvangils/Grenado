﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour {

    
    public float throwForce = 40f;
    public GameObject grenadePrefab;
	

	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            ThrowGrenade();
        }      
    }

    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position + transform.forward * 1, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);
    }
}
