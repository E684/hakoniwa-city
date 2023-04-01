using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RedKnightSpawner : MonoBehaviour
{
    public GameObject redknightPrefab;
    public Transform spawnPoint;
    public float initialCooltime = 1f;
    public float spawnInterval = 10f;

    private float _currentCooltime = 0;

    private void Start()
    {
        InitCooltime();
    }

    // Update is called once per frame
    void Update()
    {
        ConsumeCooltime();
        SpawnEnemy();
    }

    private void ConsumeCooltime()
    {
        _currentCooltime = _currentCooltime - Time.deltaTime;
    }

    private void SpawnEnemy()
    {
        if (_currentCooltime < 0)
        {
            GameObject obj = GameObject.Instantiate(redknightPrefab, this.transform);
            obj.transform.position = spawnPoint.position;

            obj.AddComponent<NavMeshAgent>(); // NavMesh‚É\•ª‹ß‚¢ó‘Ô‚ÅComponent‚ğì‚ç‚È‚¢‚ÆAgent‚ª‹@”\‚µ‚È‚¢

            ResetCooltime();
        }
    }

    private void InitCooltime()
    {
        _currentCooltime = initialCooltime;
    }

    private void ResetCooltime()
    {
        _currentCooltime = spawnInterval;
    }

}
