// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    // Game Over
    public static bool isGameOver;
    public GameObject gameOverScreen;

    private void Awake()
    {
        isGameOver = false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void ReplayLevel()
    {
        Debug.Log("Replay clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}