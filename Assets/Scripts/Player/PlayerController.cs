using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

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

    private float originalSpeed = 3f; // 假设原始移动速度为3
    private float currentSpeed;

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
        desiredx = 0;
        if (Input.GetAxis("Horizontal") > 0) desiredx = currentSpeed;
        if (Input.GetAxis("Horizontal") < 0) desiredx = -currentSpeed;

        if (Input.GetButton("Jump") && grounded) velocity.y = 6.5f;
    
    
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
    
    public override void CollideHorizontal(Collider2D other)
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
            StartCoroutine(SlowDownSpeed(5f)); // 5秒后恢复正常速度
        }
    }

    // Visualizatin of Hearts decreasing
    IEnumerator getHurt()
    {
        Physics2D.IgnoreLayerCollision(6,7);
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(6,7, false);
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
        }

    }

    IEnumerator SlowDownSpeed(float duration)
    {
        currentSpeed = originalSpeed / 2; // 将当前速度设置为原始速度的一半
        yield return new WaitForSeconds(duration);
        currentSpeed = originalSpeed; // 恢复原始速度
    }

    // for game over screen
    //https://www.youtube.com/watch?v=0ZJPmjA5Hv0

}
