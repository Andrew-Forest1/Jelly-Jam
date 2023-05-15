using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plat : MonoBehaviour
{
	//Collider col;

	//   // Start is called before the first frame update
	//   void Start()
	//   {
	//	col = transform.GetComponent<Collider>();
	//   }

	//   // Update is called once per frame
	//   void Update()
	//   {

	//   }

	//private void OnCollisionEnter(Collision collision)
	//{
	//	Debug.Log(collision.transform.position.y < transform.position.y);
	//	if (collision.transform.position.y < transform.position.y)
	//	{
	//		StartCoroutine(IgnoreCol(collision));
	//	}
	//}

	//IEnumerator IgnoreCol(Collision collision)
	//{
	//	Physics.IgnoreCollision(collision.collider, col, true);
	//	yield return new WaitForSecondsRealtime(.15f);
	//	Physics.IgnoreCollision(collision.collider, col, false);
	//}

	Rigidbody rb;

	public float maxDistance;

	public Vector3 boxSize;

	public LayerMask layerMask;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		PlatformCheck();
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawCube(transform.position - transform.up + transform.up * maxDistance, boxSize);
	}

	public void PlatformCheck()
	{
		if(Physics.BoxCast(transform.position - transform.up, boxSize, transform.up, transform.rotation, maxDistance, 1 << 8))
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
