using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : PhysicsBase

{
    //variable that tracks how much the enemy has moved to one side
    // public int moved; 
    // // how much an enemy moves at a time
    // public int moveAmount;
    // Start is called before the first frame update
    void Start()
    {
        // moved = 0;
        // moveAmount = -5;

        desiredx = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        // move to the left
        // if(grounded){
        //     //if the enemy has already moved 20 times in one direction, move it the opisite direction
        //     if(moved > 20){
        //         moveAmount = moveAmount*(-1);
        //         moved = 0;
        //     }
        //     desiredx = moveAmount;
        //     moved++;
        // }
    }

    public override void CollideHorizontal(Collider2D other)
    {
        desiredx = -desiredx;
    }

}
