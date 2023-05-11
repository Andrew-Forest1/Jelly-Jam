using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookShot : MonoBehaviour
{
	public float distance = 5f;
	public float cd = 1.5f;
	bool offCooldown = true;
	Transform player;
	Vector3 grapplePoint = Vector3.zero;
	public bool grappling = false;
	public float grappleSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
		player = transform.parent;
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
		StartCoroutine(CoolDown());

		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.right, out hit, distance))
		{
			grapplePoint = hit.point;
			grappling = true;
		}
	}

	void ExecuteHookShot()
	{
		//Debug.Log(Vector3.Distance(player.position, grapplePoint));

		if(Vector3.Distance(player.position, grapplePoint) > .5f)
		{
			player.position = Vector3.MoveTowards(player.position, grapplePoint, grappleSpeed * Time.deltaTime);
		}
		else
		{
			grappling = false;
		}
	}

	IEnumerator CoolDown()
	{
		offCooldown = false;
		yield return new WaitForSecondsRealtime(cd);
		offCooldown = true;
	}
}
