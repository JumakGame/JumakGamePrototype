using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;

public class KitchenChangeFee : MonoBehaviour
{
    public Slider drink_1;
    public TextMeshProUGUI drink_1ChangeFee;
    public Slider drink_2;
    public TextMeshProUGUI drink_2ChangeFee;
    public Slider drink_3;
    public TextMeshProUGUI drink_3ChangeFee;
    public Slider beef_1;
    public TextMeshProUGUI beef_1ChangeFee;
    public Slider beef_2;
    public TextMeshProUGUI beef_2ChangeFee;
    void Start()
    {
        ChangeDrinkFee_1();
        ChangeDrinkFee_2();
        ChangeDrinkFee_3();
        ChangeBeefFee_1();
        ChangeBeefFee_2();
    }
    public void ChangeDrinkFee_1()
    {
        drink_1ChangeFee.text = drink_1.value.ToString();
    }
    public void ChangeDrinkFee_2()
    {
        drink_2ChangeFee.text = drink_2.value.ToString();

    }
    public void ChangeDrinkFee_3()
    {
        drink_3ChangeFee.text = drink_3.value.ToString();

    }
    public void ChangeBeefFee_1()
    {
        beef_1ChangeFee.text = beef_1.value.ToString();
    }
    public void ChangeBeefFee_2()
    {
        beef_2ChangeFee.text = beef_2.value.ToString();

    }
}
