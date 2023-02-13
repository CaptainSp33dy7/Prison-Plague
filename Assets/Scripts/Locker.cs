using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour
{
    public GameObject lockerOpen;

    /// <summary>
    /// Metoda, ktera zkouma kolizi s jinym objektem, pokud je to hrac, nastavi mu pocet naboju na maximum a spusti animaci otevreni skrinky.
    /// </summary>
    /// <param name="hitInfo">Informace o objektu, se kterym nastala kolize</param>
    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            player.currentAmmo = player.maxAmmo;
            Instantiate(lockerOpen, transform.position, Quaternion.identity);
        }
    }
}
