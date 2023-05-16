using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMovement : MonoBehaviour
{
	JellyController jelly;
	Rigidbody rb;
	public float jumpForce = 10f;
	DetectGround groundDetection;
	public float maxSpeed = 5f;
	public float dragComp = 1f;

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
		Debug.Log(rb.velocity);
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
			if(rb.velocity.x > -1 * maxSpeed)
			{
				rb.velocity += Vector3.left * maxSpeed * Time.fixedDeltaTime * dragComp;
			}
			//transform.position += Vector3.left * Time.fixedDeltaTime * 5;
		}
		else if (Input.GetKey(KeyCode.D))
		{
			if (rb.velocity.x < maxSpeed)
			{
				rb.velocity += Vector3.right * maxSpeed * Time.fixedDeltaTime * dragComp;
			}
			//transform.position += Vector3.right * Time.fixedDeltaTime * 5;
		}
		else
		{
			if (rb.velocity.x < maxSpeed)
			{
				rb.velocity -= Vector3.left * maxSpeed * Time.fixedDeltaTime;
			}
			if (rb.velocity.x > -1 * maxSpeed)
			{
				rb.velocity -= Vector3.right * maxSpeed * Time.fixedDeltaTime;
			}
		}

		if (Input.GetKey(KeyCode.S))
		{
			MoveThroughPlatform();
		}



	}

	void MoveThroughPlatform()
	{
		if(groundDetection.PlatformCheck() != null)
		{
			StartCoroutine(PhaseThroughPlatforms());
		}
	}

	IEnumerator PhaseThroughPlatforms()
	{
		Physics.IgnoreLayerCollision(6, 8, true);
		yield return new WaitForSecondsRealtime(.15f);
		Physics.IgnoreLayerCollision(6, 8, false);
	}
}
