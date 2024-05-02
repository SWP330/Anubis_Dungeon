
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using Unity.IO.LowLevel.Unsafe;

[RequireComponent(typeof(Rigidbody2D))]
public class movement_sc : MonoBehaviour
{
    public Animator animator;
    public int bugCount = 0;
    public bool endStatus = false;

    enum Direction
    {
        left, right, up, down
    }

    [SerializeField]private float moveSpeed;

    private Rigidbody2D rb;
    private bool isMoveActive = true;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // move
    private Vector2 OnGetMoveDirection(Direction movingDir)
    {
        Vector2 currentDirection = new Vector2();

        switch (movingDir)
        {
            case Direction.left:
            currentDirection = new Vector2(-1, 0);
            break;

            case Direction.right:
            currentDirection = new Vector2(1, 0);
            break;

            case Direction.up:
            currentDirection = new Vector2(0, 1);
            break;

            case Direction.down:
            currentDirection = new Vector2(0, -1);
            break;
        }

        return currentDirection;
    }

    // Update is called once per frame
    // Get input
    private void Update()
    {

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) 
            {
                onMove(Direction.left);
                animator.SetFloat("Horizontal", -1);
                animator.SetFloat("Speed", 1);
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                onMove(Direction.right);
                animator.SetFloat("Horizontal", 1);
                animator.SetFloat("Speed", 1);
            }
            else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) 
            {
                onMove(Direction.up);
                animator.SetFloat("Vertical", 1);
                animator.SetFloat("Speed", 1);
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                onMove(Direction.down);
                animator.SetFloat("Vertical", -1);
                animator.SetFloat("Speed", 1);
            }
            



    }

    private void onMove(Direction movingDir)
    {
        // Check if movement is active
        if (!isMoveActive)
        {
            return; // Movement is not active, return early
        }

        // Disable movement until the current move is completed
        isMoveActive = false;

        // Get the current move direction
        Vector2 currentMoveDirection = OnGetMoveDirection(movingDir);

        // Check if the move direction is valid
        if (currentMoveDirection != Vector2.zero)
        {
            // Apply velocity based on move direction and speed
            rb.velocity = currentMoveDirection * moveSpeed;

            // Set the animation parameters
            animator.SetFloat("Horizontal", currentMoveDirection.x);
            animator.SetFloat("Vertical", currentMoveDirection.y);

            // Wait for the current move to be completed
            WaitForSeconds wait = new WaitForSeconds(1 / moveSpeed);
            StartCoroutine(WaitForMoveToComplete(wait));
        }
        else
        {
            // Log an error or handle invalid move direction
            Debug.LogError("Invalid move direction!");

            // Reset the animation parameters
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
        }
    }

    private IEnumerator WaitForMoveToComplete(WaitForSeconds wait)
    {
        yield return wait;

        // Check if the character is still colliding with the wall
        if (rb.velocity == Vector2.zero)
        {
            isMoveActive = true;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rb.velocity == Vector2.zero)
        {
            isMoveActive = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag  ("bug") )
        {
            bugCount ++;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("endPoint"))
        {
            endStatus = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("endPoint"))
        {
            endStatus = false;
        }
    }
}
