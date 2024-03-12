using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CamSet : MonoBehaviour
{
    
    public Transform target; // 플레이어나 따라다닐 대상
    public float minX, maxX; // 제한할 영역의 최소 및 최대 x 값

    private Camera mainCamera;
    private Vector3 offset;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        float clampedX = Mathf.Clamp(targetPosition.x, minX, maxX);

        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
  
}
