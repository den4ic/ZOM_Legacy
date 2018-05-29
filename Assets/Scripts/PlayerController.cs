using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
   // public float jumpForce;

    public Rigidbody rb;

    private MobileController mContr;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        mContr = GameObject.FindWithTag("Joystick").GetComponent<MobileController>();
    }
	

	void Update ()
    {
        //rb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y, moveSpeed);

        rb.velocity = new Vector3(mContr.Horizontal() * moveSpeed, rb.velocity.y, moveSpeed);



        //rb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y, Input.GetAxis("Vertical") * moveSpeed);



        //if (Input.GetKeyDown(KeyCode.Space)) //|| Input.GetMouseButtonDown(0))
        //{
        //    rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        //}

    }


}
