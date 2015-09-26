using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    //for rendering/physics
	private Rigidbody playerRB;
	private GameObject walker;
	private GameObject walkerMoveTarget;
	private Rigidbody walkerRB;
	private GameObject cam;
	private bool walk = false;
	public float turnSpeed = 0.2f;
	public float walkSpeed = 0.2f;
	private bool leftBlocked = false;
	private bool rightBlocked = false;
	//public float timer = 0;

	// Use this for initialization
	void Start () {
		playerRB = GetComponent<Rigidbody>();
		walker = GameObject.Find ("Walker");
		walkerMoveTarget = GameObject.Find ("WalkerMoveTarget");
		walkerRB = walker.GetComponent<Rigidbody>();
		cam = GameObject.Find ("PlayerCam");
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
		if (Input.GetButtonDown("Grab")) {
			RaycastHit hit;
			if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(0,0,1))) {
			}
		}

	}


	void FixedUpdate() {
		if (Vector3.Distance (transform.position, walkerMoveTarget.transform.position) > 1) {
			playerRB.AddRelativeForce (new Vector3(0, 0, walkSpeed), ForceMode.VelocityChange);
		} else {
			playerRB.AddForce (Vector3.zero, ForceMode.VelocityChange);
		}
		//--player rotation--
		//turn right
		if (Input.GetAxis ("Horizontal") > 0) {

			if (!rightBlocked) {
				transform.Rotate (0, turnSpeed, 0);
			}
		}
		//turn left
		if (Input.GetAxis ("Horizontal") < 0) {

			if (!leftBlocked) {
				transform.Rotate (0, -turnSpeed, 0);
			}
		}
		//--camera rotation--
		float yRot = cam.transform.localRotation.eulerAngles.y;
		float xRot = cam.transform.localRotation.eulerAngles.x;
		float newYRot = Input.GetAxis("Mouse X")  + yRot;
		float newXRot = (-Input.GetAxis("Mouse Y"))  + xRot;
		//Debug.Log (newYRot);
		Debug.Log (Input.GetAxis ("Mouse Y"));
		//limit horizontal rotation
		if ((newYRot > 90 && newYRot < 275) || (newYRot > 180 && newYRot < 90)) {
			//Debug.Log (newYRot);
			newYRot = yRot;
		}
		//limit vertical rotation
		if ((newXRot > 50 && newXRot < 180) || (newXRot < 340 && newXRot > 275)) {
			//Debug.Log (newXRot);
			newXRot = xRot;
		}
		cam.transform.localEulerAngles = new Vector3 (newXRot, newYRot, 0);
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

    /*public int getEnergy()
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
    }*/

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
