using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobScript : MonoBehaviour
{
    public Vector2 forceDirection = Vector2.left;   // adjust the direction of gobs
    public float forceMagnitude = 0.5f;             // adjust the speed of gobs
    private Rigidbody2D rb;

    [SerializeField]
    // Prefabs
    private GameObject gobPrefab;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // gobs should be spawned by a professor
        rb.AddForce(forceDirection * forceMagnitude);   // moves gobs
    }
}
