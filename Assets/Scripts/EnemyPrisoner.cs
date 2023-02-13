using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrisoner : MonoBehaviour
{
    public int health = 10;
    public int damage = 20;

    public GameObject deathEffect;
    public GameObject enemyHit;

    public Player player;

    /// <summary>
    /// Metoda, ktera snizuje postave nepritele zivoty, spousti animaci zasahu a zaroven kontroluje zda-li neni mrtev, pokud ano, vola metodu Die().
    /// </summary>
    /// <param name="damage">Velikost poskozeni, ktere se ubere ze zivotu</param>
    public void TakeDamage(int damage)
    {
        health -= damage;

        Instantiate(enemyHit, transform.position, Quaternion.identity);

        if (health <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Metoda, ktera zkouma kolizi nepritele s jinym predmetem, pokud je to hrac, zavola na nem metodu TakeDamage(), funguje stejne jako stejnojmenna metoda ve skripte Bullet.cs
    /// </summary>
    /// <param name="hitInfo">Informace o predmetu, se kterym nastala kolize</param>
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
    }

    /// <summary>
    /// Metoda, ktera slouzi ke spusteni animace smrti, zniceni herniho objektu nepritele a zavolani metody AddKill()
    /// </summary>
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        AddKill();
    }

    /// <summary>
    /// Metoda, ktera slouzi ke pricteni killu na hracuv killCounter
    /// </summary>
    void AddKill()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        player.killCount += 1;
    }
}
