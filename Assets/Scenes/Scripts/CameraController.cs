using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject _player;    

  
    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        if (_player == null) Debug.Log("Errore! Neesun Player in scena!");     
        
    }


    void LateUpdate()
    {
        if (_player != null)
        {
            transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, -10);
        }
    }
}
