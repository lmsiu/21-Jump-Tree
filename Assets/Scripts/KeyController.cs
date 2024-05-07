using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{

    public GameObject player;
    public bool playerPickedUp;

    public Vector2 velocity;
    // how smooth the key should float
    public float smoothTime;

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (playerPickedUp)
        {
            Vector3 offset = new Vector3(-1.5f, 1, 0); // if the key is right on the player, the player will slow down a lot
            transform.position = Vector2.SmoothDamp(transform.position, player.transform.position + offset, ref velocity, smoothTime);

        }


    }

    // once player has picked up the key
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!playerPickedUp && other.gameObject.CompareTag("Player"))
        {
            playerPickedUp = true;
            AudioManager.instance.Play("Key");
            Debug.Log("Key picked up");
        }

    }
}