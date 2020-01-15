using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public GameObject lifeIndicator;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            if(collision.gameObject.GetComponent<PlayerManager>().lifeAmount > 1)
            { 
                collision.gameObject.GetComponent<PlayerManager>().lifeAmount--;
                lifeIndicator.GetComponent<Animator>().SetTrigger(collision.gameObject.GetComponent<PlayerManager>().lifeAmount.ToString());
                //SceneManager.LoadScene("level");
            }
            else
            {
                collision.gameObject.GetComponent<PlayerManager>().Death();
            }
        }
    }
}
