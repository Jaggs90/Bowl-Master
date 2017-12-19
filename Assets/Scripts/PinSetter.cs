using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PinSetter : MonoBehaviour {

	private Ball ball;
	private float lastChangeTime;
	private bool ballEnteredBox;

	public GameObject pinSet;
	public Text standingDisplay;
	public int lastStandingCount = -1;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding ().ToString ();

		if (ballEnteredBox){
		UpdateStandingCountAndSettle();
		}
	}

	public void RaisePins () {
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			pin.RaiseIfStanding();

		}
	}

	public void LowerPins() {
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
		pin.Lower();
		}
	}
	public void RenewPins (){
		Debug.Log("Renewing pins");
		Instantiate (pinSet, new Vector3 (0, 0, 1829), Quaternion.identity);
	}

	void UpdateStandingCountAndSettle() {
		int currentStanding = CountStanding	();
		if (currentStanding != lastStandingCount) {
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}

		float settleTime = 3f; // how long to wait to consider pins settled
		if ((Time.time - lastChangeTime) > settleTime) { // if last change > 3s ago
			PinsHaveSettled();

		}
	}

	void PinsHaveSettled (){
		ball.Reset ();
		lastStandingCount = -1; // Indicates pins have settled, and ball not back in box
		ballEnteredBox = false;
		standingDisplay.color = Color.green;
	}

	int CountStanding () {
		int standing = 0;

		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()) {
			if (pin.IsStanding()) {
				standing++;
			}
		}

		return standing;
	}

	void OnTriggerEnter (Collider collider){
		GameObject thingHit = collider.gameObject;

		//bool enters play box
		if (thingHit.GetComponent<Ball> ()) {
			ballEnteredBox = true;
			standingDisplay.color = Color.red;
		}

	}
}
