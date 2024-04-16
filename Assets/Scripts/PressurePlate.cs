using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public PlatformScript ActivationTarget;

    private bool _activated;
    // Start is called before the first frame update
    void Start()
    {
        _activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        _activated = true;
        ActivationTarget.Activate();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _activated = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        other.transform.SetParent(null);
    }
}
