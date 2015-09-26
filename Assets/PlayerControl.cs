using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public Rigidbody playerRB;
	public GameObject walker;
	public GameObject walkerMoveTarget;
	public Rigidbody walkerRB;
	public float walkerMoveWait = 5f;
	public bool walk = false;
	//public float timer = 0;

	// Use this for initialization
	void Start () {
		playerRB = GetComponent<Rigidbody>();
		walker = GameObject.Find ("Walker");
		walkerMoveTarget = GameObject.Find ("WalkerMoveTarget");
		walkerRB = walker.GetComponent<Rigidbody>();
		//InvokeRepeating ("inputHandeling", 0f, 1f);
		StartCoroutine("moveAll");
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("WalkForward")) {
			walk = true;
		}
		if (Input.GetButtonUp("WalkForward")) {
			walk = false;
		}

	}


	void FixedUpdate() {
		if (Vector3.Distance (transform.position, walkerMoveTarget.transform.position) > 1) {
			playerRB.AddRelativeForce (new Vector3(0, 0, 0.2f), ForceMode.VelocityChange);
		} else {
			playerRB.AddForce (Vector3.zero, ForceMode.VelocityChange);
		}
	}

	public void inputHandeling() {
	}

	IEnumerator moveAll() {
		while (true) {
			while (walk) {
				moveWalker ();
				yield return new WaitForSeconds (2);
				movePlayer ();
				yield return new WaitForSeconds (2);
			}
			yield return new WaitForSeconds (1);
		}
	}
	
	/*IEnumerator moveWalkerDelay(float time) {
		yield return new WaitForSeconds(time);
		movingWalker = false;
		yield break;
	}

	IEnumerator movePlayerDelay(float time) {
		yield return new WaitForSeconds(time);
		movingPlayer = false;
		yield break;
	}
	IEnumerator moveBothDelay(float time) {
		yield return new WaitForSeconds(time);
		movingBoth = false;
		yield break;
	}
	*/
	public void moveWalker() {
		walkerRB.AddRelativeForce (new Vector3 (0, 2, 2), ForceMode.Impulse);
		//StartCoroutine (moveWalkerDelay (walkerMoveWait));
	}

	public void movePlayer() {
		//playerRB.MovePosition (walkerMoveTarget.transform.position);
		/*Vector3 moveForce = transform.InverseTransformPoint(walkerMoveTarget.transform.position);
		Debug.Log (moveForce);
		moveForce.z = moveForce.z * Vector3.Distance (transform.position, walkerMoveTarget.transform.position);
		moveForce.x = moveForce.x * Vector3.Distance (transform.position, walkerMoveTarget.transform.position);
		moveForce.y = moveForce.y * Vector3.Distance (transform.position, walkerMoveTarget.transform.position);
		playerRB.AddForce(moveForce, ForceMode.VelocityChange);*/
		//Vector3 moveForce = (walker.transform.position - transform.position);
		//playerRB.AddForce (moveForce, ForceMode.Impulse);
		//playerRB.AddRelativeForce (new Vector3 (0, 0, 3), ForceMode.Impulse);
		//StartCoroutine (movePlayerDelay (walkerMoveWait));		
	}


}
