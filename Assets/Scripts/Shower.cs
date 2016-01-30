using UnityEngine;
using System.Collections;

public class Shower : MonoBehaviour
{

    public bool On = true;
    public Vector2 Force = Vector2.down;
    public float TriggerDistance = 6;
    public float JitterRate = 4;
    private Rigidbody2D _rb;
    private TentacleTipController _ttc;
    private ParticleSystem _ps;
    private bool _emitting = true;
    private Transform _player;
    private AudioSource _showerSound;
    private Transform _mount;
    private float _soundStart = 0.15f;
    private float _soundLoopStart = 0.5f;
    private float _soundLoopEnd = 5;
    private float _soundEnd = 5.5f;

    void Start ()
	{
	    _rb = GetComponent<Rigidbody2D>();
        _ttc = GetComponent<TentacleTipController>();
        _ps = GetComponentInChildren<ParticleSystem>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _mount = transform.root.Find("Mount");
        _showerSound = GetComponent<AudioSource>();
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
                _showerSound.time = _soundStart;
                _emitting = true;
            }
            else if (_showerSound.time > _soundLoopEnd) _showerSound.time = _soundLoopStart;
        }
        else
        {
            _ttc.enabled = true;
            if (_emitting)
            {
                _ps.Stop();
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
