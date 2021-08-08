using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    ///<summary>
    /// Тут будет набор событий которые будут запускать большую волну зомби 
    /// либо босса.
    /// Необходимо подписаться на собития о смертях мобов.
    ///</summary>

    private int _firstWaveZombiesAmount;
    private int _secondWaveZombiesAmount;
    private int _hugeWaveZombiesAmount;
    private int _zombiezDiedInWaveAmount;
    private int _timeBetweenSpawn;
    private int _enemySpawned;
    private int _enemySpawnedInMicroWave;
    [SerializeField] private List<Spawner> _spawners = new List<Spawner>();

    public static event OnWin onWin;
    public delegate void OnWin();

    private void Start()
    {
        Enemy.onEnemyDown += onEnemyDown;

        _firstWaveZombiesAmount = 4;
        _secondWaveZombiesAmount = 12;
        _hugeWaveZombiesAmount = 20;

        _zombiezDiedInWaveAmount = 0;
        _timeBetweenSpawn = 1;
        _enemySpawned = 0;
        _enemySpawnedInMicroWave = 0;
        StartCoroutine(ZombiesWave(_firstWaveZombiesAmount));
    }

    IEnumerator EnemySpawn(int microWave)
    {
        _spawners[Random.RandomRange(0, 4)].SingleEnemySpawn();
        _enemySpawned++;
        _enemySpawnedInMicroWave++;
        yield return new WaitForSeconds(_timeBetweenSpawn);
        if (_enemySpawnedInMicroWave == microWave)
        {
            _enemySpawnedInMicroWave = 0;
            StopCoroutine(EnemySpawn(microWave));
        }
        else
        {
            StartCoroutine(EnemySpawn(microWave));
        }
    }
    IEnumerator ZombiesWave(int zombiesInWave)
    {
        StartCoroutine(EnemySpawn(zombiesInWave/4));
        yield return new WaitForSeconds(_timeBetweenSpawn+10);
        if (_enemySpawned == zombiesInWave)
        {
            StopAllCoroutines();
        }
        else
        {
            StartCoroutine(ZombiesWave(zombiesInWave));
        }
    }
    private void onEnemyDown()
    {
        _zombiezDiedInWaveAmount++;
        if (_zombiezDiedInWaveAmount == _firstWaveZombiesAmount)
        {
            _enemySpawned = 0;
            StopAllCoroutines();
            StartCoroutine(ZombiesWave(_secondWaveZombiesAmount));
        }
        else if (_zombiezDiedInWaveAmount == _secondWaveZombiesAmount + _firstWaveZombiesAmount)
        {
            _enemySpawned = 0;
            StopAllCoroutines();
            StartCoroutine(ZombiesWave(_hugeWaveZombiesAmount));
        }
        else if (_zombiezDiedInWaveAmount == _hugeWaveZombiesAmount + _secondWaveZombiesAmount + _firstWaveZombiesAmount)
        {
            onWin?.Invoke();
        }
    }


}
