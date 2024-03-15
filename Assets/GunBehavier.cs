using UnityEngine;

public class GunBehavier : MonoBehaviour
{
    bool _checked = false;
    
   
    Rigidbody2D _playerRb;//игрок
    float _gunPower =1350;//сила отдачи пушки
    Camera _camera;//главная камера
    float _timer;//таймер перезарядки
    public SpriteRenderer _checkAmmunition;//спрайт, отображающий готовность стрелять(треугольник)

    Vector2 _right = new Vector2(1, 0);//вектор глобально правый
    Ray2D _mouseRay;//луч до мыши(оставил луч, а не вектор на всякий, если будем делать реальный выстрелы или тп)
    private void Start()
    {
        _checkAmmunition.color = Color.green;
        _timer = 2;
        _camera = Camera.main;
        _playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }
    
    private float getAngle(Vector2 _vec1,Vector2 _mouseVector)//возвращает угол между двумя векторами(градусы)
    {
        float _angle = Mathf.Acos((_vec1.x * _mouseVector.x + _mouseVector.y * _vec1.y) / _vec1.magnitude * _mouseVector.magnitude) *Mathf.Rad2Deg;
        if (_mouseVector.y < 0)//т.к. угол возвращается только положительный, сами контролируем когда он отрицательный
            return -_angle;
        return _angle;
    }

    void isReloaded()
    {
        if (Input.GetMouseButtonDown(0) && _timer > 0.5f)
        {
            _checked = true;
        }

    }

    void RotateGun()
    {
        _mouseRay.origin = transform.position;
        _mouseRay.direction = _camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.rotation = Quaternion.Euler(0, 0, getAngle(_right, _mouseRay.direction));
    }

    void Update()
    {
        RotateGun();
        isReloaded();
    }
    private void FixedUpdate()
    {
        
        if (_checked ==true)
        {
            _checked = false;
            _timer = 0;
            _checkAmmunition.color = Color.red;
            _playerRb.AddForce(-_mouseRay.direction.normalized * _gunPower);
        }
        _timer += Time.fixedDeltaTime;
        if (_timer > 0.5f)
            _checkAmmunition.color = Color.green;
        
    }
    
}
