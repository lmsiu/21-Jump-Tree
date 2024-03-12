using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlayerController : PhysicsBase
{

    private bool isMouseDragging = false;
    private Vector2 startPoint;
    private Vector2 dragVector;
    public int maxPowerDrag = 50;
    public GameObject bullet;
    public float maxBulletSpeed = 40f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting game");
    }

    // Update is called once per frame
    void Update()
    {
        // moving
        desiredx = 0;
        if (Input.GetAxis("Horizontal") > 0) desiredx = 3;
        if (Input.GetAxis("Horizontal") < 0) desiredx = -3;

        if (Input.GetButton("Jump") && grounded) velocity.y = 6.5f;
    
    
        // shooting
        if (Input.GetMouseButtonDown(0))
        {
            isMouseDragging = true;
            startPoint = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (dragVector.magnitude != 0.0)
            {
                shoot(-dragVector);
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

    // for game over screen
    //https://www.youtube.com/watch?v=0ZJPmjA5Hv0


    
   
    // shooting
    void shoot(Vector2 direction)
    {
        Vector2 velocity = direction.normalized * (dragVector.magnitude / maxPowerDrag) * maxBulletSpeed;
        print(transform.position);
    	GameObject b = Instantiate(bullet, transform.position + (new Vector3(direction.normalized.x, direction.normalized.y, 0) * 0.7f), Quaternion.Euler(0, 0, 0));
    	b.GetComponent<Rigidbody2D>().velocity = velocity;
    	BulletController bc = b.GetComponent<BulletController>();
    	bc.damage = 20;
    	bc.isPlayer = true;
    	bc.ttl = 3f;
    	bc.bullet = gameObject;
    	bc.startSelfDestruct();
    }
    

}
