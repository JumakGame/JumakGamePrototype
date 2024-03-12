using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FoodCnt_Pro : MonoBehaviour
{
    public List<TextMeshProUGUI> originalMakUIs = new List<TextMeshProUGUI>();
    public List<TextMeshProUGUI> soysourceUIs = new List<TextMeshProUGUI>();

    public TextMeshProUGUI text;

    [Header("재료 개수")]
    public static int StrawberryCnt;  // 각 인스턴스의 딸기 개수를 추적하는 변수 추가
    public static int AppleCnt;
    public static int PorkCnt;
    public static int FishCnt;
    public static int SoysourceCnt;
    public static int OriginalMakCnt;


    [Header("완성된 요리 개수")]
    public static int strawberryMak_minBottles;
    public static int appleMak_minBottles;
    public static int pork_minFood;
    public static int fish_minFood;

    [Header("Bool")]
    public bool isStrawberry;
    public bool isApple;
    public bool isPork;
    public bool isFish;
    public bool isSoysource;
    public bool isOriginalMak;

    public static int strawberryBottles;
    public static int originalMakBottles;
    public static int appleBottles;
    public static int porkFood;
    public static int fishFood;
    public static int soySource;


    [Header("NeedIngredients")]
    public TextMeshProUGUI needStrawberryCnt;
    public TextMeshProUGUI needAppleCnt;
    public TextMeshProUGUI needPorkCnt;
    public TextMeshProUGUI needFishCnt;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        GameObject strawberryCntObj = GameObject.Find("NeedStrawberryCnt_txt");
        needStrawberryCnt = strawberryCntObj ? strawberryCntObj.GetComponent<TextMeshProUGUI>() : null;

        GameObject appleCntObj = GameObject.Find("NeedAppleCnt_txt");
        needAppleCnt = appleCntObj ? appleCntObj.GetComponent<TextMeshProUGUI>() : null;

        GameObject porkCntObj = GameObject.Find("NeedPorkCnt_txt");
        needPorkCnt = porkCntObj ? porkCntObj.GetComponent<TextMeshProUGUI>() : null;

        GameObject fishCntObj = GameObject.Find("NeedFishCnt_txt");
        needFishCnt = fishCntObj ? fishCntObj.GetComponent<TextMeshProUGUI>() : null;
    }

    public void OnClickTest()
    {

        if (isStrawberry)
        {
            StrawberryCnt += 1;
            text.text = StrawberryCnt.ToString();

            Debug.Log("딸기 구입 개수 : " + StrawberryCnt);
            if (StrawberryCnt >= 3)
            {
                text.color = Color.green;
                needStrawberryCnt.color = Color.green;
            }

        }
        else if (isApple)
        {
            AppleCnt += 1;
            text.text = AppleCnt.ToString();

            Debug.Log("사과 구입 개수 : " + AppleCnt);
            if (AppleCnt >= 3)
            {
                text.color = Color.green;
                needAppleCnt.color = Color.green;
            }

        }
        else if (isPork)
        {
            PorkCnt += 1;
            text.text = PorkCnt.ToString();

            Debug.Log("고기 구입 개수 : " + PorkCnt);
            if (PorkCnt >= 3)
            {
                text.color = Color.green;
                needPorkCnt.color = Color.green;
            }
        }
        else if (isFish)
        {
            FishCnt += 1;
            text.text = FishCnt.ToString();

            Debug.Log("생선 구입 개수 : " + FishCnt);
            if (FishCnt >= 3)
            {
                text.color = Color.green;
                needFishCnt.color = Color.green;
            }
        }
        else if (isSoysource)
        {
            int incrementValue = 1;

            foreach (TextMeshProUGUI uiText in soysourceUIs)
            {
                int currentValue = int.Parse(uiText.text);
                uiText.text = (currentValue + incrementValue).ToString();
            }
            SoysourceCnt += incrementValue;
            Debug.Log("간장 구입 개수 : " + SoysourceCnt);
        }
        else if (isOriginalMak)
        {
            int incrementValue = 1;

            foreach (TextMeshProUGUI uiText in originalMakUIs)
            {
                int currentValue = int.Parse(uiText.text);
                uiText.text = (currentValue + incrementValue).ToString();
            }
            OriginalMakCnt += incrementValue;
            Debug.Log("막걸리 구입 개수 : " + OriginalMakCnt);
        }
        UpdateDebugText();
    }


    public void UpdateDebugText()
    {
        strawberryBottles = StrawberryCnt / 3;
        originalMakBottles = OriginalMakCnt / 5;
        appleBottles = AppleCnt / 3;
        porkFood = PorkCnt / 3;
        fishFood = FishCnt / 3;
        soySource = SoysourceCnt / 5;

        strawberryMak_minBottles = Mathf.Min(strawberryBottles, originalMakBottles);
        appleMak_minBottles = Mathf.Min(appleBottles, originalMakBottles);
        pork_minFood = Mathf.Min(porkFood, soySource);
        fish_minFood = Mathf.Min(fishFood, soySource);

        if (strawberryMak_minBottles > 0)
        {
            Debug.Log("딸기막걸리 " + strawberryMak_minBottles + "병을 만들 수 있습니다!");
        }
        if (appleMak_minBottles > 0)
        {
            Debug.Log("사과막걸리 " + appleMak_minBottles + "병을 만들 수 있습니다!");
        }
        if (pork_minFood > 0)
        {
            Debug.Log("돼지고기요리 " + pork_minFood + "개를 만들 수 있습니다!");
        }
        if (fish_minFood > 0)
        {
            Debug.Log("생선요리 " + fish_minFood + "개를 만들 수 있습니다!");
        }
    }

}
