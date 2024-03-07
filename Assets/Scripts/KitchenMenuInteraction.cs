using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KitchenMenuInteraction : MonoBehaviour
{
    public GameObject RightPenel_1;
    public GameObject RightPenel_2;
    public GameObject MenuPaper;
    //public Player player;

    public void ClickMenuDrink_1()
    {
        RightPenel_1.SetActive(true);
        RightPenel_2.SetActive(false);
    }
    public void ClickMenuDrink_2()
    {
        RightPenel_1.SetActive(false);
        RightPenel_2.SetActive(true);
    }
    public void ExitMenuPaper()
    {
        MenuPaper.SetActive(false);
        RightPenel_1.SetActive(false);
        RightPenel_2.SetActive(false);
        Player player = FindObjectOfType<Player>();
        player.isMenuPaperOpen = false;
    }
}
