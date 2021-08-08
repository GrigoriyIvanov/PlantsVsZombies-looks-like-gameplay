using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseController : MonoBehaviour
{
    public static event OnDefeat onDefeat;
    public delegate void OnDefeat();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            onDefeat?.Invoke();
        }
    }
}
