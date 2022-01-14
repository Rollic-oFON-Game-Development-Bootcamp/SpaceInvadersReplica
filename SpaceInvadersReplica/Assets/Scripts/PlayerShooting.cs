using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;

  

    
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            PlayerShootingHandler();
        }
    }

    void PlayerShootingHandler()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }
}
