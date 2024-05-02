using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star_sc : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }
    }
}
