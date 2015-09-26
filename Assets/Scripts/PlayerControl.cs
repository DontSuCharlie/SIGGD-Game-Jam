using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    //for rendering/physics
	public Rigidbody playerRB;
	public GameObject walker;
	public GameObject walkerMoveTarget;
	public Rigidbody walkerRB;
	public bool walk = false;
	public float turnSpeed = 0.2f;
	public float walkSpeed = 0.2f;
	public bool leftBlocked = false;
	public bool rightBlocked = false;
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
			playerRB.AddRelativeForce (new Vector3(0, 0, walkSpeed), ForceMode.VelocityChange);
		} else {
			playerRB.AddForce (Vector3.zero, ForceMode.VelocityChange);
		}
		//player rotation
		if (Input.GetAxis ("Horizontal") > 0) {
			//prevent rotation of something to the right
			/*RaycastHit hit;
			if((Physics.Raycast(walker.transform.TransformPoint(Vector3.zero), walker.transform.TransformDirection(new Vector3(1,0,0)), out hit, 1)) && 
			   (Physics.Raycast(walker.transform.TransformPoint(new Vector3(0,0,-1)), walker.transform.TransformDirection(new Vector3(1,0,0)), out hit, 1))) {
			}
			else {
				transform.Rotate (0, turnSpeed, 0);
			}*/
			if (!rightBlocked) {
				transform.Rotate (0, turnSpeed, 0);
			}
		}
		if (Input.GetAxis ("Horizontal") < 0) {
			//prevent rotation if something to the left
			/*RaycastHit hit;
			if((Physics.Raycast(walker.transform.TransformPoint(Vector3.zero), walker.transform.TransformDirection(new Vector3(-1,0,0)), out hit, 1)) && 
			   (Physics.Raycast(walker.transform.TransformPoint(new Vector3(0,0,-1)), walker.transform.TransformDirection(new Vector3(-1,0,0)), out hit, 1))) {
			}
			else {
				transform.Rotate (0, -turnSpeed, 0);
			}*/
			if (!leftBlocked) {
				transform.Rotate (0, -turnSpeed, 0);
			}
		}

	}

	public void inputHandeling() {
	}

	IEnumerator moveAll() {
		while (true) {
			while (walk) {
				moveWalker ();
				yield return new WaitForSeconds (3);
			}
			yield return new WaitForSeconds (1*0.2f);
		}
	}

	public void moveWalker() {
		walkerRB.AddRelativeForce (new Vector3 (0, 2, 2), ForceMode.Impulse);

	}

	public void movePlayer() {
	}

    public int getEnergy()
    {
        return energy;
    }
    public int getHeartStat()
    {
        return heartStat;
    }
    public int getLeftEarBattery()
    {
        return leftEarBattery;
    }
    public int getRightEarBattery()
    {
        return rightEarBattery;
    }

	void leftIsBlocked() {
		leftBlocked = true;
	}
	void leftIsNotBlocked() {
		leftBlocked = false;
	}
	void rightIsBlocked() {
		rightBlocked = true;
	}
	void rightIsNotBlocked() {
		rightBlocked = false;
	}
    
    //updates heart status based on..??
    //needs to add fixedUpdate for battery life based on actual time instead of frames


}
