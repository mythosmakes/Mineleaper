using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    public int lives = 3;
    public GameObject loseScreen;

    void Awake()
    {
        loseScreen.SetActive(false);
    }

    public void Death()
    {
        lives -= 1;

        if (lives < 1)
        {
            loseScreen.SetActive(true);
        }
    }
}
