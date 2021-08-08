using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemy : Enemy
{
    private ShieldEnemyData _shieldEnemyDataParametrs;
    private float _shieldHealth;
    private float _enemyHealth;
    [SerializeField] private GameObject Shield;
    public override void Init(EnemyData _enemySettings)
    {
        base.Init(_enemySettings);
        _shieldEnemyDataParametrs = (ShieldEnemyData)_enemySettings;
        Shield.GetComponent<SpriteRenderer>().sprite = _shieldEnemyDataParametrs.ShieldSprite;
        _shieldHealth = _shieldEnemyDataParametrs.ShieldHealth;
        _enemyHealth = _enemySettings.Health;
    }
    public override void GetDamage(float damage)
    {
        if (_shieldHealth <= 0)
        {
            _enemyHealth -= damage;
            if (_enemyHealth <= 0)
            {
                Death();
            }
        }
        else
        {
            _shieldHealth -= damage;
        }
        if (_shieldHealth <= 0)
        {
            DestroyShield();
        }
    }
    private void DestroyShield()
    {
        var explosion = Instantiate(_shieldEnemyDataParametrs.Explosion);
        explosion.transform.position = gameObject.transform.position;
        Destroy(Shield);
    }
}
