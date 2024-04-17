using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : PhysicsBase

{
    // Min position that the enemy can move to
    public float minMove = 2f;
    // Max position that the enemy can move to
    public float maxMove = 3f;
    // how much to move by
    public static int MOVEAMOUNT = 3;
    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        // start positionis the min movement
        minMove = transform.position.x;
        maxMove = transform.position.x+MOVEAMOUNT;

        desiredx = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Mathf.Abs(maxMove - transform.position.x) <= .1 && spriteRenderer.flipX == true)|| (Mathf.Abs(transform.position.x - minMove) <= .1 && spriteRenderer.flipX == false)) {
            //flip 
            spriteRenderer.flipX = !spriteRenderer.flipX ;
            Debug.Log("flipped");
        }

        // move back and forth
        transform.position = new Vector3(Mathf.PingPong(Time.time*2,maxMove-minMove)+minMove, transform.position.y, transform.position.z);

    }

    public override void CollideHorizontal(Collider2D other)
    {
        if(other.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);
            Debug.Log("horizantal hit");
        }
    }

    // public override void CollideVertical(Collider2D other)
    // {
    //         if(other.gameObject.CompareTag("bullet"))
    //     {
    //         Destroy(gameObject);
    //         Debug.Log("verticle hit");
    //     }
        
    // }
}
