using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyData enemySettings;

    private int _speed;
    private float _health;
    private Rigidbody2D _myRigidBody;
    private RuntimeAnimatorController _backFlip;

    public bool IsBackFlipUp;
    public float Damage;

    public static event OnEnemyDown onEnemyDown;
    public delegate void OnEnemyDown();

    public virtual void Init(EnemyData _enemySettings)
    {
        enemySettings = _enemySettings;
        GetComponent<SpriteRenderer>().sprite = enemySettings.Icon;
        GetComponent<Animator>().runtimeAnimatorController = enemySettings.Animation;

        _speed = enemySettings.Speed;
        _health = enemySettings.Health;
        Damage = enemySettings.Damage;
        _myRigidBody = gameObject.GetComponent<Rigidbody2D>();

        _backFlip = enemySettings.BackFlip;
        IsBackFlipUp = true;

        LoseController.onDefeat += onDefeat;
    }

    private void FixedUpdate()
    {
        Move(_speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Tower>() != null)
        {
            _speed = 0;
            if (collision.gameObject.GetComponent<TowerFist>() != null && collision.gameObject.GetComponent<TowerFist>().IsReloaded)
            {
                GetComponent<Animator>().runtimeAnimatorController = _backFlip;
            }
        }
        else if (collision.gameObject.GetComponent<Tank>() != null || collision.gameObject.tag == "Tank")
        {
            Death();
        }
        else if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            GetDamage(collision.GetComponent<Bullet>().BulletDamage);
        }
        else if (collision.gameObject.GetComponent<LaserTrigger>() != null)
        {
            GetDamage(1000);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<StandingTower>() != null)
        {
            GetDamage(collision.GetComponent<StandingTower>().ContactDamage);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Tower>() != null)
        {
            _speed = enemySettings.Speed;
        }
    }

    private void Move(int Speed)
    {
        if (GetComponent<Animator>().runtimeAnimatorController != _backFlip)
        {
            var pos = gameObject.transform.position;
            pos.x -= (float)Speed / 100;
            _myRigidBody.position = pos;
        }
        else
        {
            var pos = gameObject.transform.position;
            pos.x += (float)1 / 25;

            if (IsBackFlipUp)
            {
                pos.y += (float)1 / 25;
            }
            else
            {
                pos.y -= (float)1 / 25;
            }

            _myRigidBody.position = pos;
        }
    }

    public virtual void GetDamage(float Damage)
    {
        _health -= Damage/1000;
        if (_health <= 0)
        {
            Death();
        }
    }
    static public void EnemyDown()
    {
        onEnemyDown?.Invoke();
    }
    private void onDefeat() 
    {
        _speed = 0;
    }
    public void Death()
    {
        EnemyDown();
        var Explosion = Instantiate(enemySettings.Explosion);
        Explosion.transform.position = gameObject.transform.position;
        Destroy(gameObject);
    }
    public void BackFlipEnd()
    {
        GetComponent<Animator>().runtimeAnimatorController = enemySettings.Animation;
        var pos = gameObject.transform.position;
        pos.y = 0;
        _myRigidBody.position = pos;
    }
}
