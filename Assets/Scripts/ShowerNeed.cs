using UnityEngine;
using System.Collections;

public class ShowerNeed : InteractableNeed
{
   // public SpriteRenderer spriteRenderer;
    public float ReadingDistanceTreshold = 3;
    /*
    public Sprite RolledSprite;
    public Sprite OpenSprite;
    */


    private int originalSortingOrder = 0;
    private bool _isReading;
    private BoxCollider2D _box;
    private float _rolledSize;
    private Transform _mouth;

    // Use this for initialization
    void Start()
    {
        _box = GetComponent<BoxCollider2D>();
        _rolledSize = _box.size.y;
        //_mouth = GameObject.Find("Mouth").transform;
        _mouth = FindObjectOfType<PlayerMouth>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (_mouth == null)
        {
            _mouth = FindObjectOfType<PlayerMouth>().transform;
        }
        if (Vector2.Distance(transform.position, _mouth.position) < ReadingDistanceTreshold)
        {
            if (!_isReading)
            {
                PerformNeed();
                _isReading = true;
            }
        }
        else
        {
            if (_isReading)
            {
                StopPerformingNeed();
                _isReading = false;
            }
        }
    }

    public override void PerformNeed()
    {
        base.PerformNeed();
        //spriteRenderer.sprite = OpenSprite;
        //_box.size = new Vector2(_box.size.x, _rolledSize * 2.5f);

    }

    public override void StopPerformingNeed()
    {
        base.StopPerformingNeed();
       // spriteRenderer.sprite = RolledSprite;
        //_box.size = new Vector2(_box.size.x, _rolledSize);
    }

    protected override void OnNeedComplete()
    {
        base.OnNeedComplete();
        enabled = false;
        Debug.Log("Reading complete!");
    }
}
