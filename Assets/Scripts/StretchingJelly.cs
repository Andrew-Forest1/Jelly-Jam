using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchingJelly : MonoBehaviour
{
	public GameObject holdPosition;
	public Vector3 stickPosition;
	float distance = 1f;
	float angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.position = (holdPosition.transform.position + stickPosition) / 2;
		angle = Mathf.Atan2(holdPosition.transform.position.y - stickPosition.y, holdPosition.transform.position.x - stickPosition.x) * Mathf.Rad2Deg + 90;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		distance = Vector3.Distance(holdPosition.transform.position, stickPosition);
		transform.localScale = new Vector3(1, distance / 2, 1);
	}
}
