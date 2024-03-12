using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Servant : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rigidbody2D;
    public float moveSpeed = 2f;
    public float arrivalThreshold = 0.1f;
    public float stopDistance = 0.1f; // 멈추는 거리 임계값

    private Vector3 targetPosition;
    bool isWalk;
    public bool isRandomMove = true;
    public bool isServingEnd;
    public bool isArrive;
    public bool isChk;
    public bool isCustomerDir;
    public bool isKitchenDir;
    public GameObject moveBox_1;
    public GameObject moveBox_2;
    public GameObject kitchenZone;
    public KitchenNPC_Anim[] kitchenNPC_Anim;
    public int tmp;
    public GameObject makPrefab;
    GameObject spawnedChild;


    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //kitchenNPC_Anim = new KitchenNPC_Anim[10];
        for (int i = 0; i < 5; ++i)
        {
            kitchenNPC_Anim[i] = kitchenNPC_Anim[i].GetComponent<KitchenNPC_Anim>();

        }
        SetRandomMovementDirection();
        tmp = 0;
    }

    void Update()
    {
        if (isWalk)
        {
            Move();
        }
        if (kitchenNPC_Anim[0].isSitDown && !isChk)
        {
            isRandomMove = false;
            StartCoroutine("SetTargetMovementDirection", tmp);
            //SetTargetMovementDirection(tmp);
            isChk = true;
        }
        else
        {
            isRandomMove = true; // 새로운 목표 위치를 설정하기 전에 움직임을 랜덤하게 하도록 설정
        }
    }

    void Move()
    {
        float distanceToTarget = Vector2.Distance(transform.position, targetPosition);
        float stopThreshold = Mathf.Max(arrivalThreshold, stopDistance + Mathf.Abs(targetPosition.x) * 0.2f); // 멈추는 거리 임계값 계산

        if (distanceToTarget <= stopThreshold)
        {
            Debug.Log("도착");
            isWalk = false;
            if (isCustomerDir)
            {
                Debug.Log("손님한테 도착");
                animator.SetBool("isWalk", false);
                rigidbody2D.velocity = Vector2.zero;
                if (!isServingEnd)
                {
                    StartCoroutine(StayAndGoKitchen());
                }
                else if (isServingEnd)
                {
                    if (makPrefab != null)
                    {
                        Destroy(spawnedChild);
                        spawnedChild = null;
                    }
                    kitchenNPC_Anim[tmp].animator.SetBool("isEat", true);
                    if (tmp <= 4)
                    {
                        tmp++;
                        Debug.Log(tmp);
                        StartCoroutine("SetTargetMovementDirection", tmp);

                    }
                    else
                    {
                        SetRandomMovementDirection();
                    }
                    isServingEnd = false;
                }

                isCustomerDir = false;
            }
            else if (isKitchenDir)
            {
                Debug.Log("부엌에 도착");
                animator.SetBool("isWalk", false);
                rigidbody2D.velocity = Vector2.zero;
                StartCoroutine(StayAndGoCustomer());
                isKitchenDir = false;

            }
            else
            {
                SetRandomMovementDirection();
            }
        }
        else
        {
            Vector2 movementDirection = (targetPosition - transform.position).normalized;
            rigidbody2D.velocity = movementDirection * moveSpeed;

            transform.localScale = new Vector3(movementDirection.x > 0 ? -1f : 1f, 1f, 1f);
            animator.SetBool("isWalk", true);
        }
    }
    IEnumerator StayAndGoKitchen()
    {
        Debug.Log("부엌갈거야");

        yield return new WaitForSeconds(2f);
        SetTargetKitchenMovementDirection();
    }
    IEnumerator StayAndGoCustomer()
    {
        Debug.Log("음식받았고 다시 손님한테 갈거야");
        yield return new WaitForSeconds(3f);
        spawnedChild = Instantiate(makPrefab, new Vector3(transform.position.x, transform.position.y + .4f), Quaternion.identity);
        spawnedChild.transform.parent = transform;
        isServingEnd = true;
        isCustomerDir = true;

        StartCoroutine("SetTargetMovementDirection", tmp);
    }
    void SetTargetKitchenMovementDirection()
    {
        isWalk = true;
        isCustomerDir = false;
        isKitchenDir = true;
        targetPosition = kitchenZone.transform.position;

    }
    IEnumerator SetTargetMovementDirection(int num)
    {
        yield return new WaitForSeconds(.2f);
        Debug.Log("손님한테 갈거야");
        isWalk = true;
        isCustomerDir = true;
        Vector3 sitZonePosition = kitchenNPC_Anim[num].setSitZone.transform.position;
        if (sitZonePosition.x > transform.position.x)
            targetPosition = new Vector2(sitZonePosition.x - stopDistance, transform.position.y);
        else
            targetPosition = new Vector2(sitZonePosition.x + stopDistance, transform.position.y);

    }

    void SetRandomMovementDirection()
    {
        Debug.Log("랜덤갈거야");
        isWalk = true;
        float randomX = Random.Range(moveBox_1.transform.position.x, moveBox_2.transform.position.x);
        targetPosition = new Vector2(randomX, transform.position.y);
    }

}