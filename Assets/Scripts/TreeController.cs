using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreeController : MonoBehaviour
{
    public bool locked;
    public string nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("key"))
        {
            locked = false;
            // allows for the same script to be used for different levels
            //string nextLevelName = "Level0" + nextLevel;
            //AudioManager.instance.Play("Checkpoint");
            SceneManager.LoadScene(nextLevel);
            Debug.Log("Loading scence " + nextLevel);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("key"))
        {
            locked = true;
        }
    }
}
