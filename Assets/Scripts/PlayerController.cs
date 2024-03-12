using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsBase
{
    private bool isMouseDragging = false;
    private Vector2 startPoint;
    private Vector2 dragVector;
    public int maxDrag = 50;
    // Shooting variables
    public float maxBulletSpeed = 40f;

    public float damage = 20f;
    public float ttl = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        desiredx = 0;
        if (Input.GetAxis("Horizontal") > 0) desiredx = 3;
        if (Input.GetAxis("Horizontal") < 0) desiredx = -3;

        if (Input.GetButton("Jump") && grounded) velocity.y = 6.5f;
        
        
        
        if (Input.GetMouseButtonDown(0))
        {
            isMouseDragging = true;
            startPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

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
    

}
