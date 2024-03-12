using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffInfo : MonoBehaviour
{
    public GameObject staffInfoUI;

    public void StaffInfoUISet()
    {
        staffInfoUI.SetActive(true);

    }
    public void StaffInfoUIUISet()
    {
        staffInfoUI.SetActive(false);

    }
}
