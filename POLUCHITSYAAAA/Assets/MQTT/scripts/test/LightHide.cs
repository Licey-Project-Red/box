using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHide : MonoBehaviour
{
    public GameObject light;
    public void HideLight()
    {
        if (light != null)
        {
            bool isActive = light.activeSelf;

            light.SetActive(!isActive);
        }


    }


}
