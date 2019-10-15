using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1. It contains Player's catch and shoot.
//2. By Raycast to catch, Instantiate to shoot
public class PlayerCatch : Photon.PunBehaviour {
    public LayerMask layerMask;
    RaycastHit hit;
    public GameObject ball;
    public GameObject p_bullet;
    public Transform firePosition;
    int bulletCount;
    void Update () {
        var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        if (Input.GetMouseButtonDown (0)) {

            Debug.Log ("push");
        }

        if (Physics.Raycast (ray, out hit, layerMask) && hit.distance <= 2f &&
            hit.transform.gameObject.tag == "Ball" && bulletCount == 0) {

            hit.transform.GetComponent<MeshRenderer> ().material.color = Color.red;
            Debug.DrawRay (transform.position, transform.forward, Color.blue, 100f);
            Catch ();
        }
        if (bulletCount == 1) {
            Shoot ();
        }

    }
    void Catch () {
        if (Input.GetMouseButtonDown (0) && hit.transform.gameObject.tag == "Ball") {
            
            Debug.Log ("catch");
            Destroy (hit.transform.gameObject);
            bulletCount++;
        }
    }
    void Shoot () {
        if (bulletCount == 1 && Input.GetMouseButtonDown (1)) {
            PhotonNetwork.Instantiate (this.p_bullet.name, firePosition.position, firePosition.rotation, 0);
            bulletCount--;
        }
    }
}