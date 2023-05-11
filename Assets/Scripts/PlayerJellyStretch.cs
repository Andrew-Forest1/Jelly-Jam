using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJellyStretch : MonoBehaviour
{
	public float stretchDistance = 5f;
	public float stretchDuration = .5f;
	bool stretch = false;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			stretch = true;
		}
		if (stretch)
		{
			Stretch();
		}
	}

	void Stretch()
	{
		if (transform.localScale.x < stretchDistance)
		{
			transform.localScale += Vector3.right * stretchDistance * Time.deltaTime / stretchDuration;
			//transform.position += new Vector3(Mathf.Cos(Mathf.Deg2Rad * transform.rotation.z) * stretchDistance / 2 * Time.deltaTime / stretchDuration, Mathf.Sin(Mathf.Deg2Rad * transform.rotation.z) * stretchDistance / 2 * Time.deltaTime / stretchDuration, 0);
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
