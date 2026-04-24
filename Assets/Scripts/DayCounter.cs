using UnityEngine;

public class DayCounter : GlobalDayCounter
{

    public TextMesh dayCountervar;
    // override is the same like at globaldaycount but in reverse
    protected override void Start()
    {
        base.Start();
        dayCountervar.text = "Day " + daysPassed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
