using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletCount : MonoBehaviour
{
    public static int seedCount = 0; 

    public TextMeshProUGUI seedText;

    void Awake()
    {
        seedCount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        seedText.text = "x " + seedCount;
    }   
}