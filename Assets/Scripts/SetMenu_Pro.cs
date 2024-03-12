using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class SetMenu_Pro : MonoBehaviour
{
    public GameObject obj;

    public bool isClickOriginalMak;
    public bool isClickStrawberryMak;
    public bool isClickAppleMak;
    public bool isClickPork;
    public bool isClickFish;

    public void OnToggleValueChanged(bool isToggled)
    {
        if(isClickOriginalMak && FoodCnt_Pro.OriginalMakCnt > 0)
        {
            obj.SetActive(isToggled);
        }

        if(isClickStrawberryMak && FoodCnt_Pro.strawberryMak_minBottles > 0)
        {
            obj.SetActive(isToggled);
        }

        if(isClickAppleMak && FoodCnt_Pro.appleMak_minBottles > 0)
        {
            obj.SetActive(isToggled);
        }

        if(isClickPork && FoodCnt_Pro.pork_minFood > 0)
        {
            obj.SetActive(isToggled);
        }

        if(isClickFish && FoodCnt_Pro.fish_minFood > 0)
        {
            obj.SetActive(isToggled);
        }
        else
            Debug.Log("열 수 없음");
    }
}
