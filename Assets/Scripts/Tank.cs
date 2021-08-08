using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private int _speed;
    private void Start()
    {
        _speed = 0;
    }
    private void FixedUpdate()
    {
        Move(_speed);
    }
    private void Move(int speed)
    {
        var pos = gameObject.transform.position;
        pos.x += (float)speed / 100;
        gameObject.transform.position = pos;
        if (gameObject.transform.position.x > 12)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            _speed = 3;
        }
    }
}
