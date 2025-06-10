using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRestart : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private LifeController _lc;
    [SerializeField] private float _timer = 10f;
    
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _lc = _player.GetComponent<LifeController>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (_lc.IsAlive() == false)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                SceneManager.LoadScene("Level1");
                Debug.Log("Sei morto!");
            }
        }
        
    }
}
