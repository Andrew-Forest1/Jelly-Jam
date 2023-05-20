using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
	public GameObject teleportToGameObject;
	public bool ready = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (ready)
		{
			//StartCoroutine(teleportToGameObject.transform.GetComponent<Teleport>().CoolDown());
			collision.transform.position = teleportToGameObject.transform.position;
		}
	}

	IEnumerator CoolDown()
	{
		ready = false;
		yield return new WaitForSecondsRealtime(1.5f);
		ready = true;
	}
}
