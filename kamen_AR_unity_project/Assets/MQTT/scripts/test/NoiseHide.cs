using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseHide : MonoBehaviour
{
    public GameObject noise;
    public void HideNoise()
    {
        if (noise != null)
        {
            bool isActive = noise.activeSelf;

            noise.SetActive(!isActive);
        }


    }


}
