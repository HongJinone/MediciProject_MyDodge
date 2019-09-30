using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManager : MonoBehaviour {
    public Transform[] s_Point;

    public GameObject p_Cube;

    // Start is called before the first frame update
    void Start () {
        // Instantiate(p_Cube, s_Point.position, s_Point.rotation);
        int myIndexNumber = System.Array.IndexOf(PhotonNetwork.playerList, PhotonNetwork.player);
        Vector3 location = s_Point[myIndexNumber].position;
        location.y = 1f;

        PhotonNetwork.Instantiate("Player1",location, s_Point[myIndexNumber].rotation,0);
        
    }

    // Update is called once per frame
    void Update () {

    }
}