using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ShootingTowerData", menuName = "Tower/Shooting Tower")]
public class ShootingTowerData : TowerData
{
    public float ShottingDamage;
    public float ShootingReloadTime;
    public RuntimeAnimatorController ShootAnimation;
}
