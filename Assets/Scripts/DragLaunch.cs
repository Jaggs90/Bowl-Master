using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {

	private Vector3 dragStart, dragEnd;
	private float startTime, endTime;
	private Ball ball;

	// Use this for initialization
	void Start () {
		ball = GetComponent<Ball>();
	}

	public void MoveStart (float amount){
		if( ! ball.inPlay) {
		ball.transform.Translate (new Vector3 (amount, 0, 0));
		}
	}

	// Update is called once per frame
	public	void DragStart () {
			// capture time and position of the dragstart 
			dragStart = Input.mousePosition;
			startTime = Time.time;
	}

	public	void DragEnd (){
			// lauch the ball
			dragEnd = Input.mousePosition;
			endTime = Time.time;

			float dragDuration = endTime - startTime;

			float launchSpeedX= (dragEnd.x - dragStart.x) / dragDuration;
			float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

			Vector3 launchVelocity = new Vector3 (launchSpeedX, 0, launchSpeedZ);

			ball.Launch (launchVelocity);
	}
}
