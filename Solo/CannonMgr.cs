using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonMgr : MonoBehaviour {
    //1. 클릭을 하면 포구에서 공 생성
    //1-1. 일정 시간이 지나면 자동으로 포구에서 공 생성
    public GameObject p_ball;
    public Transform firePosition;

    public Transform player1;

    public float attackRange = 4.0f;

    bool onRange = false;

    float createDelay;
    Vector3 dis;
    
    public float dis2P;

    private void Start () {
        player1 = GameObject.Find ("Player1").GetComponent<Transform> ();

    }
    void Update () {
        if (Vector3.Distance (this.transform.position, player1.position) < attackRange){
            onRange = true;
            CreateBullets();
        }
        else onRange = false;

        Debug.Log(onRange);

    void CreateBullets(){
        createDelay= createDelay + Time.deltaTime;
        if (createDelay>=2f)
        {
            createDelay -= 2f;
            Instantiate(p_ball, firePosition.position, firePosition.rotation);
        }
        this.transform.LookAt(player1.position);
    }

        // createDelay = createDelay + Time.deltaTime;
        // float s = Input.GetAxisRaw ("Fire1");

        // if(s==1f){

        //     if(createDelay>=1f){
        //         createDelay -= 1f;

        //         Instantiate(
        //             p_ball, 
        //             firePosition.position, 
        //             firePosition.rotation);

        //     }

        // }

    }
}