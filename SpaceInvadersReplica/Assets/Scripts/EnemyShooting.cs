using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject enemyBulletPrefab;
    public void EnemyShoot()
    {
        Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);
    }
  
}