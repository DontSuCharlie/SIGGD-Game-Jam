using UnityEngine;
using System.Collections;

public class RobotAI : MonoBehaviour {
	public Transform player;
	public float fov = 60;
	
	public Transform patrolPointSet;
	private Transform[] patrolPoints;
	public float patrolPointReachedThreshold = 1.0f;
	private int currentPoint = 0;
	
	private NavMeshAgent agent;
	
	public bool follow;
	
	void Start () {
 		agent = GetComponent<NavMeshAgent>();
		patrolPoints = patrolPointSet.GetComponentsInChildren<Transform>();
	}
	
	void Update () {
		if (player == null) {
			follow = false;
			Debug.LogWarning("No player to follow.");
		}
		
		if (player != null && (follow || IsPlayerInView())) {
			agent.destination = player.position;
		} else {
			if (Vector3.Distance(transform.position, patrolPoints[currentPoint].position) < patrolPointReachedThreshold) {
				currentPoint++;
				if (currentPoint >= patrolPoints.Length) {
					currentPoint = 0;
				}
			}
			agent.destination = patrolPoints[currentPoint].position;
		}
	}
	
	
	
	bool IsPlayerInView () {
		if (Vector3.Angle(player.position - transform.position, transform.forward) < fov) {
			RaycastHit hitInfo = new RaycastHit();
			return Physics.Linecast(transform.position, player.position, out hitInfo);
		} else {
			return false;
		}
	}

	public void findPlayer() {
		player = GameObject.Find ("Player").transform;
	}
	public void loosePlayer() {
		player = null;
	}
}
