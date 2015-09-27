using UnityEngine;
using System.Collections;

public enum Side {
	Left,
	Right
}

public class TurnCollider : MonoBehaviour {
	private PlayerControl controller;
	private Side side = Side.Left;

	void Start () {
		controller = GetComponent<PlayerControl>();
	}
	
	void OnCollisionEnter (Collision col) {
		//if (side == Side.Left) controller.leftIsBlocked();
		//else if (side == Side.Right) controller.rightIsBlocked();
		return;
	}

	void OnCollisionExit (Collision col) {
		//if (side == Side.Left) controller.leftIsNotBlocked();
		//else if (side == Side.Right) controller.rightIsNotBlocked();
		return;
	}
}
