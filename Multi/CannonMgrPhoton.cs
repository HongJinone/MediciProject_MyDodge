using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1. When you click, ball will be created.
//2. When player attached to cannon, cannon will detect player.
public class CannonMgrPhoton : Photon.PunBehaviour {

    public GameObject p_ball;
    public Transform firePosition;
    public Transform player1;

    public float attackRange = 4.0f;


    //float createDelay;
    public Transform capsuleRotation;
    public Renderer rend;

    private void Start () {
        player1 = GameObject.FindWithTag ("Player").GetComponent<Transform> ();
        
        StartCoroutine(PlayerOffRange());  
        
    }
    void Update () {
        if ((Vector3.Distance (this.transform.position, player1.position) < attackRange))
            this.transform.LookAt(player1.position);

    }

    IEnumerator CannonDetectedPlayer(){
        yield return new WaitForSeconds (1f);

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
            yield return PhotonNetwork.Instantiate(this.p_ball.name, firePosition.position, firePosition.rotation,0);
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
            StartCoroutine(PlayerOffRange()); //loop
        }

    }
}