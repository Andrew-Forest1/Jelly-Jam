using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHookShot : MonoBehaviour
{
	public float distance = 10f;
	public float cd = .15f;
	bool offCooldown = true;
	Vector2 grapplePoint = Vector2.zero;
	public bool grappling = false;
	public float grappleSpeed = 5f;
	LineRenderer line;
	Rigidbody2D rb;
	float length;
	HingeJoint2D hinge = null;

	// Start is called before the first frame update
	void Start()
	{
		line = GetComponent<LineRenderer>();
		rb = transform.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(1) && offCooldown && !grappling)
		{
			StartHookShot();
		}

		if (grappling)
		{
			ExecuteHookShot();
			if (Input.GetMouseButtonDown(1) && offCooldown)
			{
				StopHookShot();
			}
		}
	}

	void StartHookShot()
	{
		StartCoroutine(CoolDown());

		

		//line.SetPosition(0, transform.position);
		//line.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
		Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

		Debug.DrawRay(transform.position, dir, Color.red, 1f);
		
		RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, distance, 1 << 9);
		//Debug.Log(dir);
		//Debug.Log(Physics2D.RaycastAll(new Vector2(transform.position.x, transform.position.y), new Vector2(dir.x, dir.y)).Length);
		if (hit.collider != null)
		{
			grapplePoint = hit.point;
			grappling = true;
			length = Vector2.Distance(transform.position, hit.point);
			hinge = transform.gameObject.AddComponent<HingeJoint2D>();
			hinge.connectedBody = hit.rigidbody;
			hinge.autoConfigureConnectedAnchor = false;
			hinge.anchor = new Vector2(0, length);
			hinge.connectedAnchor = Vector2.zero;
			rb.freezeRotation = false;
		}
	}

	void ExecuteHookShot()
	{
		//Physics.box
		//Debug.Log(Physics.CheckBox(transform.position, Vector3.one, transform.rotation, (1 << 7 | 1 << 8)));

		if (Input.GetKey(KeyCode.W) && hinge.anchor.y > 0)
		{
			if (!Physics.CheckBox(transform.position + transform.up * .5f, Vector3.one * .5f, transform.rotation, (1 << 7 | 1 << 8)))
			{
				hinge.anchor -= Vector2.up * grappleSpeed * Time.deltaTime;
			}
		}
		else if (Input.GetKey(KeyCode.S) && hinge.anchor.y < distance)
		{
			if (!Physics.CheckBox(transform.position - transform.up * .5f, Vector3.one * .5f, transform.rotation, (1 << 7 | 1 << 8)))
			{
				hinge.anchor += Vector2.up * grappleSpeed * Time.deltaTime;
			}
		}

		line.SetPosition(0, transform.position);
		line.SetPosition(1, grapplePoint);
	}

	void StopHookShot()
	{
		Destroy(hinge);
		grappling = false;
		transform.rotation = Quaternion.identity;
		rb.freezeRotation = true;
		line.SetPosition(0, Vector3.zero);
		line.SetPosition(1, Vector3.zero);
	}

	IEnumerator CoolDown()
	{
		offCooldown = false;
		yield return new WaitForSecondsRealtime(cd);
		offCooldown = true;
	}
}
