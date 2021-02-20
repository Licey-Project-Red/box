using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempHide : MonoBehaviour
{
    public GameObject temp;
    public void HideTemp()
    {
        if (temp != null)
        {
            bool isActive = temp.activeSelf;

           temp.SetActive(!isActive);
        }    


    }


}
