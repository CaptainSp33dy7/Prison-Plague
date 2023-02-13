using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public static event Action OnPlayerDeath;

    public int maxHealth = 30;
    public int currentHealth;
    public int maxAmmo = 15;
    public int currentAmmo;
    public int killCount;

    public HealthBar healthBar;

    public GameObject deathEffect;
    public GameObject playerHit;
    public TextMeshProUGUI ammoDisplay;
    public TextMeshProUGUI killDisplay;
    public Stopwatch stopWatch;

    /// <summary>
    /// Metoda, ktera se spusti jeste pred vyrenderovanim prvniho frameu, v tomto pripade nastavuje hracuv pocet zivotu na maximalni pocet zivotu,
    /// nastavuje pocet naboju na maximalni pocet naboju a resetuje killcounter na nulu.
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        currentAmmo = maxAmmo;
        killCount = 0;
    }

    /// <summary>
    /// Metoda, ktera se vola kazdy frame a v tomto pripade prepisuje text poctu naboju a poctu killu v UI.
    /// </summary>
    void Update()
    {
        ammoDisplay.text = "Ammo: " + currentAmmo.ToString() + "/" + maxAmmo.ToString();
        killDisplay.text = "Kills: " + killCount.ToString();
    }

    /// <summary>
    /// Metoda, ktera ubira hraci pocet zivotu podle velikosti poskozeni, ktere dostane, upravuje health bar dle poctu zivotu, spousti animaci zasahu
    /// a kontroluje zda-li uz neni mrtev, pokud ano vola metodu Die().
    /// </summary>
    /// <param name="damage">Velikost poskozeni</param>
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        Instantiate(playerHit, transform.position, Quaternion.identity);

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Metoda, ktera spousti animaci smrti hrace, zastavuje stopky, porovnava High score s ulozenym nejvetsim High score a aktivuje Game Over Menu.
    /// </summary>
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        stopWatch.end = true;

        if (stopWatch.t > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", stopWatch.t);
            stopWatch.CalcHighScore();
            stopWatch.highScore.text = "High score: " + stopWatch.hscore;
        }

        OnPlayerDeath?.Invoke();
        Destroy(gameObject);
    }
}
