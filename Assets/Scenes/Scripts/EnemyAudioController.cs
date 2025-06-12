using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudioController : MonoBehaviour
{
    [SerializeField] private AudioClip _atk01;
    [SerializeField] private AudioClip _atk02;
    [SerializeField] private AudioClip _atk03;
    [SerializeField] private AudioClip _atk04;

    [SerializeField] private AudioSource _playingSound;
    [SerializeField] private Enemy _enemy;

    private AudioClip[] _audioList;


    void Start()
    {
        _playingSound = GetComponent<AudioSource>();
        if (_playingSound == null) Debug.LogError("Qui manca qualcosa!");

        _enemy = GetComponent<Enemy>();
        if (_enemy == null) Debug.LogError("Qui manca qualcosa!");

        _audioList = new AudioClip[4];
        _audioList[0] = _atk01;
        _audioList[1] = _atk02;
        _audioList[2] = _atk03;
        _audioList[3] = _atk04;        
    }

    // Update is called once per frame
    void Update()
    {
         int _randomNumber = Random.Range(0, 4);

        if (_enemy.IsAttacking() == true || _enemy.GetComponent<LifeController>().GetHP() <= 0)
        {
            _playingSound.clip = _audioList[_randomNumber];
            _playingSound.Play();
            _playingSound.loop = false;

        }

    }
}

