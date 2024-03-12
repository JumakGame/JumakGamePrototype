using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanmakeFood_Pro : MonoBehaviour
{
    public TextMeshProUGUI canMakeStrawberryMakCnt;
    public TextMeshProUGUI canMakeAppleMakCnt;
    public TextMeshProUGUI canMakeProkCnt;
    public TextMeshProUGUI canMakeFishCnt;

    public TextMeshProUGUI canMakeAllMakCnt;
    public TextMeshProUGUI canMakeAllMeatCnt;

    public Player player;
    public KitchenMenuInteraction kitchenMenu;


    void Start()
    {
        //GameObject makCntObj = GameObject.Find("canMakeStrawberryMakCnt_txt");
        //canMakeStrawberryMakCnt = makCntObj ? makCntObj.GetComponent<TextMeshProUGUI>() : null;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        kitchenMenu = FindObjectOfType<KitchenMenuInteraction>();
    }


    void Update()
    {
        if (player.isMenuPaperOpen)
        {
            Debug.Log("열림");
            if (kitchenMenu.RightPenel_1)
            {
                canMakeStrawberryMakCnt.text = FoodCnt_Pro.strawberryMak_minBottles.ToString();
                canMakeAppleMakCnt.text = FoodCnt_Pro.appleMak_minBottles.ToString();
                Debug.Log(canMakeStrawberryMakCnt);
            }
            if (kitchenMenu.RightPenel_2)
            {
                canMakeProkCnt.text = FoodCnt_Pro.pork_minFood.ToString();
                canMakeFishCnt.text = FoodCnt_Pro.fish_minFood.ToString();

            }
            UpdateCanMakeAllMakCnt();
            UpdateCanMakeAllMeatCnt();
        }
    }

    void UpdateCanMakeAllMakCnt()
    {
        int canMakeMak_Total = 0;

        if (FoodCnt_Pro.strawberryMak_minBottles >= 1)
        {
            canMakeMak_Total += 1;
        }

        if (FoodCnt_Pro.appleMak_minBottles >= 1)
        {
            canMakeMak_Total += 1;
        }

        if (FoodCnt_Pro.OriginalMakCnt >= 1)
        {
            canMakeMak_Total += 1;
        }

        if (canMakeMak_Total > 0)
        {
            canMakeAllMakCnt.text = canMakeMak_Total.ToString();
        }
        else
        {
            canMakeAllMakCnt.text = "0";
        }
        Debug.Log(canMakeAllMakCnt);
    }

    void UpdateCanMakeAllMeatCnt()
    {
        int canMakeMeat_Total = 0;

        if(FoodCnt_Pro.pork_minFood >=1)
        {
            canMakeMeat_Total += 1;
        }

        if(FoodCnt_Pro.fish_minFood >=1)
        {
            canMakeMeat_Total += 1;
        }

        if(canMakeMeat_Total > 0)
        {
            canMakeAllMeatCnt.text = canMakeMeat_Total.ToString();
        }
        else
        {
            canMakeAllMeatCnt.text = "0";
        }
    }
}
