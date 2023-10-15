using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UIElements;

public class ProfessorScript : MonoBehaviour
{
    [SerializeField]
    // Prefabs
    public GameObject gobPrefab;

    // GameObjects
    public GameObject Gob;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCycleGobs());
    }

    // Update is called once per frame
    void Update()
    {
        
        // potentially change the position of the professor here??
    }


    IEnumerator SpawnCycleGobs()
    {
        while (true)
        {
            StartCoroutine(SpawnGobs());
            float time = 1f + UnityEngine.Random.value * 6f;
            yield return new WaitForSeconds(time);
        }
    }

    // SPAWN
    IEnumerator SpawnGobs()
    {
        Vector3 spawnPos = getSpawnPos();
        GameObject newGob = Instantiate(gobPrefab, spawnPos, Quaternion.identity);
        Rigidbody2D rb = newGob.GetComponent<Rigidbody2D>();

        rb.AddForce(GobScript.forceDirection * 100, ForceMode2D.Force);

        yield return new WaitForSeconds(5);
    }

    public Vector3 getSpawnPos()
    {
        // coordinates to spawn gobs at
        float x = transform.position.x - 1.5f; // just to the left of the professor
        float y = transform.position.y;
        Vector2 position = new Vector2(x, y);

        return position;
    }
}