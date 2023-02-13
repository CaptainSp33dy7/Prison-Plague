using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCanvas : MonoBehaviour
{
    public GameObject gameOverMenu;

    private void OnEnable()
    {
        Player.OnPlayerDeath += EnableGameOverMenu;
    }

    private void OnDisable()
    {
        Player.OnPlayerDeath -= EnableGameOverMenu;
    }

    /// <summary>
    /// Metoda, ktera pri zavolani aktivuje Game Over Menu
    /// </summary>
    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }
}
