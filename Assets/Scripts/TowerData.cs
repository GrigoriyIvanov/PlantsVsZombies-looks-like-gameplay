using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[CreateAssetMenu(fileName = "TowerData", menuName = "Tower/Tower")]
public class TowerData : ScriptableObject
{
    public int Price;
    public float Health;
    public Sprite Icon;
    public RuntimeAnimatorController Animation;
    public RuntimeAnimatorController DeathAnimation;
}