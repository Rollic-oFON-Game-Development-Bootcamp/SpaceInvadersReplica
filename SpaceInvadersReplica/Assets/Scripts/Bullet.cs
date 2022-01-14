using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float bulletSpeed;

    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.up * bulletSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy") && col.gameObject != GameManager.EnemiesList[24])
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }

        else if (col.gameObject == GameManager.EnemiesList[24])
        {
            col.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
