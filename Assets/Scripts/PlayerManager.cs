using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{

    public GameObject coinTextField;
    public GameObject lifeIndicator;
    public ParticleSystem coinParticle;
    public ParticleSystem heartParticle;
    public Vector2 coinCillectRange;
    public Vector3 coinCillectOffset;
    int coinAmount = 0;
    public int lifeAmount = 3;
    public ParticleSystem deathParticles;
    public GameObject HUD;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision)
            if (collision.gameObject.CompareTag("Coin") && gameObject.CompareTag("Player"))
            {
                coinParticle.gameObject.transform.position = collision.gameObject.transform.position;
                Instantiate(coinParticle);
                coinParticle.Emit(500);
                coinAmount++;
                coinTextField.GetComponent<TMPro.TextMeshProUGUI>().SetText("x" + coinAmount.ToString());
                Destroy(collision.gameObject);
            }
        if (collision.gameObject.CompareTag("Heart") && lifeAmount < 3)
        {
            heartParticle.gameObject.transform.position = collision.gameObject.transform.position;
            Instantiate(heartParticle);
            heartParticle.Emit(1000);
            lifeAmount++;
            Destroy(collision.gameObject);
            lifeIndicator.GetComponent<Animator>().SetTrigger(lifeAmount.ToString());
        }
        if (collision.gameObject.CompareTag("Bulb"))
        {
            gameObject.GetComponent<CharacterController2D>().currEnergy = gameObject.GetComponent<CharacterController2D>().energy;
            coinParticle.gameObject.transform.position = collision.gameObject.transform.position;
            Instantiate(coinParticle);
            coinParticle.Emit(2000);
            Destroy(collision.gameObject);
        }
    }

    public void Death()
    {
        deathParticles.gameObject.transform.position = gameObject.transform.position;
        Instantiate(deathParticles);
        heartParticle.Emit(2000);
        HUD.SetActive(false);
        StartCoroutine(CourDeath(1.0f));
    }

    IEnumerator CourDeath(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("level");
    }

}

