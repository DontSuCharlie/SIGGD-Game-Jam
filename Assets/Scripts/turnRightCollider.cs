using UnityEngine;
using System.Collections;

public class turnRightCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter() {
		SendMessageUpwards("rightIsBlocked");
	}
	void OnTriggerExit() {
		SendMessageUpwards("rightIsNotBlocked");
	}
}
