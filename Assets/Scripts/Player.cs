using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using Cinemachine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // 플레이어의 이동 속도
    private Rigidbody2D rb; // Rigidbody2D 컴포넌트에 대한 참조
    public Canvas interactionUI;
    public Canvas kitchenMenuReadyUI;
    public Canvas GoVillageUI;
    public Canvas kitchenMenuUI;
    public Canvas staffInfoUI;
    public Canvas staffChearUpUI;
    public Canvas staffChearUpUIReady;
    public Canvas GoJumakUI;
    public Canvas CEOTalkUI;
    public GameObject marketUI;

    public bool isMenuPaperOpen;
    public bool isGoVillageUI;
    public bool isGoJumak;
    public bool isStaffPaperOpenReady;
    public bool isMenuPaperOpenReady;
    public bool isStaff;
    public bool isChk;
    public bool isCEOTalk;
    public Canvas NoNextUI;

    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트를 참조
        anim = GetComponent<Animator>();
    }
    void Update()
    {

        if (isMenuPaperOpenReady || isStaffPaperOpenReady || isStaff || isGoVillageUI || isGoJumak || isCEOTalk)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isMenuPaperOpen = true;
                if (isGoVillageUI)
                {
                    SceneManager.LoadScene("SquareScene");
                }
                if (isGoJumak)
                {
                    SceneManager.LoadScene("JumakScene");
                }

                
                if (isMenuPaperOpenReady && !kitchenMenuUI.gameObject.activeSelf)
                {
                    kitchenMenuUI.gameObject.SetActive(true);
                }
                if (isStaffPaperOpenReady && !staffInfoUI.gameObject.activeSelf)
                {
                    staffInfoUI.gameObject.SetActive(true);

                }
                if (isStaff && !staffChearUpUI.gameObject.activeSelf)
                {
                    Time.timeScale = 0;
                    staffChearUpUI.gameObject.SetActive(true);
                    isChk = true;
                }
                if(isCEOTalk && !marketUI.gameObject.activeSelf)
                {
                    marketUI.gameObject.SetActive(true);
                    CEOTalkUI.gameObject.SetActive(false);
                }
                //isStaff = false;
                isMenuPaperOpenReady = false;
                isStaffPaperOpenReady = false;
                //isMenuPaperOpen = false;
            }
        }


    }
    void FixedUpdate()
    {
        if (!isMenuPaperOpen)
        {
            Move();
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
            anim.SetBool("isWalk_Left", true);
            transform.localScale = new Vector3(Mathf.Sign(horizontalInput), 1f, 1f);
        }
        else
        {
            anim.SetBool("isWalk_Left", false);
        }


    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("MenuPaper") && !isMenuPaperOpen)
        {

            kitchenMenuReadyUI.gameObject.SetActive(true);
            isMenuPaperOpenReady = true;
        }
        if (other.CompareTag("StaffInfo") && !isStaffPaperOpenReady)
        {
            kitchenMenuReadyUI.gameObject.SetActive(true);
            isStaffPaperOpenReady = true;
        }
        if (other.CompareTag("Staff") && !isStaff && !isChk)
        {
            staffChearUpUIReady.gameObject.SetActive(true);
            isStaff = true;
        }
        if (other.CompareTag("GoVillage") && !isGoVillageUI)
        {

            GoVillageUI.gameObject.SetActive(true);
            isGoVillageUI = true;
        }
        if (other.CompareTag("GoJumak") && !isGoJumak)
        {

            GoJumakUI.gameObject.SetActive(true);
            isGoJumak = true;
        }
        if(other.CompareTag("BackyardZone"))
        {
             NoNextUI.gameObject.SetActive(true);
        }
        if(other.CompareTag("CEO")&& !isCEOTalk)
        {
            isCEOTalk = true;
            CEOTalkUI.gameObject.SetActive(true);

        }

    }
  

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("MenuPaper") && isMenuPaperOpenReady)
        {

            kitchenMenuReadyUI.gameObject.SetActive(false);
            isMenuPaperOpenReady = false;

        }
        if (other.CompareTag("StaffInfo") && isStaffPaperOpenReady)
        {

            staffInfoUI.gameObject.SetActive(false);
            isStaffPaperOpenReady = false;

        }
        if (other.CompareTag("Staff") && isStaff)
        {
            interactionUI.gameObject.SetActive(false);
            isStaff = false;
        }
        if (other.CompareTag("GoVillage") && isGoVillageUI)
        {

            GoVillageUI.gameObject.SetActive(false);
            isGoVillageUI = false;
        }
        if (other.CompareTag("GoJumak") && isGoJumak)
        {

            GoJumakUI.gameObject.SetActive(false);
            isGoJumak = false;
        }
        if(other.CompareTag("BackyardZone"))
        {
             NoNextUI.gameObject.SetActive(false);
        }
         if(other.CompareTag("CEO")&& isCEOTalk)
        {
            isCEOTalk = false;
            CEOTalkUI.gameObject.SetActive(false);

        }
    }


}
