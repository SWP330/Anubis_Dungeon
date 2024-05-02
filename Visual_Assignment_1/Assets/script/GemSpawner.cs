using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    public GameObject Gems;
    public Transform spawnLocation;

    void Start()
    {
        Instantiate(Gems, spawnLocation.position, spawnLocation.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Vector3 position = new Vector3(Random.Range(-15, 20), Random.Range(1, 5), transform.position.z);
            Instantiate(Gems, position, transform.rotation);
        }
    }

}  


