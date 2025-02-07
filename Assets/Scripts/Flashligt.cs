using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private GameObject spotlight;
    private bool isFlashlightOn = true;

    public bool grabActive = false;
    void Update()
    {
        
        
        if (isFlashlightOn)
        {
            spotlight.SetActive(true);
        }
        else
        {
            spotlight.SetActive(false);
        }
    }
}