using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMgr : MonoBehaviour {

    Transform scanPlayer;
    Vector3 dirPlayer;
    public int power;
    void Awake () {
        scanPlayer=   GameObject.FindWithTag("PLAYER").transform;
        
        //dirPlayer= new Vector3(transform.position.x, 0, transform.position.z);//성립은 하나 위치가 이상하게 뜸
        //Debug.Log(dirPlayer);
        Rigidbody rd;
        rd = GetComponent<Rigidbody> ();

        rd.AddForce (transform.forward * power);
        Destroy (this.gameObject, 4f);

    }

}