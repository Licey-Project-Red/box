using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovHide : MonoBehaviour
{
    public GameObject mov;
    public void HideMov()
    {
        if (mov != null)
        {
            bool isActive = mov.activeSelf;

            mov.SetActive(!isActive);
        }


    }


}
