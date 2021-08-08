using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Вызывается в конце анимации взрыва
    public void DestroyParent()
    {
        Destroy(gameObject);
    }
}
