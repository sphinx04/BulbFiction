using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public GameObject mainList;
    public GameObject settingList;

    public void OnButtonPush()
    {
        settingList.SetActive(false);
        mainList.SetActive(true);
    }
}
