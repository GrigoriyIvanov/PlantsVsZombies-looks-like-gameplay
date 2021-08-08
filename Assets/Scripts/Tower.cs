using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    private float _health;
    private TowerData _towerParametrs;
    private RuntimeAnimatorController _deathAnimation;

    public virtual void Init(TowerData towerSettings)
    {
        _towerParametrs = towerSettings;
        GetComponent<SpriteRenderer>().sprite = _towerParametrs.Icon;
        GetComponent<Animator>().runtimeAnimatorController = _towerParametrs.Animation;
        _deathAnimation = _towerParametrs.DeathAnimation;
        _health = _towerParametrs.Health;
    }

    public virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            GetDamage(collision.gameObject.GetComponent<Enemy>().Damage);
        }
    }

    public void GetDamage(float damage)
    {
        _health -= (damage / 1000);
        if (_health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        GetComponent<Animator>().runtimeAnimatorController = _deathAnimation;
        StartCoroutine(WaitForTimeToDeath());
        gameObject.GetComponentInParent<TowerSpawnController>().IsTowerHere = false;
    }
    IEnumerator WaitForTimeToDeath()
    {
        yield return new WaitForSeconds(_deathAnimation.animationClips[0].length - _deathAnimation.animationClips[0].length / 10);// тут странно пушо появлялся лишний кадр
        Destroy(gameObject);
    }
}