using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	Rigidbody2D rb;
	Vector3 dir = Vector3.zero;
	float angle = 0f;

	// Start is called before the first frame update
	void Start()
    {
		rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		Controls();
    }

	void Controls()
	{
		//Vector3 position = transform.position;
		////Vector3 position = Vector3.zero;

		//if (Input.GetKey(KeyCode.W))
		//{
		//	position += Vector3.up * Time.fixedDeltaTime * 5;
		//	//rb.MovePosition(transform.position + Vector3.up * Time.fixedDeltaTime);
		//}
		//else if (Input.GetKey(KeyCode.S))
		//{
		//	position += Vector3.down * Time.fixedDeltaTime * 5;
		//	//rb.MovePosition(transform.position + Vector3.down * Time.fixedDeltaTime);
		//}

		//if (Input.GetKey(KeyCode.A))
		//{
		//	position += Vector3.left * Time.fixedDeltaTime * 5;
		//	//rb.MovePosition(transform.position + Vector3.left * Time.fixedDeltaTime);
		//}
		//else if (Input.GetKey(KeyCode.D))
		//{
		//	position += Vector3.right * Time.fixedDeltaTime * 5;
		//	//rb.MovePosition(transform.position + Vector3.right * Time.fixedDeltaTime);
		//}

		//rb.MovePosition(position);
		////rb.velocity = position;
		///

		if (Input.GetKey(KeyCode.W))
		{
			transform.position += Vector3.up * Time.fixedDeltaTime * 5;
			//rb.MovePosition(transform.position + Vector3.up * Time.fixedDeltaTime);
		}
		else if (Input.GetKey(KeyCode.S))
		{
			transform.position += Vector3.down * Time.fixedDeltaTime * 5;
			//rb.MovePosition(transform.position + Vector3.down * Time.fixedDeltaTime);
		}

		if (Input.GetKey(KeyCode.A))
		{
			transform.position += Vector3.left * Time.fixedDeltaTime * 5;
			//rb.MovePosition(transform.position + Vector3.left * Time.fixedDeltaTime);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			transform.position += Vector3.right * Time.fixedDeltaTime * 5;
			//rb.MovePosition(transform.position + Vector3.right * Time.fixedDeltaTime);
		}

		dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
