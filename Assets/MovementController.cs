using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

	protected Joystick joystick;
	protected ControllerTest joybutton;

	float speed = 10.0f;
	float rotationSpeed = 30.0f;


    // Start is called before the first frame update
    void Start()
    {
		joystick = FindObjectOfType<Joystick>();
		joybutton = FindObjectOfType<ControllerTest>();
        
    }

    // Update is called once per frame
    void Update()
    {
		var rigidbody = GetComponent<Rigidbody>();



		float translation = joystick.Vertical * speed;
		float rotation = joystick.Horizontal * rotationSpeed;
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;
		transform.Translate(0, 0, translation);
		transform.Rotate(0, rotation, 0);
		rigidbody.velocity = new Vector3(rotation, rigidbody.velocity.y, translation);
        
    }
}
