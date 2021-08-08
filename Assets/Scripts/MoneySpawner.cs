using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coin;
    private float _xCoordinateToSpawn;
    private float _spawnPeriod = 3f;
    private float _timer;
    private void Update()
    {
        _timer = _timer + Time.deltaTime;
        if (_timer > _spawnPeriod)
        {
            CoinSpawn();
            _spawnPeriod = Random.Range(5f, 10f);
            _timer = 0;
        }
    }

    private void CoinSpawn()
    {
        _xCoordinateToSpawn = Random.Range(0,5);
        var coin = Instantiate(this._coin, new Vector3(_xCoordinateToSpawn, 12, -1), Quaternion.identity);
        coin.GetComponent<Money>().IsSkyFallingCoin = true;
    }
}
