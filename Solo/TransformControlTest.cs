using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformControlTest : MonoBehaviour {

  public int moveSpeed = 10;
  public Transform tr;
  bool isMove;
  int floorMask;
  //public float rotSpeed=80;
  float rayLength = 10f;
  private void Start () {
    tr = GetComponent<Transform> ();
    isMove = true;
    floorMask = LayerMask.GetMask ("Floor");
  }
  private void Update () {

    if (isMove) {
      MovePlayer ();
    } 
  }
  private void MovePlayer () {

    float h = Input.GetAxis ("Horizontal");
    float v = Input.GetAxis ("Vertical");
    // Debug.Log(h);
    // Debug.Log(v);

    Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
    tr.Translate (moveDir.normalized * moveSpeed * Time.deltaTime, Space.Self);
    //Debug.Log (Mathf.Abs (tr.position.x));
    //Debug.Log (Mathf.Abs (tr.position.z));

    // float angle = Mathf.Atan2 (tr.position.z, tr.position.x) * Mathf.Rad2Deg;
    //Debug.Log(angle);
    // Debug.Log(Mathf.Sin(angle*Mathf.Deg2Rad));;
    // if ((tr.position.x * tr.position.x) + (tr.position.z * tr.position.z) > 25) {
    //  gameObject.SetActive (false);
    // // }

    //방향까지 바꾸고 싶다면
    //float r= Input.GetAxis("Mouse X");
    //tr.Rotate(Vector3.up*rotSpeed*Time.deltaTime);

    //float sqPos = (tr.position.x * tr.position.x) + (tr.position.z * tr.position.z); //원의 방정식
    //if (sqPos > Mathf.Abs(25)) {  //Abs 를 쓴 거랑 안 쓴 거랑 차이가 있다. 절대적인 거리를 비교해야 하므로
    //moveDir += (-(tr.position.x), 0, -(tr.position.z)); //안됨
    //   // h *= -1;
    //   // v *= -1; //안됨
    //   //moveDir *= -1; //안됨

    //삼각함수 구현식(일부)
    //float angle = Mathf.Atan2 (tr.position.z, tr.position.x) * Mathf.Rad2Deg;
    //Debug.Log(angle);
    //Debug.Log(Mathf.Sin(angle*Mathf.Deg2Rad));;
    Vector3 zeroPoint = new Vector3 (0, 0, 0);
    Ray floorRay = new Ray (this.transform.position, Vector3.down);
    if (!Physics.Raycast (this.transform.position, Vector3.down, rayLength, floorMask)) {
        isMove = false;
        //이 시점에서 중단(0930 20:41)
    }
    //벡터 거리를 비교한 구현식
    // if (Vector3.Distance (tr.position, zeroPoint) >= Mathf.Abs (5)) {
    //   //isMove=false;
    //   Debug.Log ("out");
    //   isMove = false;
    // } else if (Vector3.Distance (tr.position, zeroPoint) <= Mathf.Abs (5)) {
    //   isMove = true;
    //   Debug.Log ("in");
    
    // }
    //Debug.Log (sqPos);
  }
}