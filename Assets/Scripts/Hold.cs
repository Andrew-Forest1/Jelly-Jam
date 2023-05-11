using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hold : MonoBehaviour
{
	public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && obj != null)
		{
			obj.GetComponent<Collider2D>().enabled = true;
			obj.transform.parent = null;
			obj = null;
		}

		if (Input.GetMouseButtonDown(0))
		{
			pickUpJelly();
		}
    }

	void pickUpJelly()
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 origin = new Vector2(mousePos.x, mousePos.y);
		RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.zero, 0f, 1 << LayerMask.NameToLayer("Holdable"));
		if (hit)
		{
			Debug.Log(Vector3.Distance(hit.transform.position, transform.position));
			if (Vector3.Distance(hit.transform.position, transform.position) < 2.5)
			{
				obj = hit.collider.gameObject;
				obj.transform.parent = transform;
				obj.transform.localRotation = Quaternion.Euler(0,0,0);
				obj.transform.localPosition = new Vector3(.25f, 0, 0);
				//obj.GetComponent<Collider2D>().enabled = false;
			}
		}
	}
}
