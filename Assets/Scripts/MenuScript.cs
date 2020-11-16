using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
   public void LoadSelectedLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
