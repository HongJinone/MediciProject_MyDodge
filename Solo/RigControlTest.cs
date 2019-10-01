using System.Collections;
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
    // Start is called before the first frame update
    void Start () {
        playerRigidbody = GetComponent<Rigidbody> ();
        floorMask = LayerMask.GetMask ("Floor");
        tr = GetComponent<Transform> ();
    }

    // Update is called once per frame
    void Update () {
        float h = Input.GetAxisRaw ("Horizontal");
        float v = Input.GetAxisRaw ("Vertical");
        move (h, v);
        playerRigidbody.MovePosition (transform.position + movement);
        //Turnning();
    }

    private void move (float h, float v) {
        movement.Set (h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        // Vector3 zeroPoint = new Vector3 (0, 0, 0);
        // Ray floorRay = new Ray (this.transform.position, Vector3.down);
        // if (!Physics.Raycast (this.transform.position, Vector3.down, rayLength, floorMask)) {
        //     isMove = false;
        // }
        
    }
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
}