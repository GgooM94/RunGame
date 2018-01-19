using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour {

    // Use this for initialization
    private Transform coin;
    private void Awake()
    {
        coin = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update () {

        coin.Rotate(0, 0, 5);
        
		
	}
}
