using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    public Transform platform;
    public Transform start;
    public Transform end;

    public float platformSpeed = 1f;

    public int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    Vector2 currentMovementTarget()
    {
        if (direction == 1) 
            {
                return start.position;
            }
        else 
            {
                return end.position;
            }
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 target = currentMovementTarget();

        platform.position = Vector2.Lerp(platform.position, target, platformSpeed * Time.deltaTime);

        float distance = (target - (Vector2)platform.position).magnitude;

        if (distance <= 0.1f)
        {
            direction *= -1;
        }
    }

    private void OnDrawGizmos()
    {
        if(platform != null && start != null && end != null) 
        {
            Gizmos.DrawLine(platform.position, start.position);
            Gizmos.DrawLine(platform.position, end.position);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
        }
    }
}
