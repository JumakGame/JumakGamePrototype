using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recipe_Pro : MonoBehaviour
{
    public GameObject recipePanel;
    public GameObject strawberryUI;
    public GameObject appleUI;
    public GameObject originalMakUI;
    public GameObject porkUI;
    public GameObject stewedFishUI;
    public GameObject soysourceUI;

    Store_Pro2 store;
    Button button;

    void Start()
    {
        store = FindObjectOfType<Store_Pro2>();
    }
    public void OnCLick()
    {
        

    }
   

    public void OpenPanel()
    {
        Debug.Log("열어");
        recipePanel.SetActive(true);
    }

    public void ClosePanel()
    {
        Debug.Log("닫아");

        recipePanel.SetActive(false); // 다시 닫아라

    }

}
