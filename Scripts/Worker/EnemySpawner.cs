using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 3f;
    public Transform[] destinationPoints;

    private float _currentCooltime = 0;

    private void Start()
    {
        ResetCooltime();
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
        if(_currentCooltime < 0)
        {
            GameObject obj = GameObject.Instantiate(enemyPrefab, this.transform);
            obj.transform.localPosition = Vector3.zero;

            obj.AddComponent<NavMeshAgent>(); // NavMeshÇ…è\ï™ãﬂÇ¢èÛë‘Ç≈ComponentÇçÏÇÁÇ»Ç¢Ç∆AgentÇ™ã@î\ÇµÇ»Ç¢

            SetWaypoints(obj.GetComponent<Locomotable>());


            ResetCooltime();
        }
    }

    private void ResetCooltime()
    {
        _currentCooltime = spawnInterval;
    }

    private void SetWaypoints(Locomotable locomotable)
    {
        if(locomotable == null)
        {
            return;
        }

        locomotable.SetWaypoints(destinationPoints);
        locomotable.StartLocomote();
    }
}
