using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJellyStretch2 : MonoBehaviour
{
	public float stretchDistance = 5f;
	public float stretchDuration = .5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(0))
		{
			Stretch();
		}
    }

	void Stretch()
	{
		if(transform.localScale.x < stretchDistance)
		{
			transform.localScale += Vector3.right * stretchDistance * Time.deltaTime / stretchDuration;
		}
	}
}
