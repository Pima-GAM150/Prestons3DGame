using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Transform transform;
    public float jumpPower;
    public float speed;
    public float maxSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GoForward();    
	}

    void GoForward ()
    {
        transform.position = new Vector3((transform.position.x + (speed * Time.deltaTime)), transform.position.y);

        if (speed <= maxSpeed){
            speed += Time.deltaTime; 
           }
    }

}
