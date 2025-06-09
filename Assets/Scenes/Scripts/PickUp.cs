using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
        [SerializeField] private Gun _gunPf;      


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Gun newGun = Instantiate(_gunPf, collision.transform.position, collision.transform.rotation);
                newGun.transform.SetParent(collision.transform);
                Destroy(gameObject);

            }
        }
    }
}
