using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    /// <summary>
    /// Metoda, ktera nacita tu samou scenu znova. (Volame ji pouze ze sceny Game, takze vzdy nacita scenu Game)
    /// </summary>
    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Metoda, ktera nacita scenu hlavniho menu.
    /// </summary>
    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
}
