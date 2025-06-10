using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _playingSound;
    [SerializeField] private LifeController _lifeController;

    [SerializeField] private AudioClip _deathSound;

    // Start is called before the first frame update
    void Start()
    {
        _lifeController = GetComponent<LifeController>();
        if (_lifeController == null) Debug.LogError("Something is very wrong here!");  
        
        if (_deathSound == null) Debug.LogError("Attenzione! Manca un audioclip!");

        if (_playingSound == null) Debug.Log("Attenzione! Manca l'audioSource!");
    }

    // Update is called once per frame
    void Update()
    {
        if (_lifeController.IsAlive() == false)
        {
            _playingSound.clip = _deathSound;
            _playingSound.Play();
            _playingSound.loop = false;            
        }
        
    }
}
