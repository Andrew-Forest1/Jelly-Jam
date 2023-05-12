using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallReset : MonoBehaviour
{
	public Vector3 resetPosition = new Vector3(0,0,5);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > 7)
		{
			transform.position = resetPosition;
		}
    }
}
