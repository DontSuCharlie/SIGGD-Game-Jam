﻿using UnityEngine;
using System.Collections;

public class KillOnContact : MonoBehaviour {
	private RobotAI ai;

	void Start () {
		ai = transform.parent.GetComponent<RobotAI>();
	}

	void OnTriggerEnter (Collider col) {
		if (col.transform.gameObject == ai.player.gameObject) {
			ai.player.SendMessage("kill");
		}
	}
}
