using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookShotJelly : MonoBehaviour
{
	//public bool held = false;
	Collider2D collider;
	public float throwDistance = 5;
	public float throwSpeed = 5;
	int throwProcess = 0;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent.tag == "Hold Object" && Input.GetMouseButtonDown(1))
		{
			ThrowJelly();
		}
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag != "Player")
		{
			Debug.Log(collision.gameObject.transform.position);
		}
	}

	void ThrowJelly()
	{
		if(throwProcess == 0)
		{
			throwProcess = 1;
		}
	}

	void JellyTravel()
	{
		if(transform.localPosition.x < throwDistance)
		{
			transform.Translate(Vector3.right * throwSpeed * Time.deltaTime);
			//transform.position.x += throwSpeed * Time.deltaTime;
			//transform.localPosition = new Vector3(transform.localPosition.x + throwSpeed * Time.deltaTime, transform.localPosition.y, transform.localPosition.z);
		}
	}
}
