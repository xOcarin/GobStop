using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GobScript : MonoBehaviour
{
    public static Vector2 forceDirection = Vector2.left;   // adjust the direction of gobs
    public float forceMagnitude = 1.0f;             // adjust the speed of gobs
    private Rigidbody2D rb;
    private float despawnTime = 6f;
    private float startTime;


    [SerializeField]
    // Prefabs
    private GameObject gobPrefab;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(forceDirection * forceMagnitude);   // moves gobs

        if (Time.time - startTime > despawnTime)
        {
            Destroy(gameObject);
        }
    }
}
