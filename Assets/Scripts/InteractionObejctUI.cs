using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InteractionObejctUI : MonoBehaviour
{
    public Image uiImage; // 고정된 오브젝트 위에 표시할 UI 텍스트
    public Transform targetObject; // 고정할 대상 오브젝트

    void Update()
    {
        // 대상 오브젝트의 위치를 기반으로 UI 텍스트의 위치를 업데이트
        Vector3 targetPosition = targetObject.position;
        Vector3 uiPosition = new Vector3(targetPosition.x + 1f, targetPosition.y + 1.5f, targetPosition.z); // 오브젝트 위에 UI 텍스트를 고정

        uiImage.transform.position = Camera.main.WorldToScreenPoint(uiPosition);
    }
}

