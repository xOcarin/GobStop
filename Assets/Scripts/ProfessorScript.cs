using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        Token GobObject = new Token(3.0f, gobPrefab, Gob);
        StartCoroutine(SpawnCycleGobs(GobObject));
    }

    // Update is called once per frame
    void Update()
    {
        // potentially change the position of the professor here??
    }

    IEnumerator SpawnCycleGobs(Token gobToSpawn)
    {
        while (true)
        {
            StartCoroutine(SpawnGobs(gobToSpawn.spawnTime, gobToSpawn.gameObject1, gobToSpawn.gameObject2));

            // this was pulled from Null Nukem. I'm not sure how correct it is
            float time = 0f + UnityEngine.Random.value * 3f;
            yield return new WaitForSeconds(time);
        }
    }

    // SPAWN
    IEnumerator SpawnGobs(float waitTime, GameObject prefab, GameObject name)
    {
        // coordinates to spawn gobs at
        float x = transform.position.x - 1; // just to the left of the professor
        float y = transform.position.y;
        Vector3 position = new Vector3(x, y, -1f);

        name = Instantiate(prefab, position, Quaternion.identity);
        yield return new WaitForSeconds(waitTime);

        // 
    }
}
