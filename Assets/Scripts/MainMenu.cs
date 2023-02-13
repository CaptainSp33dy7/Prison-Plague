using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Metoda, ktera nacita dalsi scenu. (Volame ji pouze ze sceny Main Menu, takze nacita scenu Introduction)
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Metoda, ktera zavre aplikaci.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
