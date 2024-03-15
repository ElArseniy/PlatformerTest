using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour
{

    
    Rigidbody2D _playerRb2D;//игрок
    float _speed =13f;//скорость
    
    private void Start()
    {
        _playerRb2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()//именно фикс апдейт, чтобы с физикой не ругаться
    {
        transform.Translate(new Vector2(Input.GetAxis("Horizontal") * _speed * Time.fixedDeltaTime, 0));
    }
    
}
