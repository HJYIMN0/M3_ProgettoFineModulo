using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private LifeController _hp;
    [SerializeField] private GameObject _player;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private float _speed = 4f;
    [SerializeField] private int _dmg = 1;


    private Vector2 _direction;
    private Vector2 _pos;
    // Start is called before the first frame update
    void Awake()
    {
        _hp = GetComponent<LifeController>();
        if (_hp == null) Debug.LogWarning("Errore questo nemico non ha HP!");

        _player = GameObject.FindGameObjectWithTag("Player");
        if (_player == null) Debug.LogWarning("Errore! Il Player non è in scena o non ha il tag corretto!");

        _rb = GetComponent<Rigidbody2D>();
        if (_rb == null) Debug.LogWarning("Errore! L'enemy non ha alcun RigidBody!");

        _collider = GetComponent<Collider2D>();
        if (_collider == null) Debug.LogWarning("Attenzione! Manca un collider!");

        
    }

    // Update is called once per frame
    void Update()
    {
        if ( _rb != null )
        {
            if (_player != null)
            {
                _pos = transform.position;
                _direction = (_player.transform.position - transform.position).normalized;
            }
            else 
            {
                Debug.Log("Il giocatore è stato sconfitto!");
            }
        }
          
    }

    private void FixedUpdate()
    {
        if (_direction != Vector2.zero)
        {
            _rb.MovePosition(_pos + _direction * (_speed * Time.fixedDeltaTime));
        }
    }

    public int GetDmg() => _dmg;

}
