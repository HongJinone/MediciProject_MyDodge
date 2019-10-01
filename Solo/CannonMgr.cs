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

    //float createDelay;

    public Renderer rend;

    private void Start () {
        player1 = GameObject.Find ("Player1").GetComponent<Transform> ();
        //rend = GetComponent<rend.Renderer>();
        
        StartCoroutine(PlayerOffRange());
         
        
    }
    void Update () {
        this.transform.LookAt(player1.position);
        //Debug.Log(onRange);
    }
    // void CreateBullets(){
        
    //     createDelay= createDelay + Time.deltaTime;
    //     if (createDelay>=2f)
    //     {
    //         createDelay -= 2f;
    //         Instantiate(p_ball, firePosition.position, firePosition.rotation);
    //     }
    //     this.transform.LookAt(player1.position);
    // }
    
    // IEnumerator BulletLoop(){
    //     yield return StartCoroutine("PlayerOnRange");
    // }
    IEnumerator CannonDetectedPlayer(){
        yield return new WaitForSeconds (1f);
        //1초 지난 후 다시 판정
        if ((Vector3.Distance (this.transform.position, player1.position) < attackRange))
        {
            rend.material.SetColor("_Color", Color.yellow);
            yield return CannonShootIsReady();
        } else{
            rend.material.SetColor("_Color", Color.blue);
            yield return PlayerOffRange();
        }       
    }
    IEnumerator CannonShootIsReady(){
        yield return new WaitForSeconds (1f);
        if ((Vector3.Distance (this.transform.position, player1.position) < attackRange))
        {
            rend.material.SetColor("_Color", Color.red);
            yield return Instantiate(p_ball, firePosition.position, firePosition.rotation);
            yield return PlayerOffRange(); 
        } else {
            rend.material.SetColor("_Color", Color.yellow);
            yield return CannonDetectedPlayer();
        }
    }
    IEnumerator PlayerOffRange(){
        yield return new WaitForSeconds (1f);
        if ((Vector3.Distance (this.transform.position, player1.position) < attackRange))
        {
            yield return CannonDetectedPlayer();
        } else {
            rend.material.SetColor("_Color", Color.blue);
            StartCoroutine(PlayerOffRange()); //무한루프를 위한 추가식
        }

        // if (Vector3.Distance (this.transform.position, player1.position) < attackRange)
        // }
    }
    
    
    // IEnumerator CreateBullets(){
    //     yield return new WaitForSeconds (1f);
    //     rend.material.SetColor("_Color", Color.yellow);
    //     Debug.Log("ready");
    //     yield return new WaitForSeconds (1f);
    //     rend.material.SetColor("_Color", Color.red);
    //     Instantiate(p_ball, firePosition.position, firePosition.rotation);
    //     Debug.Log("wow2");
    //     yield return new WaitForSeconds (1f);
    //     rend.material.SetColor("_Color", Color.red);

    //     Debug.Log("wow3");
    // }

        // void CreateBullets(){
        // createDelay= createDelay + Time.deltaTime;
        // if (createDelay>=2f)
        // {
        //     createDelay -= 2f;
        //     Instantiate(p_ball, firePosition.position, firePosition.rotation);
        // }
        // this.transform.LookAt(player1.position);
}