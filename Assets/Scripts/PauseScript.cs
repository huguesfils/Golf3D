using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseScript : MonoBehaviour
{
    public GameObject menuPause;

    public void ActivatePause()
    {
        menuPause.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void DesactivatePause()
    {
        menuPause.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Reload()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
