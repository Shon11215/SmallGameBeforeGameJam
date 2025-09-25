using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    public int enemyScore = 10;
    public GameObject area;
    //[SerializeField] float radius = 15f;
    Vector2 randomDir;
    Vector3 spawnPos;

    void Start()
    {
        Bounds bounds =  area.GetComponent<Renderer>().bounds;
        float spawnRadius = MathF.Max(bounds.extents.x, bounds.extents.y) + 5f ;
        //spawnPos = bounds.center + (Vector3)randomDir * spawnRadius;
        for(int i = 0; i < 4; i++)
        {
            randomDir = UnityEngine.Random.insideUnitCircle.normalized;
            spawnPos = bounds.center + (Vector3)randomDir * spawnRadius;
            Instantiate(enemy, spawnPos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
