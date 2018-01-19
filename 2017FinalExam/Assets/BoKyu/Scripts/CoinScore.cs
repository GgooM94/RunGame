using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScore : MonoBehaviour {
    //GameUI에 접근하기 위한 변수
    private GameUI gameUI;


    private Transform playerTr;
    private Transform coinTr;

    public AudioClip coinClip;
    public AudioSource coinSource;
   
    private void Awake()
    {
        gameUI = GameObject.Find("GameUI").GetComponent<GameUI>();


    }
    // Use this for initialization
    void Start () {
        coinSource.clip = coinClip;
     
    }

    // Update is called once per frame
    void Update () {


	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            coinSource.Play();
            gameUI.CountCoin();
            gameUI.DispScore(50);

            this.GetComponent<Renderer>().enabled = false;

            StartCoroutine(DestroyCoin());      

        }
    }

    IEnumerator DestroyCoin()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
