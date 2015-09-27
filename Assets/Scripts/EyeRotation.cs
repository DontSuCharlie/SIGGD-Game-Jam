using UnityEngine;
using System.Collections;

public class EyeRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		float zRot = transform.localRotation.eulerAngles.z + 1;
		//transform.localEulerAngles = new Vector3 (0, 0, zRot);
		transform.Rotate(transform.InverseTransformPoint(new Vector3(0,0,zRot)));
		//tranform.local
	}
}
