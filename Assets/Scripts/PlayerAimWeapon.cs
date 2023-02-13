using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class PlayerAimWeapon : MonoBehaviour
{

    private Transform aimTransform;
    private Transform aimGunEndPointTransform;

    public GameObject bulletPrefab;
    public Player player;

    /// <summary>
    /// Metoda, ktera si ziskava polohu herniho objektu "Aim" a "GunEndPointPosition".
    /// </summary>
    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        aimGunEndPointTransform = aimTransform.Find("GunEndPointPosition");
    }

    /// <summary>
    /// Metoda, ktera se vola kazdy frame a v tomto pripade vola metody HandleAiming() a HandleShooting().
    /// </summary>
    private void Update()
    {
        HandleAiming();
        HandleShooting();
    }

    /// <summary>
    /// Metoda, ktera prepocitava polohu kurzoru z pixelovych souradnic do souradnic herniho sveta, nasledne pocita vektor ke kurzoru a jeho uhel s kladni osou x. 
    /// Kdyz je kurzor na leve polovine obrazovky obraci texturu zbrane, aby nebyla hlavou dolu.
    /// </summary>
    private void HandleAiming()
    {
        Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        Vector3 aimlocalScale = Vector3.one;
        if (angle > 90 || angle < -90)
        {
            aimlocalScale.y = -1f;
        }
        else
        {
            aimlocalScale.y = +1f;
        }
        aimTransform.localScale = aimlocalScale;

    }

    /// <summary>
    /// Metoda, ktera zkouma zda-li hrac nevystrelil (zmacknuti tlacitka prirazeneho strileni), pokud ano, vlozi do sceny herni objekt kulky 
    /// a odecte jeden naboj z poctu naboju hrace.
    /// </summary>
    private void HandleShooting()
    {
        if (Input.GetButtonDown("Fire1") && player.currentAmmo > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, aimGunEndPointTransform.position, aimGunEndPointTransform.rotation);
            player.currentAmmo -= 1;
        }
    }
}
