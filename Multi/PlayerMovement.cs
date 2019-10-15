
using UnityEngine;

//1. Movement: We will use first person view. Controller are mouse and keyboard. 
public class PlayerMovement : Photon.PunBehaviour {
    public float speed = 6f;

    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;
    public Camera myCam;
    private int count;
    public float rotSpeed = 3.0f;

    private void Awake () {
        floorMask = LayerMask.GetMask ("Floor");
        anim = GetComponent<Animator> ();
        playerRigidbody = GetComponent<Rigidbody> ();
        myCam = GetComponentInChildren<Camera> ();
        if (!photonView.isMine) {
            enabled = false;
            myCam.gameObject.SetActive (false);
        }
    }

    void FixedUpdate () {
        float h = Input.GetAxisRaw ("Horizontal");
        float v = Input.GetAxisRaw ("Vertical");

        rotCtrl ();
        Move (h, v);


    }

    void Move (float h, float v) {
        movement.Set (h, 0f, v);
        movement = Camera.main.transform.TransformDirection(movement);
        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidbody.MovePosition (transform.position + movement);
    }
    void rotCtrl () {
        float rotX = Input.GetAxis ("Mouse Y") * rotSpeed;
        float rotY = Input.GetAxis ("Mouse X") * rotSpeed;
        myCam.transform.localRotation *= Quaternion.Euler (-rotX, 0, 0);
        this.transform.localRotation *= Quaternion.Euler (0, rotY, 0);

    }

}