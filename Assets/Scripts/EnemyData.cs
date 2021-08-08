using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy/BasicEnemy")]
public class EnemyData : ScriptableObject
{
    public int Speed;
    public float Health;
    public Sprite Icon;
    public RuntimeAnimatorController Animation;
    public float Damage;
    public GameObject Explosion;
    public RuntimeAnimatorController BackFlip;
}