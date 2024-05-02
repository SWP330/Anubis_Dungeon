using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class inventoryScript : MonoBehaviour
{
    public Button item1;
    public Button item2;
    public Button item3;
    public GameObject inventory;
    bool InvToggle = false;
    public PlayerMovement playerMovement;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            InvToggle = !InvToggle;
            inventory.gameObject.SetActive(InvToggle);
        }
    }

    public void eatFood()
    {
        playerMovement.gameObject.GetComponent<PlayerMovement>().myHp += 50;
    }
}
