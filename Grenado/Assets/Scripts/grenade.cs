using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade : MonoBehaviour {

    public float delay = 3f;
    public float radius = 5f;
    public float force = 700f;


    public GameObject ExplosionSound;

    public GameObject explosionEffect;

    public GameController gameController;


    float countdown;
    bool hasExploded = false;
	// Use this for initialization
	void Start () {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        countdown = delay;
    }
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
        if(countdown <= 0f && !hasExploded)
        {
            explode();
            hasExploded = true;           
        }
	}

    void explode()
    {
        GameObject explosion = Instantiate(explosionEffect, transform.position, transform.rotation);
        Instantiate(ExplosionSound, explosion.transform);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObject in colliders)
        {
            
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb != null && rb.gameObject.tag == "Crate")
            {
                
                rb.AddExplosionForce(force, transform.position, radius);
                gameController.SubtractLives();
                Destroy(nearbyObject);
            }
        }

        Destroy(gameObject);
    }
}
