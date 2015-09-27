using UnityEngine;
using System.Collections;

public class RobotDetect : MonoBehaviour {
	private RobotAI robotAI;

	void Start () {
		robotAI = transform.parent.GetComponent<RobotAI>();
	}
	
	void Update () {
	
	}
	
	void OnTriggerEnter (Collider col) {
		robotAI.follow = true;
	}
	
	void OnTriggerExit (Collider col) {
		robotAI.follow = false;
	}
}
