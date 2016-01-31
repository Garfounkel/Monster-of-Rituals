using UnityEngine;
using System.Collections;

public class ControlableBody : MonoBehaviour {

	public static ControlableBody instance;

	public SpriteRenderer OverHeadSprite;
	public SpriteRenderer playerSpriteRenderer;
    public TentaculeOverlap leftTentaculeOverlap;
    public TentaculeOverlap rightTentaculeOverlap;

    public float m_MaxSpeed = 10f;
	public AudioSource ahhSource;

	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;

	private void Start()
	{
		if (instance != null){
			Destroy(gameObject);
		}
		else{
			instance = this;
		}
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
        leftTentaculeOverlap.AddSortingOrder(2);
	}


	private void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");
		Move(h);

	}


	public void OnNeedFilled(){
		ahhSource.Play();
	}

	public void Move(float move)
	{
		m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed, m_Rigidbody2D.velocity.y);

		if (move > 0 && !m_FacingRight)
		{
			Flip();
		}
		else if (move < 0 && m_FacingRight)
		{
			Flip();
		}
	}


	private void Flip()
	{
		m_FacingRight = !m_FacingRight;

		Vector3 theScale = playerSpriteRenderer.transform.localScale;
		theScale.x *= -1;

	    if (theScale.x < 0)
	    {
            leftTentaculeOverlap.AddSortingOrder(2);
	        rightTentaculeOverlap.AddSortingOrder(-2);
	    }
	    else
	    {
            leftTentaculeOverlap.AddSortingOrder(-2);
            rightTentaculeOverlap.AddSortingOrder(2);
        }

        playerSpriteRenderer.transform.localScale = theScale;
	}
}
