using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDetectGround : MonoBehaviour
{
	public float maxDistance;

	public Vector2 boxSize;

	public LayerMask layerMask;

	// Start is called before the first frame update
	private void FixedUpdate()
	{
		PlatformCheckUp();
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawCube(transform.position - transform.up * maxDistance, boxSize);
		Gizmos.color = Color.blue;
		Gizmos.DrawCube(transform.position + transform.up * maxDistance, boxSize);
	}

	public bool GroundCheck()
	{
		//Debug.Log(Physics2D.OverlapBox())
		//Debug.Log(Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.down, maxDistance, (1 << 7 | 1 << 8)).Length);
		return Physics2D.BoxCast(transform.position, boxSize, 0, Vector2.down, maxDistance, (1 << 7 | 1 << 8)).collider != null;//Physics2D.BoxCast(transform.position + transform.up, boxSize, -1 * transform.up, transform.rotation, maxDistance, (1 << 7 | 1 << 8));
	}

	public bool PlatformCheck()
	{
		RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxSize, 0, Vector2.down, maxDistance, 1 << 8);
		return hit.collider != null;
	}

	public void PlatformCheckUp()
	{
		//Debug.Log();
		if (Physics2D.BoxCast(transform.position, boxSize, 0, Vector2.up, maxDistance, 1 << 8).collider != null)
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
