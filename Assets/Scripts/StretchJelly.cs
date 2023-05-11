using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchJelly : MonoBehaviour
{
	public Animator anime;
	public GameObject jelly;
	public bool held = false;
	StretchingJelly stretching;
	Collider2D collider;

	// Start is called before the first frame update
	void Start()
	{
		anime = GetComponent<Animator>();
		collider = GetComponent<Collider2D>();
		stretching = jelly.GetComponent<StretchingJelly>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{
			if (!jelly.active)
			{
				collider.enabled = true;
				anime.SetBool("Stretch", true);
			}
			else
			{
				transform.gameObject.active = true;
				jelly.active = false;
			}
		}
	}

	public void Over()
	{
		collider.enabled = false;
		anime.SetBool("Stretch", false);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		transform.gameObject.active = false;
		jelly.active = true;
		stretching.stickPosition = collision.contacts[0].point;
	}
}
