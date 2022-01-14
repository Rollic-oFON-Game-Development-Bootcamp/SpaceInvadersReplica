using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float startingMoveTime = 0f;
    [SerializeField] float timeBetweenMoves = 1f;
    private float enemy25XPos;
    private float enemy1XPos;
    private bool isGoingRight = false;
    private bool isGoingDown = false;
    private bool isGoingLeft = false;
    private float xRightLimitValueForEnemies;
    void Start()
    {

        isGoingRight = true;
        xRightLimitValueForEnemies = 2.5f;
        // Wait some time before starting
    }
    void Update()
    {
        EnemyXPosFinder();
        EnemyMoveHandler(1f, -1f);

        void EnemyXPosFinder()
        {
            if (GameManager.EnemiesList[24] != null)                                                                  // Why getting error
            {
                enemy25XPos = GameManager.EnemiesList[24].transform.position.x;
            }
        }
        void EnemyMoveHandler(float directionRight, float directionDown)                                              // Optimize and fix last frame
        {
            if (GameManager.EnemiesList[24] != null && isGoingRight == true)
            {
                if (Time.time >= startingMoveTime && enemy25XPos < xRightLimitValueForEnemies)
                {
                    transform.position = (Vector2)transform.position + new Vector2(directionRight * 0.1f, 0f);
                    startingMoveTime = Time.time + timeBetweenMoves;
                    if (enemy25XPos > 2.49f && isGoingDown == false)
                    {
                        isGoingRight = false;
                        transform.position = (Vector2)transform.position + new Vector2(0, directionDown * 0.25f);
                        isGoingDown = true;
                        isGoingLeft = true;
                        timeBetweenMoves -= 0.1f;
                    }
                }
            }

            else if (GameManager.EnemiesList[24] != null && isGoingLeft == true)
            {
                if (Time.time >= startingMoveTime && enemy25XPos > xRightLimitValueForEnemies - 1f)
                {
                    transform.position = (Vector2)transform.position + new Vector2(directionRight * -1 * 0.1f, 0f);
                    startingMoveTime = Time.time + timeBetweenMoves;
                }
                if (enemy25XPos < 1.51f && isGoingDown == true)
                {
                    transform.position = (Vector2)transform.position + new Vector2(0, directionDown * 0.25f);
                    isGoingDown = false;
                    isGoingRight = true;
                    timeBetweenMoves -= 0.1f;
                }
            }
        }

    }
}