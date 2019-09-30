using UnityEngine;

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
    //변수들을 초기화한다
    private void Awake () {
        floorMask = LayerMask.GetMask ("Floor");
        anim = GetComponent<Animator> ();
        playerRigidbody = GetComponent<Rigidbody> ();
        myCam = GetComponentInChildren<Camera> ();
        if (!photonView.isMine) {
            enabled = false;
            myCam.gameObject.SetActive (false); //이게 없어서 카메라가 뒤바뀌었던 것
        }
    }

    void FixedUpdate () {
        float h = Input.GetAxisRaw ("Horizontal");
        float v = Input.GetAxisRaw ("Vertical");

        rotCtrl ();
        Move (h, v);
        //Turnning();

    }

    void Move (float h, float v) {
        movement.Set (h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidbody.MovePosition (transform.position + movement);
    }
    void rotCtrl () {
        float rotX = Input.GetAxis ("Mouse Y") * rotSpeed;
        float rotY = Input.GetAxis ("Mouse X") * rotSpeed;
        myCam.transform.localRotation *= Quaternion.Euler (-rotX, 0, 0);
        this.transform.localRotation *= Quaternion.Euler (0, rotY, 0);

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

    //////////////////
}