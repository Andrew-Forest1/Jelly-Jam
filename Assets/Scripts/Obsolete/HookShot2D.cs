using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookShot2D : MonoBehaviour
{
	public float distance = 5f;
	public float cd = 1.5f;
	bool offCooldown = true;
	Transform player;
	Vector3 grapplePoint = Vector3.zero;
	public bool grappling = false;
	public float grappleSpeed = 5f;
	LineRenderer line;
	Rigidbody rb;

	// Start is called before the first frame update
	void Start()
	{
		player = transform.parent;
		line = GetComponent<LineRenderer>();
		rb = transform.parent.GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(1) && offCooldown)
		{
			StartHookShot();
		}

		if (grappling)
		{
			ExecuteHookShot();
		}
	}

	void StartHookShot()
	{
		Debug.Log("Hook Shot");
		StartCoroutine(CoolDown());

		RaycastHit hit;

		if (Physics.Raycast(new Vector2(transform.position.x, transform.position.y), new Vector2(transform.right.x, transform.right.y), out hit, distance))
		{
			grapplePoint = hit.point;
			grappling = true;
		}
	}

	void ExecuteHookShot()
	{
		Debug.Log(Vector3.Distance(player.position, grapplePoint));

		if (Vector3.Distance(player.position, grapplePoint) > .5f)
		{
			player.position = Vector3.MoveTowards(player.position, grapplePoint, grappleSpeed * Time.deltaTime);
			line.SetPosition(0, transform.position);
			line.SetPosition(1, grapplePoint);
			rb.useGravity = false;
		}
		else
		{
			grappling = false;
			line.SetPosition(0, Vector3.zero);
			line.SetPosition(1, Vector3.zero);
			rb.useGravity = true;
		}
	}

	IEnumerator CoolDown()
	{
		offCooldown = false;
		yield return new WaitForSecondsRealtime(cd);
		offCooldown = true;
	}
}
