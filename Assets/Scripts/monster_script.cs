﻿using System;
using UnityEngine;
using System.Collections;

public class monster_script : MonoBehaviour {

    public bool _moving = true;
    public bool _movingRight = true;
    public float Acceleration = 5;
    public float MaxVelocity = 5;
    public float BounceForce = 5;
    private Rigidbody2D _localrigid;
    AudioSource _audio_hardhit;

    // Use this for initialization
    void Start () {
        _audio_hardhit = GetComponent<AudioSource>();
        _localrigid = GetComponent<Rigidbody2D>();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAngry>();
    }
	
	// Update is called once per frame
	void Update () {


        if (_moving)
        {
            if (_localrigid.velocity.x < MaxVelocity) _localrigid.AddForce(new Vector2((_movingRight ? 1 : -1) * Acceleration, 0));
        }
        
        //if (transform.position.y < -8 || Mathf.Abs(transform.position.x) > 12) Destroy(gameObject);

	}
   /* void OnTriggerEnter2D(Collider2D _other)
    {
        Debug.Log("TriggerEnter");
        if (_other.tag == "Tentacle")
        {
            _moving = false;
        }
        
    }*/
    public void HitByTentacle()
    {


    }

    private void OnCollisionEnter2D(Collision2D _coll)
    {
        //Debug.Log("CollisionEnter");
        if (_coll.gameObject.tag == "Tentacle")

            _moving = false;

        if (_coll.relativeVelocity.magnitude > 0.1)
        {
            //_audio_hardhit.Play();
            //Debug.Log("Magnitude");
        }

        if (_coll.gameObject.tag == "Player")
        {
            PlayerAngry.MoreAngry();
            _localrigid.AddForce(new Vector2((_movingRight ? -1 : 1), 1) * BounceForce,ForceMode2D.Impulse);
        }

    }

}
