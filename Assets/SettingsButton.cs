using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public GameObject mainList;
    public GameObject settingList;
    // Start is called before the first frame update
    public void OnButtonPush()
    {
        settingList.SetActive(true);
        mainList.SetActive(false);
    }
}
