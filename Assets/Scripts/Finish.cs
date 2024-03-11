using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject winScreen;

    void Awake()
    {
        winScreen.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    { 
        winScreen.SetActive(true);
    }
}
