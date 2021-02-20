using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumHide : MonoBehaviour
{
    public GameObject hum;
    public void HideHum()
    {
        if (hum != null)
        {
            bool isActive = hum.activeSelf;

            hum.SetActive(!isActive);
        }


    }


}
