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
        TriggerDistance += Random.Range(-TriggerDistance * 0.1f, TriggerDistance * 0.2f); //Adding individual differences to the fear zone
    }
	
	// Update is called once per frame
    private void Update()
    {
        var bl = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f));
        var tr = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        var w = tr.x - bl.x;
        var h = tr.y - bl.y;
        var wallsRect = new Rect(bl.x + marginH, bl.y + marginBottom, w - marginH*2, h - marginBottom - marginTop);
        if (_player && Mathf.Abs(_player.transform.position.x - transform.position.x) < TriggerDistance)
        {
            if (wallsRect.Contains(transform.position))
            {
                transform.position += transform.up*Speed;
                transform.Rotate(0, 0, Random.Range(-RandomWiggle, RandomWiggle));
            }
            else
            {
                /*if (transform.position.x < bl.x + marginH) transform.Rotate(0, 0, Random.Range(45, -45)); //Outside right wall
                if (transform.position.x > tr.x - marginH) transform.Rotate(0, 0, Random.Range(90+45, 180-45)); //left
                if (transform.position.y < bl.y + marginBottom) transform.Rotate(0, 0, Random.Range(45, 180-45)); //bottom
                if (transform.position.y > tr.y - marginTop) transform.Rotate(0, 0, Random.Range(180+45, 360-45)); //top*/
                if (transform.position.x < bl.x + marginH) transform.eulerAngles = new Vector3(0, 0, Random.Range(45 - 90, -45 - 90)); //Outside right wall
                if (transform.position.x > tr.x - marginH) transform.eulerAngles = new Vector3(0, 0, Random.Range(90 + 45 - 90, 180 - 45 - 90)); //left
                if (transform.position.y < bl.y + marginBottom) transform.eulerAngles = new Vector3(0, 0, Random.Range(45 - 90, 180 - 45 - 90)); //bottom
                if (transform.position.y > tr.y - marginTop) transform.eulerAngles = new Vector3(0, 0, Random.Range(180 + 45 - 90, 360 - 45 - 90)); //top
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(), 0.005f);
            }
        }
    }
}
