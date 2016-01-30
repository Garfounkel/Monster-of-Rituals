using System.Collections;
using UnityEngine;

public class Clock : MonoBehaviour {

	public static Clock instance;

	public float coffeeTime;
    public float showerTime;
    public float lunchTime;

    public bool coffeeDrinked;
    public bool showerTook;
    public bool lunchEaten;
    public bool wiskyDrinked;

    public Sprite coffeeClue;
    public Sprite showerClue;

    public float timeBeforeClue;
    [Tooltip("Over Head Message Duration")]public float overHeadMessageDuration;

    public Transform clockNeedle;
    public Transform mid;
	public float speed;

	public static float CurrentHour;


    private ControlableBody playerCB;

    private bool coffeeTimePassedOnlyOnce;
    private bool coffeeClueOnlyOnce;
    private bool coffeeDrinkedInTimeOnlyOnce;
    private bool showerTimePassedOnlyOnce;
    private bool showerClueOnlyOnce;
    private bool showerTookInTimeOnlyOnce;

    void Awake(){
		instance = this;
	}

    void Start()
	{
	    playerCB = FindObjectOfType<ControlableBody>();
		CurrentHour = 0;
	}

	void Update () 
	{
		clockNeedle.RotateAround (mid.position, Vector3.back, Time.deltaTime * speed);
		CurrentHour =  12 - ((clockNeedle.eulerAngles.z / 30) % 12);
		//Debug.Log ("hour = " + hours);


        // COFFEE
	    if (CurrentHour > coffeeTime && !coffeeDrinked && !coffeeTimePassedOnlyOnce)
	    {
	        coffeeTimePassedOnlyOnce = true;
            Debug.Log("Time for coffee has passed and I haven't even drinked one, I'm pissed !!");
            PlayerAngry.MoreAngry();
	    }

	    if (CurrentHour > coffeeTime - timeBeforeClue && !coffeeDrinked && !coffeeClueOnlyOnce)
	    {
	        coffeeClueOnlyOnce = true;
	        StartCoroutine(SetOverHeadImage(coffeeClue));
	    }

	    if (CurrentHour < coffeeTime && coffeeDrinked && !coffeeDrinkedInTimeOnlyOnce)
	    {
	        coffeeDrinkedInTimeOnlyOnce = true;
            Debug.Log("Coffee drinked in time, I'm less angry =)");
	        PlayerAngry.LessAngry();
	    }


        // SHOWER
        if (CurrentHour > showerTime && !showerTook && !showerTimePassedOnlyOnce)
        {
            showerTimePassedOnlyOnce = true;
            Debug.Log("Time for shower has passed and I haven't even took it, I'm pissed !!");
            PlayerAngry.MoreAngry();
        }

        if (CurrentHour > showerTime - timeBeforeClue && !showerTook && !showerClueOnlyOnce)
        {
            showerClueOnlyOnce = true;
            StartCoroutine(SetOverHeadImage(showerClue));
        }

        if (CurrentHour < showerTime && showerTook && !showerTookInTimeOnlyOnce)
        {
            showerTookInTimeOnlyOnce = true;
            Debug.Log("Shower has been taken in time, I'm less angry =)");
            PlayerAngry.LessAngry();
        }
    }

	public static void ReportNeedComplete(NeedType needType){
		if (needType == NeedType.Coffee){
			instance.coffeeDrinked = true;
		}
		else if (needType == NeedType.Shower){
			instance.showerTook = true;
		}
		else if (needType == NeedType.Lunch){
			instance.lunchEaten = true;
		}
	}

    private IEnumerator SetOverHeadImage(Sprite image)
    {
        Sprite previousImage = playerCB.OverHeadSprite.sprite;
        playerCB.OverHeadSprite.sprite = image;
        yield return new WaitForSeconds(overHeadMessageDuration);
        playerCB.OverHeadSprite.sprite = previousImage;
    }
}

public enum NeedType
{
    Coffee,
    Shower,
    Lunch
}