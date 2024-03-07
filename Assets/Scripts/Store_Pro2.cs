using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store_Pro2 : MonoBehaviour
{
    public GameObject storeUI;
    public GameObject[] imagePrefabs; // 추가할 이미지의 프리팹
   
    public Transform[] contents; // ScrollView의 Content 배열

    public GameObject selectedImagePrefab;

    private bool isImageAdded = false; // 이미지가 추가되었는지 여부를 나타내는 플래그
    public Recipe_Pro recipePro;

    public void SetSelectedImagePrefab(GameObject selectedPrefab)
    {
        selectedImagePrefab = selectedPrefab;
        isImageAdded = false; // 새로운 이미지를 선택하면 플래그 초기화
    }

    public void AddImage()
    {
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


                    isImageAdded = true; // 이미지 추가 true
                    break;
                }
            }
        }
    }

    public bool ContainsImage(Transform content)
    {
        return content.childCount > 0; // content에 이미지프리팹 있는지 확인
    }

    public void OnClickButton()
    {

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
