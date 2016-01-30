using UnityEngine;

public class Clock : MonoBehaviour {

	public float coffeeTime;
    public float showerTime;
    public float lunchTime;

    public bool coffeeDrinked;
    public bool showerTook;
    public bool lunchEaten;

    public float timeBeforeClue;

	public Transform clockNeedle;
	public float speed;

	public static float CurrentHour;


	void Start()
	{
		CurrentHour = 0;
	}

	void Update () 
	{
		clockNeedle.RotateAround (transform.position, Vector3.back, Time.deltaTime * speed);
		CurrentHour =  12 - ((clockNeedle.eulerAngles.z / 30) % 12);
		//Debug.Log ("hour = " + hours);

	    if (CurrentHour > coffeeTime && !coffeeDrinked)
	    {
	        //Debug.Log("Time for coffee has passed and I haven't even drinked one, I'm pissed !!");
            PlayerAngry.MoreAngry();
	    }

	    if (CurrentHour > coffeeTime - timeBeforeClue && !coffeeDrinked)
	    {
	        
	    }
	}
}

public enum NeedType
{
    Coffee,
    Shower,
    Lunch
}