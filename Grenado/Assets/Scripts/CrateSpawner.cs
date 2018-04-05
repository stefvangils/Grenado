using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSpawner : MonoBehaviour {

    public GameObject cratePrefab;

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            spawnCrate();
        }
    }

    void spawnCrate()
    {
        GameObject crate = Instantiate(cratePrefab, transform.position + transform.forward * 5 + transform.up * 5, transform.rotation);
        Rigidbody rb = crate.GetComponent<Rigidbody>();
    }
}
