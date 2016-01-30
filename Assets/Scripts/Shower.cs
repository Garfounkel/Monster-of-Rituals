using UnityEngine;
using System.Collections;

public class Shower : MonoBehaviour
{

    public bool On = true;
    public Vector2 Force = Vector2.down;
    public float TriggerDistance = 6;
    private Rigidbody2D _rb;
    private TentacleTipController _ttc;
    private ParticleSystem _ps;
    private bool _emitting = true;
    private Transform _player;

    void Start ()
	{
	    _rb = GetComponent<Rigidbody2D>();
        _ttc = GetComponent<TentacleTipController>();
        _ps = GetComponentInChildren<ParticleSystem>();
        _player = GameObject.Find("Player").transform;
	}

    private void Update()
    {
        if (On)
        {
            _rb.AddRelativeForce(Force);
            _ttc.enabled = false;
            if (!_emitting)
            {
                _ps.Play();
                _emitting = true;
            }
        }
        else
        {
            _ttc.enabled = true;
            //_rb.MovePosition(new Vector2(transform.parent.position.x-0.5f, Mathf.Min(transform.position.y+0.5f,transform.parent.position.y+4)));
            //_rb.MoveRotation(180);
            if (_emitting)
            {
                _ps.Stop();
                _emitting = false;
            }
        }
        //if (_player && _player.transform.position.x > transform.position.x-1) On = true;
        if (_player && Mathf.Abs(_player.transform.position.x - transform.position.x) < TriggerDistance)
            On = true;
        else
            On = false;
    }
}
