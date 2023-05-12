using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectGround : MonoBehaviour
{
	Rigidbody rb;

	public float maxDistance;

	public Vector3 boxSize;

	public LayerMask layerMask;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawCube(transform.position + transform.up - transform.up * maxDistance, boxSize);
	}

	public bool GroundCheck()
	{
		//Debug.Log(Physics.BoxCast(transform + transform.up, boxSize, -1 * transform.up, transform.rotation, maxDistance, layerMask));
		return Physics.BoxCast(transform.position + transform.up, boxSize, -1 * transform.up, transform.rotation, maxDistance, layerMask);
	}
}
