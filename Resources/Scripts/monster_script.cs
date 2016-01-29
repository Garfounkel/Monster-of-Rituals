using UnityEngine;
using System.Collections;

public class monster_script : MonoBehaviour {

    
    public float _movespeed = 0.05f;
    Vector2 _movedirection;
    private Rigidbody2D _localrigid;

	// Use this for initialization
	void Start () {

        _localrigid = GetComponent<Rigidbody2D>();   
	}
	
	// Update is called once per frame
	void Update () {

        _movedirection = new Vector2(

            transform.position.x + _movespeed,
            transform.position.y

            );
        _localrigid.MovePosition( _movedirection);

	}
}
