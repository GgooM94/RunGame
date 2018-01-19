using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour {

    private Transform groundTr;


    private void Awake()
    {
        groundTr = GetComponent<Transform>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DestroyGround"))
        {

            StartCoroutine(TimeDelay());
            
        }
    }

    IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(3);
        //Translate(이동방향 * 속도 * 변위값 * Time.deltaTime, 기준좌표)
        groundTr.Translate(Vector3.up * -1 , Space.Self);

    }
}
