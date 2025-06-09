using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{

    [SerializeField] private int _hp = 10;
    [SerializeField] PlayerController _player;

    private bool _isAlive = true;
    
    void Awake()
    {
        _player = GetComponent<PlayerController>();
        
    }

    
    void Update()
    {
        if (_hp <= 0) 
        {
            Destroy(gameObject, 1f);
            _isAlive = false;
            _player.enabled = false;
        }  
    }

    public void TakeDamage(int dmg)
    {
        _hp -= dmg;        
    }

    public int GetHP() => _hp;
    public void SetHp(int hp)
    {
        if (hp > 0)
        {
            _hp = hp;
        }
    }

    public bool IsAlive() => _isAlive;

}
