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
	public float walkerMoveWait = 5f;
	public bool walk = false;
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
    
    //updates heart status based on..??
    //needs to add fixedUpdate for battery life based on actual time instead of frames
}
