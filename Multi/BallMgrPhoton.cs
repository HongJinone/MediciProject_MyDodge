using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1. Ball contains Collision event. It's same as player's bullet.
public class BallMgrPhoton : MonoBehaviour {
    GameObject player;
    //Transform scanPlayer;
    Vector3 dirPlayer;
    public int power;

    PlayerHealth playerHealth;
    public int attackDmg=1;

    GameObject catchableArea;
    void Awake () {

        player= GameObject.FindWithTag("Player");
        catchableArea= GameObject.Find("CatchableArea");
        playerHealth = player.GetComponent<PlayerHealth>();

        Rigidbody rd;
        rd = GetComponent<Rigidbody> ();

        rd.AddForce (transform.forward * power);
        Destroy (this.gameObject, 4f);
    }
    private void OnCollisionEnter(Collision other) { 
        if (other.gameObject==player)
        {
            Debug.Log("attacked");
            playerHealth.TakeDamage(attackDmg);
        } 
    }
}