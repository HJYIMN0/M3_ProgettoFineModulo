using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] private Animator _enemyAnimation;
    [SerializeField] private Enemy _enemy;
    void Start()
    {
        _enemyAnimation = GetComponent<Animator>();
        if (_enemyAnimation == null) Debug.LogWarning("Manca qualcosa qui!");

        _enemy = GetComponent<Enemy>();
        if (_enemy == null) Debug.LogWarning("Manca qualcosa qui!");
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemy.IsAttacking() == true)
        {
            _enemyAnimation.SetBool("IsAttacking", true);
        }
        else
        {
            _enemyAnimation.SetBool("IsAttacking", false);
        }
        
    }
}
