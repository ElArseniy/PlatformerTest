using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    Transform _targetPosition;//позиция объекта, к которому будет двигаться камера
    Vector2 _velocity = Vector2.zero;//пустой компонент скорости для smooth.Dump

    void Start()
    {
        _targetPosition = GameObject.FindGameObjectWithTag("CameraTarget").transform;//берем позицию объекта по тэгу 
    }

    private void FixedUpdate()//именно в фикс апдейте, чтобы не было ругани с физикой движения
    {
        transform.position = Vector2.SmoothDamp(transform.position, _targetPosition.position, ref _velocity, 0.1f);//двигаем камеру от ее позиции к позиции объекта за время 0,1мсек
    }
}
