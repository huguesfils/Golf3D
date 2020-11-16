using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class ShootScript : MonoBehaviour
{
    public int nbShotsLeft = 5;
    int power = 1000;
    public GameObject balle;
    public Text txtNbShots;
    public Text txtPower;
    public Slider slider;
    public AudioClip swing, put;
    public Image image;
   

    private void start()
    {
        txtNbShots.text = "Shots:" + nbShotsLeft;
    }

    public void setShotPower()
    {
        int val = (int)slider.value;
        txtPower.text = val + "%";
    }

    public void shoot()
    {
        if(nbShotsLeft > 0)
        {
            power = (int)slider.value * 25;
            
            if (slider.interactable == true)
            {
                if (power > 50 * 25)
                {
                    balle.GetComponent<AudioSource>().PlayOneShot(swing);
                }
                else
                {
                    balle.GetComponent<AudioSource>().PlayOneShot(put);
                }
                nbShotsLeft--;
            }
            txtNbShots.text = "Shots:" + nbShotsLeft;
            balle.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * power);
            slider.value = 0;
            StartCoroutine("LockSlider");
        }
    }

    IEnumerator LockSlider()
    {
        yield return new WaitForSeconds(0.2f);
        slider.interactable = false;
        image.enabled = false;

    }

    private void Update()
    {
        if (balle.GetComponent<Rigidbody>().velocity.magnitude < 0.2f && slider.interactable == false)
        {
            slider.interactable = true;
            image.enabled = true;
        }
    }
   
}
