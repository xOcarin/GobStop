using UnityEngine;

public class MovingPlat : MonoBehaviour
{
    public Vector2 offset = new Vector2(5.0f, 0.0f); // Adjust the offset as needed
    public Vector2 startPoint;
    public Vector2 endPoint;
    public float speed = 2.0f;

    private bool movingToEnd = true;

    void Start()
    {
        startPoint = transform.position;
        endPoint = startPoint + offset;
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