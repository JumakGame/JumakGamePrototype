using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenNPC_Customer : MonoBehaviour
{
    public List<GameObject> sitZones;
    public List<GameObject> customers;
    List<int> selectedZones = new List<int>();

    public int sitZoneNum;
    public int speed;
    public int enterZoneTime;

    void Start()
    {

        StartCoroutine("EnterRestaurant");
    }
    IEnumerator EnterRestaurant()
    {
        enterZoneTime = Random.Range(3,15);
        for (int i = 0; i < 5; ++i)
        {
            do
            {
                sitZoneNum = Random.Range(0, 8); // 0부터 3까지의 랜덤한 숫자 선택
            } while (selectedZones.Contains(sitZoneNum)); // 이미 선택된 숫자라면 다시 선택

            selectedZones.Add(sitZoneNum); // 선택된 숫자 기록

            KitchenNPC_Anim kitchenNPC_Anim = customers[i].GetComponent<KitchenNPC_Anim>();
            if (kitchenNPC_Anim != null)
            {
                kitchenNPC_Anim.Move(sitZones[sitZoneNum]);
            }
            yield return new WaitForSeconds(enterZoneTime);

        }
        yield return null;
    }

}
