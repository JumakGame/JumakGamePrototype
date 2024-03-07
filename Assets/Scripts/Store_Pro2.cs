using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Store_Pro2 : MonoBehaviour
{
    public GameObject storeUI;
    public GameObject[] imagePrefabs; // 추가할 이미지의 프리팹

    public Transform[] contents; // ScrollView의 Content 배열

    public GameObject selectedImagePrefab;
    public GameObject selectedUIPrefab;

    private bool isImageAdded = false; // 이미지가 추가되었는지 여부를 나타내는 플래그
    private bool isUIAdded = false;
    public Recipe_Pro recipePro;

    public List<GameObject> saveRecipe;

    public void SetSelectedImagePrefab(GameObject selectedPrefab)
    {
        selectedImagePrefab = selectedPrefab;
        isImageAdded = false; // 새로운 이미지를 선택하면 플래그 초기화
    }
    public void SetSelectedUI(GameObject selectedUI) // 선택한 UI 저장
    {
        selectedUIPrefab = selectedUI;
        SaveRecipeImage(); // 선택한 UI 리스트에 추가
        //isUIAdded = false; // 새로운 UI를 선택하면 플래그 초기화 // 추후 필요가능성 O
    }

    public void AddImage()
    {
        // 24.03.08 수정 필요 : 클릭한 이미지 이미 생성되어 있으면 카운트만 증가하기
        //          :  만약 이미 선택한 이미지를 재선택 할 경우 이미 선택한 UI 는 선택되지 않도록 하기
        if (selectedImagePrefab != null && !isImageAdded)
        {
            for (int i = 0; i < contents.Length; i++)
            {
                if (!ContainsImage(contents[i]))
                {

                    // 클릭한 이미지 프리팹을 사용하여 이미지 생성
                    GameObject newImage = Instantiate(selectedImagePrefab, contents[i]);

                    // Content의 크기 조정
                    RectTransform contentRectTransform = contents[i].GetComponent<RectTransform>();
                    contentRectTransform.sizeDelta += new Vector2(0, newImage.GetComponent<RectTransform>().sizeDelta.y);
                    isUIAdded = true;

                    //isImageAdded = true; // 이미지 추가 true
                    break;
                }
            }
        }
    }
    public void SaveRecipeImage()
    {
        if (saveRecipe.Count < 6) // 5개까지만 추가
        {
            saveRecipe.Add(selectedUIPrefab);
        }


    }

    public bool ContainsImage(Transform content)
    {
        return content.childCount > 0; // content에 이미지프리팹 있는지 확인
    }



    public void OpenStoreUI()
    {
        storeUI.SetActive(true);
    }

    public void CloseStoreUI()
    {
        storeUI.SetActive(false);
    }

}
