using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Introduction : MonoBehaviour
{
    /// <summary>
    /// Metoda, ktera nacita dalsi scenu. (Volame ji pouze ze sceny Introduction, takze nacita scenu Game)
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
