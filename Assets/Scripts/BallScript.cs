using UnityEngine;
using UnityEngine.SceneManagement;

public class BallScript : MonoBehaviour
{
    public AudioClip hole;
    public GameObject sphere;
    public GameObject panelFin;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ocean")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (other.gameObject.tag == "Fin")
        {
            sphere.GetComponent<AudioSource>().PlayOneShot(hole);
            panelFin.SetActive(true);
            int niveauActuel = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("DernierNiveau", niveauActuel);
        }
    }
}
