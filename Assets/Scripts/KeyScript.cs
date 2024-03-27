using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : PhysicsBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void CollideHorizontal(Collider2D other)
    {
        if(other.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);
        }
    }

      public virtual void CollideVertical(Collider2D other)
    {
             if(other.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);
        }

    }

}
