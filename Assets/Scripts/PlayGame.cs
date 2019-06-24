using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    public GameObject playText;
    public GameObject settingsText;
    public GameObject quitText;
    public GameObject playParticles;
    public GameObject settingsParticles;
    public GameObject quitParticles;

    public void StartGame()
    {
        playText.SetActive(false);
        settingsText.SetActive(false);
        quitText.SetActive(false);
        playParticles.SetActive(true);
        settingsParticles.SetActive(true);
        quitParticles.SetActive(true);
    }

}
