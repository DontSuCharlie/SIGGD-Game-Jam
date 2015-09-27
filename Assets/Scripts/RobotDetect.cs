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
		if (col.gameObject.name == "Player") {
			SendMessageUpwards ("findPlayer");
			robotAI.follow = true;
		}
	}
	
	void OnTriggerExit (Collider col) {
		if (col.gameObject.name == "Player") {
			robotAI.follow = false;
			SendMessageUpwards ("loosePlayer");
		}
	}
}
