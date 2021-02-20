using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasHide : MonoBehaviour
{
    public GameObject gas;
    public void HideGas()
    {
        if (gas != null)
        {
            bool isActive = gas.activeSelf;

            gas.SetActive(!isActive);
        }


    }


}
