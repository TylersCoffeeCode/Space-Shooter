using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    private bool _stopSpawning = false;
    [SerializeField]
    private GameObject _tripleShotPowerupPrefab;
    [SerializeField]
    private GameObject _powerupContainer;
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());

    }

    void Update()
    {
        
    }


    IEnumerator SpawnEnemyRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);

        }
    }

    IEnumerator SpawnPowerupRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8.0f, 8), 7, 0);
            GameObject newTripleShotPowerup = Instantiate(_tripleShotPowerupPrefab, posToSpawn, Quaternion.identity);
            newTripleShotPowerup.transform.parent = _powerupContainer.transform;
            yield return new WaitForSeconds(Random.Range(3.0f, 11.0f));
        }
        
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}
