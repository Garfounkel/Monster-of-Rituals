using UnityEngine;
using System.Collections;

public class monster_script : MonoBehaviour {

    public bool _moving = true;
    public float _movespeed = 0.05f;
    Vector2 _movedirection;
    private Rigidbody2D _localrigid;
    AudioSource _audio_hardhit;

    // Use this for initialization
    void Start () {
        _audio_hardhit = GetComponent<AudioSource>();
        _localrigid = GetComponent<Rigidbody2D>();   
	}
	
	// Update is called once per frame
	void Update () {


        if (_moving == true)
        {
            _movedirection = new Vector2(

                transform.position.x + _movespeed,
                transform.position.y

                );
            _localrigid.MovePosition(_movedirection);
        }

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
    void OnCollisionEnter2D(Collision2D _coll)
    {
        Debug.Log("CollisionEnter");
       if (_coll.gameObject.tag == "Tentacle")
        
            _moving = false;
        
        if (_coll.relativeVelocity.magnitude > 0.1)
        {
            _audio_hardhit.Play();
            Debug.Log("Magnitude");
        }
           
            

    }

}
