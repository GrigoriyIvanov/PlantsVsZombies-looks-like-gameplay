using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTower : Tower
{
    private ShootingTowerData _towerData;
    [SerializeField] private GameObject _bullet;
    
    public override void Init(TowerData towerData)
    {
        base.Init(towerData);
        _towerData = (ShootingTowerData)towerData;
        StartCoroutine(Shooting());
    }
    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(_towerData.ShootingReloadTime);
        Shoot();
        StartCoroutine(Shooting());
    }
    IEnumerator ShotAnim()
    {
        yield return new WaitForSeconds(_towerData.ShootAnimation.animationClips[0].length);
        GetComponent<Animator>().runtimeAnimatorController = null;
    }
    private void Shoot()
    {
        var bulet = Instantiate(_bullet,gameObject.transform.position,Quaternion.identity);
        bulet.GetComponent<Bullet>().BulletDamage = _towerData.ShottingDamage;
        GetComponent<Animator>().runtimeAnimatorController = _towerData.ShootAnimation;
        StartCoroutine(ShotAnim());
    }
}
