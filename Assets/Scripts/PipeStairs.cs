﻿using System;
using System.Collections;
using UnityEngine;

public class PipeStairs : MonoBehaviour
{
    public Transform exit;
    public float TargetZ;
    public ParticleSystem Particles;
    private AudioSource _sound;

    void Start()
    {
        Particles.Stop();
        _sound = Particles.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ControlableBody cb = other.GetComponent<ControlableBody>();
        if (cb != null)
        {
            Particles.transform.position = cb.transform.position;
            Particles.Play();
            StartCoroutine(Teleportation(cb));
        }
    }

    private IEnumerator Teleportation(ControlableBody cb)
    {
        /*
        while (cb.transform.rotation.z > -90 && cb.transform.rotation.z < 90) 
        {
            cb.transform.Rotate(new Vector3(0, 0, Time.deltaTime * 100));
            yield return null;
        }
        */

        //cb.gameObject.SetActive(false);
        // Play sound
        yield return new WaitForSeconds(0.5f);
        //cb.gameObject.SetActive(true);
        //float y = cb.transform.position.y;
        float y = exit.position.y;
        cb.transform.position = new Vector2(exit.position.x, y);
        Particles.transform.position = cb.transform.position;
        _sound.Play();
        _sound.time = 0.05f;
        yield return new WaitForSeconds(0.5f);
        Particles.Stop();
    }
}
