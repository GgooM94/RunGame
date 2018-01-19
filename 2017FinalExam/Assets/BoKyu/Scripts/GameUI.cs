using System.Collections;
//UI 컴포넌트에 접근하기 위해 추가한 네임스페이스
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;


public class GameUI : MonoBehaviour
{


    public Text txtScore;
    public Text txtTopScore;
    public Text txtEndScore;
    public Text txtCoin;

    private int nowScore = 0;
    private int topScore = 0;

    private int coinCount = 0;
    // Use this for initialization
    void Start()
    {
        topScore = PlayerPrefs.GetInt("TOP_SCORE", 0);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void CountCoin()
    {
        coinCount += 1;
    }


    public void DispScore(int score)
    {
        nowScore += score;

        txtScore.text = "<color=0000000>" + nowScore.ToString() + "</color>";


    }

    public void EndScore()
    {
        txtTopScore = GameObject.Find("TopScoretxt").GetComponent<Text>();
        txtEndScore = GameObject.Find("EndScoretxt").GetComponent<Text>();
        txtCoin = GameObject.Find("EndCoinstxt").GetComponent<Text>();


        txtEndScore.text = nowScore.ToString();
        txtCoin.text = coinCount.ToString();

        //PlayerPrefs 변수 초기화
        //PlayerPrefs.SetInt("TOP_SCORE", 0);


        if (nowScore >= topScore)
        {
            PlayerPrefs.SetInt("TOP_SCORE", nowScore);
            txtTopScore.text = nowScore.ToString();
        }
        else
        {
            txtTopScore.text = topScore.ToString();
        }



    }


}