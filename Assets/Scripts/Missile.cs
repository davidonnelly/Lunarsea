﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {
	public float speed;
	float variable;

	public GameObject particles;

	// Use this for initialization
	void Start () {
		Init ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 forward = new Vector3 (transform.position.x + -speed, transform.position.y + Mathf.Sin (Time.time / variable) );
		transform.position = Vector2.MoveTowards(transform.position, forward, speed * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			other.gameObject.GetComponent<Boat> ().TakeDamage ();
			AudioController.controller.PlayMissileSound ();
			Instantiate (particles,transform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer ("Water")) {
			Destroy (gameObject);
		}
	}

	void Init()
	{
		variable = Random.Range (.1f, .5f);
		speed = Random.Range (3, 6);
	}
}
