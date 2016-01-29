using UnityEngine;
using System.Collections;

public class monster_spawner_script : MonoBehaviour {

    int _spawntimer = 0;
    Vector2 _spawnerposition;

    public GameObject _monsterprefab;
    
	// Use this for initialization
	void Start () {

      

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        _spawnerposition = new Vector2(
            transform.position.x,transform.position.y
            );
      

        
        if (_spawntimer >= 20)
        {
            GameObject _Monster = Instantiate(_monsterprefab);
            _Monster.name = "Monster";
            _Monster.transform.position = Random.insideUnitCircle * 2 + _spawnerposition;

            _spawntimer = 0;
            Debug.Log("Spawn");
        }


        _spawntimer += 1;

    }
}
