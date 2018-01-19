using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {

    public bool isGrounded = true;
    public bool gamePlay = true;

    private Transform tr;
    private Rigidbody rigid;

    private GameUI gameUI;

    public float moveSpeed = 13.0f;
    public float jumpmoveSpeed = 7.0f;
    public float jumpSpeed = 6.0f;

    private int runScore;

    public AudioClip[] audioClip;
    public AudioSource audioSource;

    public Renderer renderer;

    private GameObject gamePanel;


    private void Awake()
    {
        gameUI = GameObject.Find("GameUI").GetComponent<GameUI>();
        tr = GetComponent<Transform>();
        rigid = GetComponent<Rigidbody>();
        renderer = GetComponentInChildren<Renderer>();
    }
    // Use this for initialization
    void Start () {
        gamePanel = GameObject.Find("GamePanel");
    }

    // Update is called once per frame
    void Update () {
        //전후좌우 이동 방향 벡터 계산
        Vector3 moveDir = Vector3.forward;
        Vector3 rotDir = Vector3.up;

        runScore = (int)moveSpeed/5;
        //달리기 속도에 맞게 점수 계산


        if (isGrounded == true)
        {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    Debug.Log("Right");
                    tr.Rotate(0, 90, 0);
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    Debug.Log("Left");
                    tr.Rotate(0, -90, 0);
                }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Jump");
                PlaySound(0);
                rigid.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            }
        }

        if(gamePlay == true)
        {
            gameUI.DispScore(runScore);
            //Translate(이동방향 * 속도 * 변위값 * Time.deltaTime, 기준좌표)
            tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.Self);
        }
        if (rigid.velocity.y < 0)
        {
            rigid.velocity += Vector3.up * Physics.gravity.y * 5 * Time.deltaTime;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void SpeedUp()
    {
        moveSpeed += 0.5f;
    }

    public  void GameOver()
    {
        renderer.enabled = false;
        PlaySound(1);
        gamePlay = false;

        gamePanel.transform.FindChild("GameOverPanel").gameObject.SetActive(true);
        gameUI.EndScore();
    }

    private void PlaySound(int clip)
    {
        audioSource.clip = audioClip[clip];
        audioSource.Play();

    }
}
