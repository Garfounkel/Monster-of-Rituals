using UnityEngine;
using System.Collections;

public class FleeFromPlayer : MonoBehaviour {

    public float TriggerDistance = 10;
    public float Speed = 0.01f;
    public float RandomWiggle = 1;
    public float marginH = 1;
    public float marginBottom = 1;
    public float marginTop = 0.5f;
    private Transform _player;

    // Use this for initialization
    void Start () {
        _player = GameObject.Find("Player").transform;
    }
	
	// Update is called once per frame
    private void Update()
    {
        var bl = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f));
        var tr = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        var w = tr.x - bl.x;
        var h = tr.y - bl.y;
        var wallsRect = new Rect(bl.x + marginH, bl.y + marginBottom, w - marginH*2, h - marginBottom - marginTop);
        if (_player && Mathf.Abs(_player.transform.position.x - transform.position.x) < TriggerDistance
            && wallsRect.Contains(transform.position))
        {
            transform.position += transform.up*Speed;
            transform.Rotate(0, 0, Random.Range(-RandomWiggle, RandomWiggle));
        }
    }
}
