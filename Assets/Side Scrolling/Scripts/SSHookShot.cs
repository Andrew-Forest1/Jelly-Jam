using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSHookShot : MonoBehaviour
{
	public float distance = 5f;
	public float cd = 1.5f;
	bool offCooldown = true;
	Vector3 grapplePoint = Vector3.zero;
	public bool grappling = false;
	public float grappleSpeed = 5f;
	LineRenderer line;
	Rigidbody rb;
	float length;
	HingeJoint hinge = null;

	// Start is called before the first frame update
	void Start()
	{
		line = GetComponent<LineRenderer>();
		rb = transform.GetComponent<Rigidbody>();
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

		RaycastHit hit;

		//line.SetPosition(0, transform.position);
		//line.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
		Vector3 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		dir = new Vector3(dir.x, dir.y, 0);

		Debug.DrawRay(transform.position, dir, Color.red, 1f);
		//Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));

		if (Physics.Raycast(transform.position, dir, out hit, distance, 1 << 9))
		{
			grapplePoint = hit.point;
			grappling = true;
			length = Vector3.Distance(transform.position, hit.point);
			hinge = transform.gameObject.AddComponent<HingeJoint>();
			hinge.connectedBody = hit.rigidbody;
			hinge.autoConfigureConnectedAnchor = false;
			hinge.axis = Vector3.forward;
			hinge.anchor = new Vector3(0, length, 0);
			rb.freezeRotation = false;
		}
	}

	void ExecuteHookShot()
	{
		//Physics.box
		Debug.Log(Physics.CheckBox(transform.position, Vector3.one, transform.rotation, (1 << 7 | 1 << 8)));
		
		if (Input.GetKey(KeyCode.W) && hinge.anchor.y > 0)
		{
			if(!Physics.CheckBox(transform.position + transform.up * .5f, Vector3.one * .5f, transform.rotation, (1 << 7 | 1 << 8)))
			{
				hinge.anchor -= Vector3.up * grappleSpeed * Time.deltaTime;
			}
		}
		else if (Input.GetKey(KeyCode.S) && hinge.anchor.y < distance)
		{
			if (!Physics.CheckBox(transform.position - transform.up * .5f, Vector3.one * .5f, transform.rotation, (1 << 7 | 1 << 8)))
			{
				hinge.anchor += Vector3.up * grappleSpeed * Time.deltaTime;
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
