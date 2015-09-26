using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public Rigidbody playerRB;
	public GameObject walker;
	public Rigidbody walkerRB;

	// Use this for initialization
	void Start () {
		playerRB = GetComponent<Rigidbody>();
		walker = GameObject.Find ("Walker");
		walkerRB = walker.GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetAxis ("Vertical") > 0) {
			moveWalker();
			playerRB.AddRelativeForce((new Vector3(0,0,1)), ForceMode.VelocityChange);
			waitForSec(.5f);
			playerRB.AddRelativeForce((new Vector3(0,0,0)), ForceMode.VelocityChange);

		}
	}

	public IEnumerator waitForSec(float time) {
	yield return new WaitForSeconds(time);
	yield break;
	}

	public void moveWalker() {
		playerRB.AddRelativeForce ((new Vector3 (0, 0, 1)), ForceMode.VelocityChange);
		waitForSec(.5f);
		playerRB.AddRelativeForce ((new Vector3 (0, 0, 0)), ForceMode.VelocityChange);
	}

}
