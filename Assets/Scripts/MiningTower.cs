using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningTower : Tower
{
    private MiningTowerData _miningTowerParametrs;
    [SerializeField] private GameObject _coin;
    private void Start()
    {
        StartCoroutine(Mining());
    }
    public override void Init(TowerData _towerSettings)
    {
        base.Init(_towerSettings);
        _miningTowerParametrs = (MiningTowerData)_towerSettings;
    }

    IEnumerator Mining()
    {
        yield return new WaitForSeconds(_miningTowerParametrs.MiningTime + Random.RandomRange(-10, 10));
        var coin = Instantiate(_coin, transform.position,Quaternion.identity);
        coin.GetComponent<Money>().IsSkyFallingCoin = false;
    }
}
