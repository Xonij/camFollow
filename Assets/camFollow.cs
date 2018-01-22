using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow : MonoBehaviour {

    //change between control scemes
    public bool forwardAndBackwards,translateOrNot,rollerball;
    //all the things
    public Camera cam;
    public GameObject targetThingie;
    public float kerroin = 3;

    Rigidbody rb;
    float speed = 15;
    Vector3 offset = new Vector3(0, 2, -5),offsetpos;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        cam.transform.position = targetThingie.transform.position + offset;
    }

	void Update ()
    {
        offsetpos = new Vector3(targetThingie.transform.position.x, targetThingie.transform.position.y+1, targetThingie.transform.position.z);

        //cam.transform.LookAt(targetThingie.transform.position);
        //cam.transform.position = targetThingie.transform.position+offset;
        cam.transform.position = Vector3.Lerp(cam.transform.position, offsetpos, Time.deltaTime * 2);
        cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, targetThingie.transform.rotation,Time.deltaTime*2);


        if (forwardAndBackwards == true)
        {
            tankControls();
        }
        if (translateOrNot == true)
        {
            movementTranslateGrid();
        }
	}
    void FixedUpdate()
    {
        if (rollerball == true)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rb.AddForce(movement * speed);
        }
    }//rollerball tutorial
    public void movementTranslateGrid()
    {
        //all sides horizontally
        if (Input.GetKey(KeyCode.A)) { targetThingie.transform.Translate(Vector3.left * Time.deltaTime * kerroin); }
        else if (Input.GetKey(KeyCode.D)) { targetThingie.transform.Translate(Vector3.right * Time.deltaTime * kerroin); }
        else if (Input.GetKey(KeyCode.W)) { targetThingie.transform.Translate(new Vector3(0,0,1) * Time.deltaTime * kerroin); }
        else if (Input.GetKey(KeyCode.S)) { targetThingie.transform.Translate(new Vector3(0,0,-1) * Time.deltaTime * kerroin); }
        //up & down
        else if (Input.GetKey(KeyCode.Q)) { targetThingie.transform.Translate(Vector3.up * Time.deltaTime * kerroin); }
        else if (Input.GetKey(KeyCode.E)) { targetThingie.transform.Translate(Vector3.down * Time.deltaTime * kerroin); }
    }//translate on axis
    public void tankControls()
    {
        if (Input.GetKey(KeyCode.A)) { targetThingie.transform.Rotate(0, -3, 0); }
        else if (Input.GetKey(KeyCode.D)) { targetThingie.transform.Rotate(0, 3, 0); }
        else if (Input.GetKey(KeyCode.W)) { targetThingie.transform.Translate(Vector3.forward * Time.deltaTime * kerroin); }
        else if (Input.GetKey(KeyCode.S)) { targetThingie.transform.Translate(Vector3.back * Time.deltaTime * kerroin); }
    }
}