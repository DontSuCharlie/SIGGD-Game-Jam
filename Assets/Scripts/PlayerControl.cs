using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    //Constants
    //maximum values for your player's stats
    private const int MaxEnergy = 100;
    private const int MaxLeftEarBattery = 100;
    private const int MaxRightEarBattery = 100;

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

    //player's stats
    private int leftEarBattery;//battery life of left ear
    private int rightEarBattery;//battery life of right ear
    private int heartStat;//status of heart, higher = heart attack and shizz, lower = heart dying and shizz
    //heartStat caps at 100, if it goes above 100, it goes back to 0 to signify death. (mod it)
    //private int heartRate_amplitude;//amplitude of heart monitor
    //private int heartRate_period;//period of the heart monitor
    private int energy;//amount of energy, 0 = no more energy, 100 = full energy

	// Use this for initialization
	void Start () {
		playerRB = GetComponent<Rigidbody>();
		walker = GameObject.Find ("Walker");
		walkerMoveTarget = GameObject.Find ("WalkerMoveTarget");
		walkerRB = walker.GetComponent<Rigidbody>();
		//InvokeRepeating ("inputHandeling", 0f, 1f);
		StartCoroutine("moveAll");
        leftEarBattery = MaxLeftEarBattery;
        rightEarBattery = MaxRightEarBattery;
        energy = MaxEnergy;
        heartStat = 50;//50 = initial = healthy; 100 = crazy, 0 = death. going past 100 = goes back to 0
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
			yield return new WaitForSeconds (1);
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
