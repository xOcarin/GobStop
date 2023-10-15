using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class Token
{
    public float spawnTime;
    public GameObject gameObject1;  // Assuming this is the prefab
    public GameObject gameObject2;  // Assuming this is the name

    public Token(float time, GameObject prefab, GameObject name)
    {
        this.spawnTime = time;
        this.gameObject1 = prefab;
        this.gameObject2 = name;
    }
}
public class ProfessorScript : MonoBehaviour
{
    [SerializeField]
    // Prefabs
    public GameObject gobPrefab;

    // GameObjects
    public GameObject Gob;

    public float forceAmount = 300.0f;


    // Start is called before the first frame update
    void Start()
    {
        
        //Token GobObject = new Token(3.0f, gobPrefab, Gob);
        


        StartCoroutine(SpawnCycleGobs(/*GobObject.spawnTime, GobObject.gameObject1, GobObject.gameObject2*/));
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
            StartCoroutine(SpawnGobs(/*gobToSpawn.spawnTime, gobToSpawn.gameObject1, gobToSpawn.gameObject2*/));

            // this was pulled from Null Nukem. I'm not sure how correct it is
            float time = 1f + UnityEngine.Random.value * 5f;
            yield return new WaitForSeconds(time);
        }
    }

    // SPAWN
    IEnumerator SpawnGobs(/*float waitTime, GameObject prefab, GameObject name*/)
    {
        //// coordinates to spawn gobs at
        //float x = transform.position.x - 1.5f; // just to the left of the professor
        //float y = transform.position.y;
        //Vector3 position = new Vector3(x, y, -1f);

        //name = Instantiate(gobPrefab, position, Quaternion.identity);

        Vector3 spawnPos = getSpawnPos();
        GameObject newGob = Instantiate(gobPrefab, spawnPos, Quaternion.identity);
        Rigidbody2D rb = newGob.GetComponent<Rigidbody2D>();

        rb.AddForce(GobScript.forceDirection * forceAmount, ForceMode2D.Force);

        yield return new WaitForSeconds(5);
        // figure out if player has purchased current shop's gob and move professor to the next one if so
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