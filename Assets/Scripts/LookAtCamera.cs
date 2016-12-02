using UnityEngine;
using System.Collections;

public class LookAtCamera : MonoBehaviour {
	void Update()
	{
		transform.LookAt(transform.position + 
			Camera.main.transform.rotation * Vector3.forward,
			Vector3.up);
	}
}

