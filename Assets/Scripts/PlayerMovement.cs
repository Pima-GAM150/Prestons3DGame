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
    public bool crashed = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (crashed == false) { 
            Debug.Log("Jump is " + Input.GetButtonDown("Jump"));
            if (Input.GetButtonDown("Jump") == true && isGrounded == true)
            {
                rb.AddForce(jump * jumpPower, ForceMode.Impulse);
            }
            if (Input.GetAxis("Horizontal") != 0)
            {
                transform.position = new Vector3((transform.position.x + (Input.GetAxis("Horizontal") * horizSpeed * Time.deltaTime)), transform.position.y, transform.position.z);
            }
            GoForward();
        }
    }

    void GoForward ()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, (transform.position.z + (speed * Time.deltaTime)));

        if (speed <= maxSpeed){
            speed += Time.deltaTime; 
           }
    }

    //This function updates the isGrounded variable when the player lands after a jump.
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        if(collision.gameObject.tag == "Obstacle")
        {
            Crashed();
        }
    }

    //This function updates the isGrounded variable to false when the player jumps, 
    //not allowing for another jump.
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    void Crashed()
    {
        speed = 0f;
        crashed = true;
    }
}
