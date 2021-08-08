using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingTower : Tower
{
    private StandingTowerData _standingTowerParametrs;
    public float ContactDamage;

    public override void Init(TowerData towerSettings)
    {
        base.Init(towerSettings);
        _standingTowerParametrs = (StandingTowerData)towerSettings;
        ContactDamage = _standingTowerParametrs.ContactDamage;
    }
}
