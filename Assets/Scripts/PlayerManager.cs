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
    }

    public void Death()
    {
        SceneManager.LoadScene("level");
    }

}

