using UnityEngine;
using System.Collections;

public class FleeFromPlayer : MonoBehaviour {

    public float TriggerDistance = 10;
    public float Speed = 0.01f;
    public float RandomWiggle = 1;
    private Transform _player;

    // Use this for initialization
    void Start () {
        _player = GameObject.Find("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
	    if (_player && Mathf.Abs(_player.transform.position.x - transform.position.x) < TriggerDistance)
	    {
	        transform.position += transform.up * Speed;
	        //transform.eulerAngles.Set(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + Random.Range(-RandomWiggle, RandomWiggle));
	        transform.Rotate(0, 0, Random.Range(-RandomWiggle, RandomWiggle));
	    }
    }
}
