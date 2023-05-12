using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMovement : MonoBehaviour
{
	JellyController jelly;
	Rigidbody rb;
	public float jumpForce = 10f;
	DetectGround groundDetection;

    // Start is called before the first frame update
    void Start()
    {
		jelly = GetComponent<JellyController>();
		rb = GetComponent<Rigidbody>();
		groundDetection = GetComponent<DetectGround>();
    }

	// Update is called once per frame
	void FixedUpdate()
	{
		if (jelly.canMove)
		{
			MoveControls();
		}

		//if (jelly.canLook)
		//{
		//	LookControls();
		//}
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && groundDetection.GroundCheck())
		{
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}
	}

	void MoveControls()
	{
		//if (Input.GetKey(KeyCode.W))
		//{
		//	transform.position += Vector3.right * Time.fixedDeltaTime * 5;
		//}
		//else if (Input.GetKey(KeyCode.S))
		//{
		//	transform.position += Vector3.left * Time.fixedDeltaTime * 5;
		//}

		if (Input.GetKey(KeyCode.A))
		{
			transform.position += Vector3.left * Time.fixedDeltaTime * 5;
		}
		else if (Input.GetKey(KeyCode.D))
		{
			transform.position += Vector3.right * Time.fixedDeltaTime * 5;
		}



	}
}
