using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    
    void Start()
    {
        store = FindObjectOfType<Store_Pro2>(); // 비활성화 오브젝트는 찾지 못함
    }
    public void OnClickButton_1()
    {
        store.saveRecipe[0].SetActive(true); // UI 리스트 0 번째 접근 후 UI 활성화
        SetfalseUI(0); // 0을 제외한 나머지 UI 비활성화
    }
    public void OnClickButton_2()
    {
        store.saveRecipe[1].SetActive(true);
        SetfalseUI(1);

    }
    public void OnClickButton_3()
    {
        store.saveRecipe[2].SetActive(true);
        SetfalseUI(2);
    }
    public void OnClickButton_4()
    {
        store.saveRecipe[3].SetActive(true);
        SetfalseUI(3);
    }
    public void OnClickButton_5()
    {
        store.saveRecipe[4].SetActive(true);
        SetfalseUI(4);
    }
    public void OnClickButton_6()
    {
        store.saveRecipe[5].SetActive(true);
        SetfalseUI(5);
    }
    public void SetfalseUI(int num)
    {
        for (int i = 0; i < store.saveRecipe.Count; ++i)
        {
            if (i != num)
            {
                store.saveRecipe[i].SetActive(false);
            }
        }

    }
    public void OpenPanel()
    {       
        recipePanel.SetActive(true);
    }
    public void ClosePanel()
    {       
        recipePanel.SetActive(false);
    }
}
