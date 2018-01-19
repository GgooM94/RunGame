using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMonster : MonoBehaviour
{
    public Transform targetTr;
    public float monsterDist = 6.0f;
    public float monsterDampTrace = 20.0f;

    private BoxCollider boxCollider;

    private Transform tr;

    // Use this for initialization
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        tr = GetComponent<Transform>();     
    }

    // Update is called once per frame
    private void Update()
    {
    }
    public void MinuDist()
    {
        monsterDist -= 1.5f;
        Debug.Log("MinuDist");
    }


    private void LateUpdate()
    {

        tr.position = Vector3.Lerp(tr.position, targetTr.position
            - (targetTr.forward * monsterDist), Time.deltaTime * monsterDampTrace);

        tr.LookAt(targetTr.position);

    }
}
