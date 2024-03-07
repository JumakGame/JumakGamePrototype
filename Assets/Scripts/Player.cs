using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using Cinemachine;
public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // 플레이어의 이동 속도
    private Rigidbody2D rb; // Rigidbody2D 컴포넌트에 대한 참조
    public Canvas interactionUI;
    public Canvas kitchenMenuReadyUI;
    public Canvas kitchenMenuUI;
    public bool isMenuPaperOpen;
    public bool isMenuPaperOpenReady;
    public CinemachineVirtualCamera mainCam;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트를 참조
    }
    void Update()
    {
        if (!isMenuPaperOpen)
        {
            Move();
        }
        if(isMenuPaperOpenReady)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                isMenuPaperOpen = true;
                isMenuPaperOpenReady = false;
                kitchenMenuReadyUI.gameObject.SetActive(false);
                kitchenMenuUI.gameObject.SetActive(true);
            }
            

        }


    }
    void Move()
    {
        // 플레이어 이동 입력 처리
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        // 플레이어 좌우 이동
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        // 플레이어가 좌우로 이동하는 방향을 바라보도록 설정
        if (horizontalInput != 0f)
        {
            transform.localScale = new Vector3(Mathf.Sign(horizontalInput), 1f, 1f);
        }
        

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Object"))
        {
            interactionUI.gameObject.SetActive(true);

        }
        if (other.CompareTag("MenuPaper")&& !isMenuPaperOpen)
        {

            kitchenMenuReadyUI.gameObject.SetActive(true);
            isMenuPaperOpenReady = true;

        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Object"))
        {
            interactionUI.gameObject.SetActive(false);

        }
         if (other.CompareTag("MenuPaper")&& !isMenuPaperOpen)
        {

            kitchenMenuReadyUI.gameObject.SetActive(false);
            isMenuPaperOpenReady = false;

        }
    }


}