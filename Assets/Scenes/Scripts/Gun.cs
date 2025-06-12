using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    
    [SerializeField] private Bullet _bullet;
    [SerializeField] private GameObject _player;

    private GameObject[] _enemies;
    [SerializeField] private float _maxRange =20f;
    [SerializeField] private float _fireRate = 1f;

    private float _timer;


    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        if (_player == null)
        {
            Debug.LogWarning("Something is not right!");
        }
        _timer = 0;
    }
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _fireRate)
        {
            //Debug.Log(_timer);
            Shoot();
            _timer = 0;
        }
    }

    public GameObject FindNearestEnemy()
    {
        _enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (_enemies == null) return null;
        if (_enemies.Length == 0) return null;
        else
        {
            GameObject nearestEnemy = _enemies[0];
            for (int i = 1; i < _enemies.Length; i++)
            {
                if (Vector2.Distance(nearestEnemy.transform.position, _player.transform.position) > Vector2.Distance(_enemies[i].transform.position, _player.transform.position))
                {
                    nearestEnemy = _enemies[i];
                }
            }
            return nearestEnemy;
        }
    }

    public void Shoot()
    {
        if (_player == null) return;
        GameObject enemy = FindNearestEnemy();
        if (enemy == null)
        {
            Debug.LogWarning("Non ci sono Enemies in scena!");
            return;
        }                
        else
        {
            Debug.Log(enemy.name);
            Debug.Log(Vector2.Distance(enemy.transform.position, _player.transform.position));
            if (Vector2.Distance(enemy.transform.position, _player.transform.position) < _maxRange)
            {                
                Debug.Log(_maxRange);
                if (_timer > _fireRate)
                {
                  Debug.Log("Imma fire!");
                  Instantiate(_bullet);                    
                }
            }
        }
    }
}
