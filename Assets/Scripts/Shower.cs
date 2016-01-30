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
    private AudioSource _showerSound;
    private Transform _mount;
    public float _soundStart = 0.15f;
    public float _soundLoop = 5;
    public float _soundEnd = 5.5f;
    public float JitterRate = 10;

    void Start ()
	{
	    _rb = GetComponent<Rigidbody2D>();
        _ttc = GetComponent<TentacleTipController>();
        _ps = GetComponentInChildren<ParticleSystem>();
        _player = GameObject.Find("Player").transform;
        _mount = transform.root.Find("Mount");
        _showerSound = GetComponent<AudioSource>();
        //_showerSound.Play();
    }

    private void Update()
    {
        if (On)
        {
            _rb.AddRelativeForce(Force);
            if (Random.Range(0, JitterRate) > 1)
                _ttc.enabled = false;
            else
                _ttc.enabled = true;
            if (!_emitting)
            {
                _ps.Play();
                _showerSound.Play();
                _showerSound.time = 0.15f;
                //_showerSound.mute = false;
                _emitting = true;
            }
            else if (_showerSound.time > _soundLoop) _showerSound.time = _soundStart;
        }
        else
        {
            _ttc.enabled = true;
            //_rb.MovePosition(new Vector2(transform.parent.position.x-0.5f, Mathf.Min(transform.position.y+0.5f,transform.parent.position.y+4)));
            //_rb.MoveRotation(180);
            if (_emitting)
            {
                _ps.Stop();
                //_showerSound.mute = true;
                _showerSound.time = _soundEnd;
                _emitting = false;
            }
        }
        //if (_player && _player.transform.position.x > transform.position.x-1) On = true;
        if (_player && Mathf.Abs(_player.transform.position.x - _mount.position.x) < TriggerDistance)
            On = true;
        else
            On = false;
    }
}
