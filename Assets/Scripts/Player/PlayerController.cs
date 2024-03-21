using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private bool isMouseDragging = false;
    private Vector2 startPoint;
    private Vector2 dragVector;
    public int maxDrag = 50;
    // Shooting variables
    public float maxBulletSpeed = 40f;

    public float damage = 20f;
    public float ttl = 3f;

    private float originalSpeed = 5f; // set original speed as 5
    private float currentSpeed;
    private bool isgrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting game");
        currentSpeed = originalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // moving
        Vector2 currentVelocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        if (Input.GetAxis("Horizontal") > 0.001) currentVelocity.x = currentSpeed;
        if (Input.GetAxis("Horizontal") < -0.001) currentVelocity.x = -currentSpeed;
        if (math.abs(Input.GetAxis("Horizontal")) < 0.001) currentVelocity.x = 0;

        if (Input.GetButton("Jump") && isgrounded)
        {
            currentVelocity.y = 9.8f;
            isgrounded = false;
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = currentVelocity;
    
          if (Input.GetMouseButtonDown(0))
        {
            isMouseDragging = true;
            startPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        // animate the player movement 

        // Shooting Controll
        if (Input.GetMouseButtonUp(0))
        {
            if (dragVector.magnitude != 0.0)
            {
                Vector2 direction = new Vector2(0, 0);
                if (dragVector.magnitude > maxDrag)
                {
                    direction = -dragVector.normalized;
                }
                else
                {
                    direction = -dragVector / maxDrag;
                }
                Vector2 velocity = direction * maxBulletSpeed;
                gameObject.GetComponent<ShooterScript>().shoot(velocity, damage, true, ttl, gameObject);
            }
            isMouseDragging = false;
            dragVector = new Vector2(0, 0);
            startPoint = new Vector2(-1, -1);
        }

        if (isMouseDragging)
        {
            dragVector = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - startPoint;
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("lethal"))
        {
            LifeCount.lives--;
            if(LifeCount.lives <= 0)
            {
                Debug.Log("GAME OVER!"); 
            }else{
                StartCoroutine(getHurt());
            }
        }
        else if (other.gameObject.CompareTag("Sap"))
        {
            StartCoroutine(SlowDownSpeed(5f)); // after 5s back to normal speed
        }
        
        
    }

    public void OnCollisionStay2D(Collision2D other)
    {
        // is grounded handling
        foreach (ContactPoint2D contact in other.contacts)
        {
            print(" hit " + contact.otherCollider.name);
            if (Vector2.Angle(contact.normal, Vector2.up) < 45)
            {
                isgrounded = true;
                // Visualize the contact point
                Debug.DrawRay(contact.point, contact.normal, Color.white);
            }
        }    
    }

    // Visualizatin of Hearts decreasing
    IEnumerator getHurt()
    {
        Physics2D.IgnoreLayerCollision(6,7);
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(6,7, false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("seed"))
        {
            BulletCount.seedCount++;
            Destroy(other.gameObject);
        }

    }

    IEnumerator SlowDownSpeed(float duration)
    {
        currentSpeed = originalSpeed / 2; 
        yield return new WaitForSeconds(duration);
        currentSpeed = originalSpeed; 
    }

    // for game over screen
    //https://www.youtube.com/watch?v=0ZJPmjA5Hv0

}
