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
	public Rigidbody walkerRB;
	public double walkerMoveDist = 5;
	private bool moving;

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
		walkerRB = walker.GetComponent<Rigidbody>();
        leftEarBattery = MaxLeftEarBattery;
        rightEarBattery = MaxRightEarBattery;
        energy = MaxEnergy;
        heartStat = 50;//50 = initial = healthy; 100 = crazy, 0 = death. going past 100 = goes back to 0
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetAxis ("Vertical") > 0 && moving == false) {
			moveWalker();
			//playerRB.AddRelativeForce((new Vector3(0,0,1)), ForceMode.VelocityChange);
			waitForSec(.5f);
			//playerRB.AddRelativeForce((new Vector3(0,0,0)), ForceMode.VelocityChange);

		}
	}

	public IEnumerator waitForSec(float time) {
		yield return new WaitForSeconds(time);
		yield break;
	}

	public void moveWalker() {
		moving = true;
		Vector3 startPos = walker.transform.position;
		walkerRB.AddRelativeForce ((new Vector3 (0, 0, 1)), ForceMode.VelocityChange);
		for (int i = 0; i > 50; i++) {
			if (Vector3.Distance(startPos,walker.transform.position) >= walkerMoveDist) {
				walkerRB.AddRelativeForce ((new Vector3 (0, 0, 0)), ForceMode.VelocityChange);
				moving = false;
				break;
			}
		}
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
