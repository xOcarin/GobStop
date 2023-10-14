using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PlayerPointHandler : MonoBehaviour
{
    public int coinCounter = 0; // coin counter

    // Text stuff
    [SerializeField]
    public TextMeshProUGUI coinText;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //coinText.text = coinCounter.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            coinCounter++;
        }
        else if (collision.gameObject.tag == "Shop")
        {
            if (coinCounter >= 3)// player has enough points to buy a gob
            {
                Destroy(collision.gameObject);
                coinCounter = coinCounter - 3;
            }
        }
        else if (collision.gameObject.tag == "fire")
        {
            //death
        }
        else if (collision.gameObject.tag == "saw")
        {
            //death
        }
    }
}
