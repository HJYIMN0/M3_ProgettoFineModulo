using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Bullet : MonoBehaviour
{
    private Vector2 _direction;
    [SerializeField] private int _dmg = 1;
    [SerializeField] private float _maxDuration = 5f;
    [SerializeField] private float _speed = 7f;
    [SerializeField] private Gun _gun;
    [SerializeField] private Rigidbody2D _rb;
    private float _timer;


    private void Awake()
    {
        _gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>();
        _rb = GetComponent<Rigidbody2D>();
        _rb.position = _gun.transform.position;

    }
    void Start()
    {
        _timer = 0f;
        _direction =  _gun.FindNearestEnemy().transform.position - _gun.transform.position;      
        
    }
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _maxDuration)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (_gun != null)
        {
            if (_rb != null)

            {                
                _rb.MovePosition(_rb.position + _direction * (_speed * Time.fixedDeltaTime));
            }
        }

    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null) 
        {
            LifeController target = collision.gameObject.GetComponent<LifeController>();
            if (target != null) 
            {
                target.TakeDamage(_dmg);
            }
            
        } 
        Destroy(gameObject);
    }
}
