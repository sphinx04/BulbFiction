using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    public GameObject playText;
    public GameObject settingsText;
    public GameObject quitText;
    public GameObject playParticles;
    public GameObject settingsParticles;
    public GameObject quitParticles;
    public GameObject MenuLights;

    public void OnButtonPush()
    {
        StartCoroutine(Wait(2f));
    }

    IEnumerator Wait(float seconds)
    {
        MenuLights.GetComponent<Animator>().enabled = true;
        playText.SetActive(false);
        settingsText.SetActive(false);
        quitText.SetActive(false);
        playParticles.SetActive(true);
        settingsParticles.SetActive(true);
        quitParticles.SetActive(true);
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("level1");
    }
}
