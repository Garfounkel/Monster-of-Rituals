using System.Collections;
using UnityEngine;

public class Clock : MonoBehaviour {

	public static Clock instance;

    public bool useClue;

	public float coffeeTime;
    public float showerTime;
    public float whiskyTime;
    public float newsPaperTime;

    public bool coffeeDrinked;
    public bool showerTook;
    public bool whiskyDrinked;
    public bool newspaperRead;

    public Sprite coffeeClue;
    public Sprite showerClue;
    public Sprite newsPaperClue;
    public Sprite whiskyClue;

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
    private bool whiskyTimePassedOnlyOnce;
    private bool whiskyClueOnlyOnce;
    private bool whiskyTookInTimeOnlyOnce;
    private bool newspaperTimePassedOnlyOnce;
    private bool newspaperClueOnlyOnce;
    private bool newspaperTookInTimeOnlyOnce;

    void Awake(){
        instance = this;
    }

    void Start()
	{
	    playerCB = FindObjectOfType<ControlableBody>();
		CurrentHour = 0;
	}

    private bool afternoon;
    private int previousHour = -1;

    void Update () 
	{
		clockNeedle.RotateAround (mid.position, Vector3.back, Time.deltaTime * speed);
	    previousHour = Mathf.FloorToInt(CurrentHour);

        CurrentHour =  12 - ((clockNeedle.eulerAngles.z / 30) % 12);
	    if ((previousHour == 11 || previousHour == 23) && Mathf.FloorToInt(CurrentHour) == 0)
	    {
	        afternoon = !afternoon;
	    }

        if (afternoon)
	    {
	        CurrentHour += 12;
	    }

        //Debug.Log ("hour = " + CurrentHour);


        // COFFEE
        if (CurrentHour > coffeeTime && !coffeeDrinked && !coffeeTimePassedOnlyOnce)
	    {
	        coffeeTimePassedOnlyOnce = true;
            Debug.Log("Time for coffee has passed and I haven't even drinked one, I'm pissed !!");
            PlayerAngry.MoreAngry();
	    }

	    if (useClue && CurrentHour > coffeeTime - timeBeforeClue && !coffeeDrinked && !coffeeClueOnlyOnce)
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

        if (useClue && CurrentHour > showerTime - timeBeforeClue && !showerTook && !showerClueOnlyOnce)
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


        // Whisky
        if (CurrentHour > whiskyTime && !whiskyDrinked && !whiskyTimePassedOnlyOnce)
        {
            whiskyTimePassedOnlyOnce = true;
            Debug.Log("Time for whisky has passed and I haven't even took it, I'm pissed !! it is " + CurrentHour);
            PlayerAngry.MoreAngry();
        }

        if (useClue && CurrentHour > whiskyTime - timeBeforeClue && !whiskyDrinked && !whiskyClueOnlyOnce)
        {
            whiskyClueOnlyOnce = true;
            StartCoroutine(SetOverHeadImage(whiskyClue));
        }

        if (CurrentHour < whiskyTime && whiskyDrinked && !whiskyTookInTimeOnlyOnce)
        {
            whiskyTookInTimeOnlyOnce = true;
            Debug.Log("whisky has been taken before going to bed, I'm less angry =)");
            PlayerAngry.LessAngry();
        }

        // NewsPaper
        if (CurrentHour > newsPaperTime && !newspaperRead && !newspaperTimePassedOnlyOnce)
        {
            newspaperTimePassedOnlyOnce = true;
            Debug.Log("Time for newspaper has passed and I haven't even took it, I'm pissed !!");
            PlayerAngry.MoreAngry();
        }

        if (useClue && CurrentHour > newsPaperTime - timeBeforeClue && !newspaperRead && !newspaperClueOnlyOnce)
        {
            newspaperClueOnlyOnce = true;
            StartCoroutine(SetOverHeadImage(newsPaperClue));
        }

        if (CurrentHour < newsPaperTime && newspaperRead && !newspaperTookInTimeOnlyOnce)
        {
            newspaperTookInTimeOnlyOnce = true;
            Debug.Log("Newspaper has been read, I'm less angry =)");
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
        else if (needType == NeedType.Whisky)
        {
            Debug.Log("whisky drinked");
            instance.whiskyDrinked = true;
        }
        else if (needType == NeedType.Newspaper)
        {
            instance.newspaperRead = true;
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
    Lunch,
    Newspaper,
    Whisky
}