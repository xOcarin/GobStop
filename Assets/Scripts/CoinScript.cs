using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinScript : MonoBehaviour
{
    [SerializeField]
    // Prefabs
    public GameObject coinPrefab;

    // GameObjects

    public PlayerPointHandler handler;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //coinText.text = coinCounter.ToString();
    }
}
