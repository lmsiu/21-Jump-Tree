using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFallController : MonoBehaviour
{
    public GameObject Sap;
    public Vector3 spawnPosition;
    public float fallInterval = 1.0f; // 下落间隔时间

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fall", 0, fallInterval);
    }

    void Fall()
    {
        Instantiate(Sap, spawnPosition, Quaternion.identity);
    }
}
