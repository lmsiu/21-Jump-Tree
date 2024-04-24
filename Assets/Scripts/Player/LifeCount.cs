using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    //public static int lives = 3;
    public PlayerStats lives;

    public Image[] hearts;

    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Awake()
    {
        //lives.currentLifeCount = lives.MAX_LIFE;
    }
    // Update is called once per frame
    void Update()
    {
        foreach (Image img in hearts)
        {  
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < lives.currentLifeCount; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }
} 
