using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private LifeController _lifeController;


    private float h;
    private float v;
    public Vector2 Direction { get; private set; }

    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (_rb == null)
        {
            Debug.LogError("Rigidbody2D non trovato!");
        }

        _lifeController = GetComponent<LifeController>();
        if (_lifeController == null) Debug.LogWarning("Errore! Non ha il LifeController!");

    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        Direction = new Vector2(h, v).normalized;        
    }

    private void FixedUpdate()
    {
        if (_rb != null)
        {
            if (h != 0 || v != 0)
            {
                _rb.MovePosition(_rb.position + Direction * (_speed * Time.fixedDeltaTime));
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_rb != null)
        {
            if (collision != null)
            {
                if (collision.gameObject.CompareTag("Enemy"))
                {
                    Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                    _lifeController.TakeDamage(enemy.GetDmg());
                }
                    
            }
        }
    }
}
