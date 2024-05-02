using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    public int coinCount = 0;   

    public Transform whiteHole;
    public GameObject SwitchButton;
    public bool boxOpen = false;    
    public GameObject box;

    public float timeRemaining = 3f;
    public bool timerOn = false;

    public Rigidbody2D projectile;
    public Transform fireport;

    public TMP_Text gemText; 
    public TMP_Text timerText;
    public TMP_Text mpText;
    public TMP_Text hpText;
    public float myTimer;

    float horizontalmove = 0f;

    public bool jump = false;
    public bool crouch = false;
    public bool attack = false;

    //hpbar
    public float myHp;
    public float maxHp;
    public Slider hpSlider;

    //mpbar
    public float myMp;
    public float maxMp;
    public Slider mpSlider;

    public int counter;


    public PlayerMovement(bool attack)
    {
        this.attack = attack;
    }

    // Start is called before the first frame update
    void Start()
    {
        myHp = 120;
        maxHp = 120;
        myMp = 100;
        maxMp = 100;
        hpSlider.maxValue = 120;
    }

    // Update is called once per frame
    void Update()
    {
        
        gemText.text = coinCount.ToString("0");
        timerText.text = myTimer.ToString("0.0");
        mpText.text = myMp.ToString("0");
        hpText.text = myHp.ToString("0");

        hpSlider.value = myHp;
        mpSlider.value  = myMp;

        horizontalmove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalmove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            animator.SetBool("IsCrouching", true);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            animator.SetBool("IsCrouching", false);

        }

        if (Input.GetKeyDown(KeyCode.F) && myMp >= 10)
        {
            Invoke("shootingStar", 0f);
            attack = true;
            animator.SetBool("IsAttacking", true);
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            attack = false;
            animator.SetBool("IsAttacking", false);
        }

        if (Input.GetKeyDown(KeyCode.V) && myMp >= 5)
        {
            Invoke("attackEffect", 0f);
            attack = true;
            animator.SetBool("IsAttacking", true);
        }
        else if (Input.GetKeyUp(KeyCode.V))
        {
            attack = false;
            animator.SetBool("IsAttacking", false);
        }


        if (Input.GetKey(KeyCode.R) && myMp < 100)
        {
            myMp += 20*Time.deltaTime;
        }

        teleporter switchScript = SwitchButton.GetComponent<teleporter>();
        if (Input.GetKeyDown(KeyCode.E) && switchScript.switchStatus == true)
        {  
            transform.position = whiteHole.transform.position;
        }

        boxScript boxCS = box.GetComponent<boxScript>();
        if (boxCS.boxBool == true && Input.GetKeyDown(KeyCode.E))
        {
            boxOpen = true;
        }
        else
        {
            boxOpen = false;
        }

        if (myHp <= 0)
        {
            Destroy(gameObject);
        }

        if (myTimer >= 0)
        {
            myTimer = myTimer - Time.deltaTime;
        }
    }

    

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalmove * Time.fixedDeltaTime, crouch, jump);
        jump= false;
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("gem"))
        {
            coinCount++;
        }
        //if (collision.gameObject.CompareTag("teleporter"))
        //{
        //    transform.position = whiteHole.position;
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("enemy"))
        {
            myHp -= 10;
        }
        
    }


    public void shootingStar()
    {
        myMp -= 10;

        Rigidbody2D star;
        star = Instantiate(projectile, fireport.transform.position, transform.rotation);

        int run = controller.facingRight ? 1 : -1;
        star.AddForce(new Vector2(run * 15, 0), ForceMode2D.Impulse);
        Destroy(star.gameObject, 1.5f);
        counter++;

        if (counter == 5)
        {
            CancelInvoke("shootingStar");
            counter = 0;
        }


    }

    public void attackEffect()
    {
        myMp -= 5;

        Rigidbody2D star;
        star = Instantiate(projectile, fireport.transform.position, transform.rotation);

        int run = controller.facingRight ? 1 : -1;
        star.AddForce(new Vector2(run * 15, 0), ForceMode2D.Impulse);
        Destroy(star.gameObject, 0.1f);
        counter++;

        if (counter == 5)
        {
            CancelInvoke("attackEffect");
            counter = 0;
        }


    }

}
