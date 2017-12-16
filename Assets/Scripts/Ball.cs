﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Vector3 launchVeclocity;

	private Rigidbody rigidBody;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();

		Launch ();

	}

	void Launch ()
	{
		rigidBody.velocity = launchVeclocity;
		audioSource.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}