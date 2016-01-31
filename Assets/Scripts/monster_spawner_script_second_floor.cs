using UnityEngine;
using System.Collections;
using System.Linq;

public class monster_spawner_script_second_floor : MonoBehaviour {

    public int MaximumMonsters = 5;
    public bool SpawnRight = true;

    int _spawntimer = 0;
    Vector2 _spawnerposition;
    private int _monsterCount = 0;

    public GameObject _monsterprefab;
    public GameObject player;
    // Use this for initialization
    void Start () {

        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (player.transform.position.y > 0)
        {

            _spawnerposition = new Vector2(
            transform.position.x, transform.position.y
            );



            //if (_spawntimer >= 20 && _monsterCount < MaximumMonsters)
            if (_spawntimer >= 20 && GameObject.FindGameObjectsWithTag("Monster2").Count() < MaximumMonsters) //Is this slow?
            {
                GameObject _Monster = Instantiate(_monsterprefab);
                _Monster.name = "Monster2";
                _Monster.transform.position = Random.insideUnitCircle * 2 + _spawnerposition;
                _Monster.GetComponent<monster_script>()._movingRight = SpawnRight;

                _spawntimer = 0;
                //Debug.Log("Spawn nr " + GameObject.FindGameObjectsWithTag("Monster").Count());
                //_monsterCount++;
            }


            _spawntimer += 1;

        }
    }
}
