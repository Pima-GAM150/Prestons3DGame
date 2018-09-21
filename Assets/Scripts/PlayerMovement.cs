using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public new Transform transform;
    public Rigidbody rb;
    public SphereCollider sc;
    public float jumpPower;
    public float speed;
    public float horizSpeed;
    public float maxSpeed;

    private Vector3 jump = new Vector3(0f, 2f, 0f);
    private bool isGrounded;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {
        GoForward();
        Debug.Log("Jump is " + Input.GetButtonDown("Jump"));
        if (Input.GetButtonDown("Jump") == true && isGrounded)
        {
            Jump(rb, jump, jumpPower);
        }
        if(Input.GetAxis("Horizontal") != 0)
        {
            transform.position = new Vector3((transform.position.x + (Input.GetAxis("Horizontal") * horizSpeed * Time.deltaTime)), transform.position.y, transform.position.z);
        }

        
	}

    void GoForward ()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, (transform.position.z + (speed * Time.deltaTime)));

        if (speed <= maxSpeed){
            speed += Time.deltaTime; 
           }
    }

    void Jump(Rigidbody rb, Vector3 direction, float x)
    {
        rb.AddForce(direction * jumpPower, ForceMode.Impulse);
    }

    //This function updates the isGrounded variable when the player lands after a jump.
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }

        if(collision.gameObject.tag == "obstacle")
        {
            Crashed();
        }
    }

    //This function updates the isGrounded variable to false when the player jumps, 
    //not allowing for another jump.
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            isGrounded = false;
        }
    }

    void Crashed()
    {

    }
}
