using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsBase
{

    public LifeCount lifeCount;
    private bool isMouseDragging = false;
    private Vector2 startPoint;
    private Vector2 dragVector;
    public int maxDrag = 50;

    //Player Animation
    private Animator player_animator;


    // Shooting variables
    public float maxBulletSpeed = 40f;

    public float damage = 20f;
    public float ttl = 3f;

    private float originalSpeed = 5f; // set original speed as 5
    private float currentSpeed;

      
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting game");
        currentSpeed = originalSpeed;
        player_animator = GetComponent<Animator>();
    }


    // Update is  called once per frame
    void Update()
    {
        // moving
        desiredx = 0;
        if (Input.GetAxis("Horizontal") > 0) 
        {
            desiredx = currentSpeed;
            GetComponent<SpriteRenderer>().flipX = true;
           
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            desiredx = -currentSpeed;
            GetComponent<SpriteRenderer>().flipX = false;
            
        }
         

        if (Input.GetButton("Jump") && grounded)
        {
            velocity.y = 8.5f;
            AudioManager.instance.PlaySFX("Jump"); 
        }
        
    
        // For Shooting Control    
        if (Input.GetMouseButtonDown(0))
        {
            isMouseDragging = true;
            startPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            AudioManager.instance.PlaySFX("Shoot");
        }

        // Animate the player movement 
        player_animator.SetFloat("MoveX", desiredx);
  

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
                if(BulletCount.seedCount > 0)
                {
                	gameObject.GetComponent<ShooterScript>().shoot(velocity, damage, true, ttl, gameObject);
                	BulletCount.seedCount--;
                }
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

    // Player falls down
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Floor"){
            Debug.Log("Player hits the floor");
            PlayerManager.isGameOver = true;
            AudioManager.instance.PlaySFX("GameOver");
        }
    }

    
    public override void CollideHorizontal(Collider2D other)
    {
        if(other.gameObject.CompareTag("lethal"))
        {
            lifeCount.lives.currentLifeCount--;
            if(lifeCount.lives.currentLifeCount <= 0)
            {
                PlayerManager.isGameOver = true;
                AudioManager.instance.PlaySFX("GameOver");
            }else{
                StartCoroutine(getHurt());
            }
        }
        else if (other.gameObject.CompareTag("Sap"))
        {
            StartCoroutine(SlowDownSpeed(5f)); // after 5s back to normal speed
        }
    }

    // Visualizatin of Hearts decreasing
    IEnumerator getHurt()
    {
        Physics2D.IgnoreLayerCollision(6,7);
        yield return new WaitForSeconds(1);
        Physics2D.IgnoreLayerCollision(6,7, false);
        AudioManager.instance.PlaySFX("Hit");
    }

    public override void CollideVertical(Collider2D other)
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("seed"))
        {
            BulletCount.seedCount++;
            Destroy(other.gameObject);
            AudioManager.instance.PlaySFX("Seed");
        }

    }

    IEnumerator SlowDownSpeed(float duration)
    {
        currentSpeed = originalSpeed / 2; 
        yield return new WaitForSeconds(duration);
        currentSpeed = originalSpeed; 
    }
}
