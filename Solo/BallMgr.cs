﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMgr : MonoBehaviour {
    GameObject player;
    //Transform scanPlayer;
    Vector3 dirPlayer;
    public int power;

    PlayerHealth playerHealth;
    public int attackDmg=1;

    void Awake () {
        //scanPlayer=   GameObject.FindWithTag("PLAYER").transform;
        player= GameObject.FindWithTag("PLAYER");
        playerHealth = player.GetComponent<PlayerHealth>();

        
        //dirPlayer= new Vector3(transform.position.x, 0, transform.position.z);//성립은 하나 위치가 이상하게 뜸
        //Debug.Log(dirPlayer);
        Rigidbody rd;
        rd = GetComponent<Rigidbody> ();

        rd.AddForce (transform.forward * power);
        Destroy (this.gameObject, 4f);
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject==player)
        {
            Debug.Log("맞았다");
            playerHealth.TakeDamage(attackDmg); //PlayerHealth 클래스의 TakeDamage의 함수에 이 클래스 attackDmg 저장
            
        }
    }
    
}