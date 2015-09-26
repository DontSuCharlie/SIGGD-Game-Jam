using UnityEngine;
using System.Collections;

public class HeartMonitorAnim : MonoBehaviour {
    private Vector3 currentPos;
    private int health_slope;
    private int health_amp;
    private const int maxHeight = 120;
    private const int maxWidth = 200;
    private const int initialX = 0;
    private const int initialY = 50;
    private const int initialZ = 0;
	// Use this for initialization
	void Start () {
        health_slope = 60;
        health_amp = 60;
        currentPos = new Vector3(initialX, initialY, initialZ);
	}
	
	// Update is called once per frame
	void Update () {
        //goes from point A.x to point B.x
        //everytime it hits point B.x, it goes back to point A.x
        //it's position in y could fluctuate, but it's speed in x is always constant
        //if y goes up, it has to go down in the negative direction until it hits the bottom
        currentPos.x += 3;
        if (currentPos.x >= maxWidth)
            currentPos.x = initialX;
        if (Mathf.Abs(currentPos.y) >= health_amp)
            health_slope = -health_slope;
        gameObject.transform.position = currentPos;
	}
}
