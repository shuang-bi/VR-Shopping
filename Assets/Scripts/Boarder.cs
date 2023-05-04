using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boarder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            other.GetComponent<Renderer>().enabled = false;
            var canvasGroup = other.GetComponentInChildren<CanvasGroup>();
            canvasGroup.alpha = 0;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            other.GetComponent<Renderer>().enabled = true;
            var canvasGroup = other.GetComponentInChildren<CanvasGroup>();
            canvasGroup.alpha = 1;
        }
    }
}
