using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static List<GameObject> EnemiesList = new List<GameObject>();
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform firstEnemySpawnPointPosition;
    [SerializeField] Transform secondEnemySpawnPointPosition;
    [SerializeField] Transform thirdEnemySpawnPointPosition;
    [SerializeField] Transform fourthEnemySpawnPointPosition;
    [SerializeField] Transform fifthEnemySpawnPointPosition;
    [SerializeField] float spawnPeriod;
    private float startOfTheEnemiesFiring = 0;
    [SerializeField] float timeBetweenEnemyFiring;
    private Vector2 distanceBetweenEnemies = Vector2.zero;
    private int randomNumber;
    private int randomNumber2;

    void Start()
    {
        SpawnEnemies();
    }

    void Update()
    {
        if (Time.time >= startOfTheEnemiesFiring && EnemiesList[24] != null)
        {
            EnemiesFiringInOrder();
            startOfTheEnemiesFiring = Time.time + timeBetweenEnemyFiring;
        }
    }

    void SpawnEnemies()
    {
        StartCoroutine(WaitLittleBit());
    }

    void EnemiesFiringInOrder()
    {
        randomNumber = Random.Range(0, 5);

        if (EnemiesList[randomNumber] != null)
        {
            EnemiesList[randomNumber].GetComponentInChildren<EnemyShooting>().EnemyShoot();
        }

        else if (EnemiesList[randomNumber] == null)
        {
            if (EnemiesList[randomNumber + 5] != null)
            {
                EnemiesList[randomNumber + 5].GetComponentInChildren<EnemyShooting>().EnemyShoot();
            }

            else if (EnemiesList[randomNumber + 5] == null)
            {
                if (EnemiesList[randomNumber + 10] != null)
                {
                    EnemiesList[randomNumber + 10].GetComponentInChildren<EnemyShooting>().EnemyShoot();
                }

                else if (EnemiesList[randomNumber + 10] == null)
                {
                    if (EnemiesList[randomNumber + 15] != null)
                    {
                        EnemiesList[randomNumber + 15].GetComponentInChildren<EnemyShooting>().EnemyShoot();
                    }

                    else if (EnemiesList[randomNumber + 15] == null)
                    {
                        if (EnemiesList[randomNumber + 20] != null)
                        {
                            EnemiesList[randomNumber + 20].GetComponentInChildren<EnemyShooting>().EnemyShoot();
                        }

                    }

                }

            }

        }
    }

    IEnumerator WaitLittleBit() // Optimize this Function
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, (Vector2)firstEnemySpawnPointPosition.position + distanceBetweenEnemies, Quaternion.identity);
            yield return new WaitForSeconds(spawnPeriod);
            distanceBetweenEnemies += new Vector2(1, 0);
            EnemiesList.Add(enemy);

        }

        distanceBetweenEnemies = Vector2.zero;
        yield return new WaitForSeconds(spawnPeriod);

        for (int i = 0; i < 5; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, (Vector2)secondEnemySpawnPointPosition.position + distanceBetweenEnemies, Quaternion.identity);
            yield return new WaitForSeconds(spawnPeriod);
            distanceBetweenEnemies += new Vector2(1, 0);
            EnemiesList.Add(enemy);
        }

        distanceBetweenEnemies = Vector2.zero;
        yield return new WaitForSeconds(spawnPeriod);

        for (int i = 0; i < 5; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, (Vector2)thirdEnemySpawnPointPosition.position + distanceBetweenEnemies, Quaternion.identity);
            yield return new WaitForSeconds(spawnPeriod);
            distanceBetweenEnemies += new Vector2(1, 0);
            EnemiesList.Add(enemy);
        }

        distanceBetweenEnemies = Vector2.zero;
        yield return new WaitForSeconds(spawnPeriod);

        for (int i = 0; i < 5; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, (Vector2)fourthEnemySpawnPointPosition.position + distanceBetweenEnemies, Quaternion.identity);
            yield return new WaitForSeconds(spawnPeriod);
            distanceBetweenEnemies += new Vector2(1, 0);
            EnemiesList.Add(enemy);
        }

        distanceBetweenEnemies = Vector2.zero;
        yield return new WaitForSeconds(spawnPeriod);

        for (int i = 0; i < 5; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, (Vector2)fifthEnemySpawnPointPosition.position + distanceBetweenEnemies, Quaternion.identity);
            yield return new WaitForSeconds(spawnPeriod);
            distanceBetweenEnemies += new Vector2(1, 0);
            EnemiesList.Add(enemy);
        }
    }
}