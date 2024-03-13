using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float ttl;
    public GameObject owner;
    public bool isPlayer;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        // hide bullet when start
    }
    
    public void startSelfDestruct()
    {
       StartCoroutine(Disappear()); 
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(ttl);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
