using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float enemyBulletSpeed;
    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(SelfDestruct());

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.down * enemyBulletSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
            Debug.Log("Game Over!");
        }
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

}
