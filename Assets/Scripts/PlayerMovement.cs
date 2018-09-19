using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public new Transform transform;
    public float jumpPower;
    public float speed;
    public float horizSpeed;
    public float maxSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GoForward();
        Debug.Log("Horizontal is at " + Input.GetAxis("Horizontal"));
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

    void MoveHorizontal()
    {
        
    }

    void Jump(float x)
    {

    }

    void Crashed()
    {

    }
}
