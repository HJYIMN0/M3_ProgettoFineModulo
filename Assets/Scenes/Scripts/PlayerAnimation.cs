using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    [SerializeField] private Animator _anim;
    [SerializeField] private PlayerController _player;
    [SerializeField] private LifeController _lifeController;

    

    void Awake()
    {
        _anim = GetComponent<Animator>();
        _player = GetComponent<PlayerController>();
        _lifeController = GetComponent<LifeController>();
        if (_player == null || _anim == null)
        {
            Debug.LogWarning("Something is not quite right!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_lifeController.IsAlive() == true)
        {
            _anim.SetBool("IsAlive", true);
            if (_player.Direction != Vector2.zero)
            {
                _anim.SetBool("IsMoving", true);
                _anim.SetFloat("hDir", _player.Direction.x);
                _anim.SetFloat("vDir", _player.Direction.y);
            }
            else
            {
                _anim.SetBool("IsMoving", false);
            }
        }
        else
        {
            _anim.SetBool("IsAlive", false);
        }


    }
}
