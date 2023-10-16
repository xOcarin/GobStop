using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlat : MonoBehaviour
{
    public Vector2 startPoint;
    public Vector2 endPoint;
    public float speed = 2.0f;

    private bool movingToEnd = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Vector2 target = movingToEnd ? endPoint : startPoint;
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, step);

        if (Vector2.Distance(transform.position, target) < 0.01f)
        {
            movingToEnd = !movingToEnd;
        }
    }
}
