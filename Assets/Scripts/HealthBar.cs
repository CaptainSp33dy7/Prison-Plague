using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    /// <summary>
    /// Metoda, ktera nastavi maximalni hodnotu health baru a nastavi ho na tuto hodnotu.
    /// </summary>
    /// <param name="health">Pocet zivotu hrace</param>
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    /// <summary>
    /// Metoda, ktera nastavuje hodnotu health baru podle poctu zivotu hrace.
    /// </summary>
    /// <param name="health">Pocet zivotu hrace</param>
    public void SetHealth(int health)
    {
        slider.value = health;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
