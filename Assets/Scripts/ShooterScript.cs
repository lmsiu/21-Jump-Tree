using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{

    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void shoot(Vector2 velocity, float damage, bool isPlayer, float ttl, GameObject origin)
    {
        GameObject b = Instantiate(bullet, transform.position + (new Vector3(velocity.normalized.x, velocity.normalized.y, 0) * 0.7f), Quaternion.Euler(0, 0, 0));
        b.GetComponent<Rigidbody2D>().velocity = velocity;
        b.tag = "bullet";
        BulletController bc = b.GetComponent<BulletController>();
        bc.damage = damage;
        bc.isPlayer = isPlayer;
        bc.ttl = ttl;
        bc.owner = origin;
        bc.startSelfDestruct();
    }
}
