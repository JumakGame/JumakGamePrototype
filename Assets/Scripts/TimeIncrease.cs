using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeIncrease : MonoBehaviour
{
    
    public Slider slider; // Unity Inspector에서 슬라이더를 연결할 수 있도록 public으로 선언합니다.
    public float increaseRate = 1.0f; // 슬라이더가 증가할 속도를 조절하기 위한 변수입니다.

    private float currentValue = 0.0f; // 슬라이더의 현재 값입니다.

    void Start()
    {
        // 초기 슬라이더 값을 설정합니다.
        slider.value = currentValue;
    }

    void Update()
    {
        // 시간에 따라 슬라이더 값을 증가시킵니다.
        currentValue += increaseRate * Time.deltaTime;

        // 슬라이더의 최대 값을 넘지 않도록 제한합니다.
        currentValue = Mathf.Min(currentValue, slider.maxValue);

        // 증가한 값을 슬라이더에 반영합니다.
        slider.value = currentValue;
    }
}
