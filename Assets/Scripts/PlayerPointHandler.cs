using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class PlayerPointHandler : MonoBehaviour
{
    public int coinCounter = 0; // coin counter
    public int gobCounter = 0; // gob counter
    public int coinsNeeded = 1; // gob counter

    // Text stuff
    [SerializeField]
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI gobText;
    public TextMeshProUGUI needText;

    public GameObject ProfessorPrefab;

    public GameObject Professor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + coinCounter.ToString();
        gobText.text = "Gobs: " + gobCounter.ToString();
        needText.text = "Price " + coinsNeeded.ToString();
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
            if (coinCounter >= coinsNeeded)// player has enough points to buy a gob
            {
                Destroy(collision.gameObject);
                coinCounter = 0;
                gobCounter++;
                coinsNeeded++;

                Destroy(Professor);
                // move the professor and despawn all gobs on screen
            }
        }
        else if (collision.gameObject.tag == "fire")
        {
            SceneManager.LoadScene("DEATH");
        }
        else if (collision.gameObject.tag == "saw")
        {
            SceneManager.LoadScene("DEATH");

        }
        else if (collision.gameObject.tag == "gob")
        {
            SceneManager.LoadScene("DEATH");
        }
    }
}
