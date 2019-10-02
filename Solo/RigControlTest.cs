﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigControlTest : MonoBehaviour {
    Vector3 movement;
    public float speed;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;
    float rayLength = 10f;
    bool isMove;
    //GameObject transparentWall;
    Transform tr;
    float angle;
    bool CACheck = false;

    GameObject catchableArea;
    // Start is called before the first frame update
    void Start () {
        playerRigidbody = GetComponent<Rigidbody> ();
        floorMask = LayerMask.GetMask ("Floor");
        tr = GetComponent<Transform> ();
        catchableArea = GameObject.Find("CatchableArea");
        catchableArea.SetActive(false);
    
        StartCoroutine(CatchDelay());   //캐치딜레이 루틴 실행 준비완료
    }

    // Update is called once per frame
    void Update () {
        float h = Input.GetAxisRaw ("Horizontal");
        float v = Input.GetAxisRaw ("Vertical");
        bool CACheck = Input.GetMouseButtonUp(0);
        Debug.Log("업데이트"+CACheck);
        Move (h, v);
        playerRigidbody.MovePosition (transform.position + movement);
        //Turnning();
        if(CACheck) Catch(CACheck);

        //CatchDelay(); //여기다 이걸 놓으면 Inumerator는 리턴을 하지 못하는 것 같다
    }

    private void Move (float h, float v) {
        movement.Set (h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        // Vector3 zeroPoint = new Vector3 (0, 0, 0);
        // Ray floorRay = new Ray (this.transform.position, Vector3.down);
        // if (!Physics.Raycast (this.transform.position, Vector3.down, rayLength, floorMask)) {
        //     isMove = false;
        // }    
    }
     void Catch (bool CACheck) {     
        if(CACheck)
        {
            Debug.Log("wow");
            catchableArea.SetActive (true);
            //yield return 0f;     
            CatchDelay();  //유니티가 멈춤 - 자기 자신을 어떤 조건도 없이 무한실행
        } 
    }

    IEnumerator CatchDelay(){
        //좌클 입력값이 들어오면 CatchArea GO를 1초 동안 unactive한다.
        //Debug.Log("wow");
        yield return new WaitForSeconds (10f);
        catchableArea.SetActive(false);
        CACheck=false;
        //Debug.Log(CACheck);
        yield return StartCoroutine(CatchDelay());
    }

    // void OnTriggerStay(Collider other) {
    //     if()
    //     Destroy(other)
    //     // if(other.gameObject == catchableArea)
    //     // {
    //     //     Destroy();
    //     // }   
    // }

    // void Turnning()
    // {
    //     Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

    //     RaycastHit floorHit;

    //     if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
    //     {
    //         Vector3 playerToMouse = floorHit.point - transform.position;
    //         playerToMouse.y = 0f;

    //         Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
    //         playerRigidbody.MoveRotation(newRotation);
    //     }
    // }

    // IEnumerator Catch () {
        
    //     float f = Input.GetAxisRaw ("Fire1");
    //     Debug.Log(f);
    //     if (f > 0f) {
    //         Debug.Log("wow");
    //         catchableArea.SetActive (true);
    //         yield return new WaitForSeconds (1f);
    //         catchableArea.SetActive (false);
    //         //yield return 0f;
    //         StartCoroutine (Catch());
    //     }
    // }

    // void Catch(bool f){
    //     if(f){
    //         catchableArea.SetActive(true);  
    //         CACheck = true;         //매서드를 불값으로 돌릴 수 없어서 변수를 수동 연동시킴
    //         CatchDelay();
    //     }
    // }
}