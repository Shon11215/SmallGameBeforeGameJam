using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    private List<int> enemyCosts = new List<int>();

    public GameObject area;
    Vector2 randomDir;
    Vector3 spawnPos;
    Bounds bounds;
    public int wave = 1;
    [SerializeField] private int baseBudget = 5;
    [SerializeField] private int budgetGrowth = 3;


    void Awake()
    {
        foreach (GameObject prefab in enemyPrefabs)
        {
            EnemyManager stats = prefab.GetComponent<EnemyManager>();
            if (stats != null)
            {
                enemyCosts.Add(stats.GetCost());
            }
        }
    }
    void Start()
    {
        bounds =  area.GetComponent<Renderer>().bounds;
        SpawnWave();
    }
    private void Update()
    {

    }
    public void SpawnWave()
    {
        int budget = baseBudget + budgetGrowth * (wave - 1);
        List<int> enemies = new List<int>();
        int safty = 2000;
        while (budget > 0 && safty-- > 0) 
        {
            int enemyIndex = UnityEngine.Random.Range(0, enemyPrefabs.Count);
            if (enemyCosts[enemyIndex] <= budget)
            {
                enemies.Add(enemyIndex);
                budget -= enemyCosts[enemyIndex];
                //Debug.Log(enemyCosts[enemyIndex]);
            }
        }
        float spawnRadius = MathF.Max(bounds.extents.x, bounds.extents.y) + 5f;
        foreach (int i in enemies)
        {
            randomDir = UnityEngine.Random.insideUnitCircle.normalized;
            spawnPos = bounds.center + (Vector3)randomDir * spawnRadius;
            Instantiate(enemyPrefabs[i], spawnPos, Quaternion.identity);


        }
    }

}

