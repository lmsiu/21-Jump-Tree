using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlayerController : PhysicsBase
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting game");
    }

    // Update is called once per frame
    void Update()
    {
        desiredx = 0;
        if (Input.GetAxis("Horizontal") > 0) desiredx = 3;
        if (Input.GetAxis("Horizontal") < 0) desiredx = -3;

        if (Input.GetButton("Jump") && grounded) velocity.y = 6.5f;
    }
    
    // https://www.youtube.com/watch?v=C_NsmQD6LK8
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
    IEnumerator getHurt()
    {
        Physics2D.IgnoreLayerCollision(6,7);
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(6,7, false);
    }

    public override void CollideVertical(Collider2D other)
    {

    }
}
