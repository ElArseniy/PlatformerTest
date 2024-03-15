using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicMove : MonoBehaviour
{
    Rigidbody2D _playerRb;

    float _speedLimit = 15f;
    float _move;
    float _speed = 100f;

    
    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        
        _move = Input.GetAxis("Horizontal");

        CheckSpeedLimits();

    }
    void CheckSpeedLimits()
    {
        if (_playerRb.velocity.x > _speedLimit && _move > 0)
        {
            _move = 0;
        }
        if (_playerRb.velocity.x < -_speedLimit && _move < 0)
        {
            _move = 0;
        }
    }
    private void FixedUpdate()
    {
        CheckSpeedLimits();
        _playerRb.AddForce(new Vector2(_move * _speed, 0));
        
    }
}
