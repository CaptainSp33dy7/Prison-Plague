using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1f;

    [SerializeField] private GameObject[] enemyPrefabs;

    [SerializeField] private bool canSpawn = true;

    public Transform player;

    private GameObject enemy;

    /// <summary>
    /// Metoda Start() se spusti jeste pred vyrenderovanim prvniho frameu a v pripade tohoto skriptu zacne coroutine, co umoznuje rozlozit kod do vice frameu.
    /// </summary>
    private void Start()
    {
        StartCoroutine(Spawner());
    }

    /// <summary>
    /// Deklarace coroutine, ktera nam umoznuje vlozit postavu nepritele do sceny, pak pockat nekolik vterin a vlozit tam dalsiho, jelikoz diky coroutine se kod 
    /// na konci frameu pouze prerusi a po vyckani nami nastaveneho casu pokracuje tam, kde skoncil.
    /// </summary>
    /// <returns></returns>
    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;

            int rand = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyToSpawn = enemyPrefabs[rand];

            enemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
        }
    }

    /// <summary>
    /// Metoda Update(), se vola kazdy frame a v tomto skriptu prirazuje vlozene komponente AIDestinationSetter postavy nepritele polohu hrace na mape.
    /// </summary>
    void Update()
    {
        enemy.GetComponent<AIDestinationSetter>().target = player;
    }
}
