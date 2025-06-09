using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private Gun _gunPf;
    [SerializeField] private GameObject _SpawnLocation;
    


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (_SpawnLocation != null)
                {
                    Gun newGun = Instantiate(_gunPf, _SpawnLocation.transform.position, _SpawnLocation.transform.rotation);
                    newGun.transform.SetParent(collision.transform);
                    Destroy(gameObject);
                }
                else
                {
                    Debug.LogWarning("Errore! Manca la posizione di Spawn dell'arma!");
                }

            }
        }
    }
}
