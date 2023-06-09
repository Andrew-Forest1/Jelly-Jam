using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJellyStretch : MonoBehaviour
{
	public float stretchDistance = 5f;
	public float stretchDuration = .5f;
	bool stretch = false;
	JellyController jelly;

	// Start is called before the first frame update
	void Start()
	{
		jelly = GetComponent<JellyController>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			Stretch();
			jelly.canLook = false;
		}
		else
		{
			Retract();
		}
	}

	void Stretch()
	{
		if (transform.localScale.x < stretchDistance)
		{
			transform.localScale += new Vector3(1 * stretchDistance * Time.deltaTime / stretchDuration, -1 * .777f * Time.deltaTime / stretchDuration, 0);
			//transform.position += new Vector3(Mathf.Cos(Mathf.Deg2Rad * transform.rotation.z) * stretchDistance / 2 * Time.deltaTime / stretchDuration, Mathf.Sin(Mathf.Deg2Rad * transform.rotation.z) * stretchDistance / 2 * Time.deltaTime / stretchDuration, 0);
		}
	}

	void Retract()
	{
		if (transform.localScale.x > 1)
		{
			transform.localScale += new Vector3(-1 * stretchDistance * Time.deltaTime / stretchDuration, 1 * .777f * Time.deltaTime / stretchDuration, 0);
			//transform.position += new Vector3(Mathf.Cos(Mathf.Deg2Rad * transform.rotation.z) * stretchDistance / 2 * Time.deltaTime / stretchDuration, Mathf.Sin(Mathf.Deg2Rad * transform.rotation.z) * stretchDistance / 2 * Time.deltaTime / stretchDuration, 0);
		}
		else
		{
			jelly.canLook = true;
		}
	}
	//public Animator anime;

	//// Start is called before the first frame update
	//void Start()
	//   {
	//	anime = GetComponent<Animator>();
	//}

	//   // Update is called once per frame
	//   void Update()
	//   {
	//	if (Input.GetMouseButtonDown(1))
	//	{
	//		anime.SetBool("Stretch", true);
	//	}
	//}

	//public void Finish()
	//{
	//	anime.SetBool("Stretch", false);
	//}

	//private void OnCollisionEnter2D(Collision2D collision)
	//{
	//	//stretching.stickPosition = collision.contacts[0].point;
	//	anime.Play("Player Jelly Retract", 0, 0);
	//}
}
