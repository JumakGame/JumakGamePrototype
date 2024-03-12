using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenNPC_Anim : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float moveSpeed;
    public Animator animator;
    public bool isWalking;
    public bool isWalk;
    public bool isExit;
    public bool isSitDown;

    public float arrivalThreshold = 0.1f; // 원하는 위치에 도달했다고 판단할 거리 임계값
    public float stopDistance = 0.1f; // 멈추는 거리 임계값
    private Vector3 targetPosition; // 목표 위치 저장
    public GameObject setSitZone;
    public GameObject exitZone;

    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
    }

    public void Move(GameObject sitZone)
    {
        setSitZone = sitZone;
        targetPosition = new Vector3(sitZone.transform.position.x + 0.5f, this.transform.position.y, sitZone.transform.position.z); // 목표 위치 설정
        isWalk = true;
        isWalking = true; // 걷는 중으로 설정
        
        animator.SetBool("isWalk", true); // 걷는 애니메이션 활성화
    }

    void Update()
    {
        if (isWalking)
        {
            Vector3 currentPosition = transform.position; // 현재 위치 가져오기
            float distanceToTarget = Vector3.Distance(currentPosition, targetPosition); // 현재 위치와 목표 위치 사이의 거리 계산

            float stopThreshold = Mathf.Max(arrivalThreshold, stopDistance + setSitZone.transform.localScale.x * 0.5f); // 멈추는 거리 임계값 계산

            // 움직임 제어
            if (distanceToTarget <= stopThreshold) // 원하는 위치에 도달했다고 판단되는 경우
            {
                if (isWalk && !isExit)
                {
                    animator.SetBool("isSitDown", true); // 걷는 애니메이션 비활성화
                    isSitDown = true;
                    isWalking = false; // 걷는 중이 아니라고 설정
                    rigidbody2D.velocity = Vector2.zero; // 속도를 0으로 설정하여 멈춤
                    StartCoroutine("LeaveHere");
                }
                else if(isExit)
                {
                    animator.SetBool("isWalk",false);
                    isWalking = false;
                    rigidbody2D.velocity = Vector2.zero;
                }               
            }
            else
            {
                // 목표 위치 방향으로 이동
                Vector3 direction = (targetPosition - currentPosition).normalized;
                rigidbody2D.velocity = direction * moveSpeed;
                transform.localScale = new Vector3(direction.x < 0 ? -1f : 1f, 1f, 1f);
            }
        }
        
    }
    void LeaveMove()
    {
        targetPosition = new Vector3(exitZone.transform.position.x + 0.5f, this.transform.position.y, exitZone.transform.position.z); // 목표 위치 설정
        isExit = true;
        isSitDown = false;
        isWalking = true; // 걷는 중으로 설정
        animator.SetBool("isEat", false); // 걷는 애니메이션 활성화
        animator.SetBool("isWalk", true);
        animator.SetBool("isSitDown", false);
        
    }
    IEnumerator LeaveHere()
    {
         yield return new WaitForSeconds(60f); // 60f
        LeaveMove();       
    }
}
