using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxScript : MonoBehaviour
{
    public bool boxBool = false;
    Animator anim;
    public PlayerMovement myController;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (myController.gameObject.GetComponent<PlayerMovement>().boxOpen == true)
        {
            anim.SetBool("BoxOpen", true);
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && boxBool != true)
        {
            boxBool = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            boxBool = false;
        }
    }
}
