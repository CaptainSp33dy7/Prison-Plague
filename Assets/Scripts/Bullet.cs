using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;
    public Rigidbody2D rb;

    /// <summary>
    /// Pred vyrenderovanim prvniho frameu se nastavi hybnost kulky, aby se po vlozeni do sceny hybala smerem letu.
    /// </summary>
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    /// <summary>
    /// Metoda, ktera po kolizi kulky s nejakym jinym predmetem prozkouma, co to je za predmet a pokud je to nepritel, zavola na nem metodu TakeDamage().
    /// </summary>
    /// <param name="hitInfo">Informace o objektu, se kterym nastala kolize</param>
    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Debug.Log(hitInfo);
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        EnemyPrisoner enemyPrisoner = hitInfo.GetComponent<EnemyPrisoner>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }else if(enemyPrisoner != null)
        {
            enemyPrisoner.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

}
