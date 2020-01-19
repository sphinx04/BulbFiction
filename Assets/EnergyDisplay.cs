using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDisplay : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float energyScale = player.GetComponent<CharacterController2D>().currEnergy / player.GetComponent<CharacterController2D>().energy;
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(energyScale,1,1);
        if(energyScale > 0.5f)
        {
            //gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(1 - (energyScale - 0.5f) * 2, 1, 0);
            gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(2 - 2 * energyScale, 1, 0);
        }
        else if (energyScale <= 0.5f)
        {

            gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(1, energyScale * 2, 0);
        }
    }
}
