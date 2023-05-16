using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour
{
	JellyController jelly;
	Rigidbody2D rb;
	public float jumpForce = 10f;
	NewDetectGround groundDetection;
	NewHookShot hookshot;
	public float maxSpeed = 5f;
	public float acceration = 3f;

	// Start is called before the first frame update
	void Start()
	{
		jelly = GetComponent<JellyController>();
		rb = GetComponent<Rigidbody2D>();
		groundDetection = GetComponent<NewDetectGround>();
		hookshot = GetComponent<NewHookShot>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (jelly.canMove)
		{
			MoveControls();
		}

		//Debug.Log(rb.velocity);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && groundDetection.GroundCheck())
		{
			rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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
			if (rb.velocity.x > -1 * maxSpeed || hookshot.grappling)
			{
				rb.AddForce(-1 * transform.right * acceration, ForceMode2D.Impulse);
			}
			else
			{
				rb.velocity = new Vector2(-1 * maxSpeed, rb.velocity.y);
			}
			//transform.position += Vector3.left * Time.fixedDeltaTime * 5;
		}
		else if (Input.GetKey(KeyCode.D))
		{
			if (rb.velocity.x < maxSpeed || hookshot.grappling)
			{
				rb.AddForce(transform.right * acceration, ForceMode2D.Impulse);
			}
			else
			{
				rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
			}
			//transform.position += Vector3.right * Time.fixedDeltaTime * 5;
		}

		if (Input.GetKey(KeyCode.S))
		{
			MoveThroughPlatform();
		}



	}

	void MoveThroughPlatform()
	{
		if (groundDetection.PlatformCheck())
		{
			StartCoroutine(PhaseThroughPlatforms());
		}
	}

	IEnumerator PhaseThroughPlatforms()
	{
		Physics2D.IgnoreLayerCollision(6, 8, true);
		yield return new WaitForSecondsRealtime(.15f);
		Physics2D.IgnoreLayerCollision(6, 8, false);
	}
}
