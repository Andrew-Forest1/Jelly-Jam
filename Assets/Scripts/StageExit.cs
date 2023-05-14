using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageExit : MonoBehaviour
{
	public GameObject nextStage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
		other.transform.GetComponent<FallReset>().resetPosition = nextStage.transform.position;
		other.transform.position = nextStage.transform.position;
	}
}
