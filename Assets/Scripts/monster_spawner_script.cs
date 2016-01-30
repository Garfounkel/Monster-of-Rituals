using UnityEngine;
using System.Collections;
using System.Linq;

public class monster_spawner_script : MonoBehaviour {

    public int MaximumMonsters = 5;

    int _spawntimer = 0;
    Vector2 _spawnerposition;
    private int _monsterCount = 0;

    public GameObject _monsterprefab;
    
	// Use this for initialization
	void Start () {

      

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        _spawnerposition = new Vector2(
            transform.position.x,transform.position.y
            );



        //if (_spawntimer >= 20 && _monsterCount < MaximumMonsters)
        if (_spawntimer >= 20 && GameObject.FindGameObjectsWithTag("Monster").Count() < MaximumMonsters) //Is this slow?
        {
            GameObject _Monster = Instantiate(_monsterprefab);
            _Monster.name = "Monster";
            _Monster.transform.position = Random.insideUnitCircle * 2 + _spawnerposition;

            _spawntimer = 0;
            //Debug.Log("Spawn nr " + GameObject.FindGameObjectsWithTag("Monster").Count());
            //_monsterCount++;
        }


        _spawntimer += 1;

    }
}
