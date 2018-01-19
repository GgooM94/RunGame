using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObstacle : MonoBehaviour {
    private FollowMonster followMonster;
    private PlayerCtrl playerCtrl;

    private void Awake()
    {
  //      followMonster = GameObject.Find("Creepy").GetComponent<FollowMonster>();
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerCtrl>();
    }
    // Use this for initialization
    void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            followMonster.MinuDist();
        }
        else if (other.gameObject.CompareTag("SpeedUpWall"))
        {
            playerCtrl.SpeedUp();
        }
        else if (other.gameObject.CompareTag("GameOver"))
        {
            Debug.Log("GameOver");
            playerCtrl.GameOver();
        }
    }




}
