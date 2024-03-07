using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class KitchenMousePoint : MonoBehaviour
{

    public bool isChk;
    public TextMeshProUGUI loveChkText;
    
    public GameObject loveChkImg;
    private void Update()
    {
        // 마우스의 화면 좌표를 가져옴
        Vector3 mousePos = Input.mousePosition;
        // 화면 좌표를 월드 좌표로 변환
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        // 텍스트 UI의 RectTransform을 가져옴
        RectTransform textRect = loveChkText.GetComponent<RectTransform>();

        // 텍스트 UI 영역 안에 마우스가 있는지 확인
        if (RectTransformUtility.RectangleContainsScreenPoint(textRect, mousePos))
        {
            // 마우스가 텍스트 위에 있을 때 UI 요소를 활성화
            loveChkImg.SetActive(true);
            // UI 요소의 위치를 마우스 위치로 이동
            //loveChkImg.transform.position = worldPos;
        }
        else
        {
            // 마우스가 텍스트 위에 없을 때 UI 요소를 비활성화
            loveChkImg.SetActive(false);
        }
    }
}
