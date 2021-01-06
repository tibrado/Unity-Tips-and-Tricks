public class Timer
{
    float countdown { set; get; }
    float set_time { set; get; } = 0.001f; // -- timer time refrence
    public bool done { set; get; } = true;

    // -- Run Function needs to be called in the update or fixedupdate function. 
    public float Run()
    {
        if (countdown > 0f) { countdown -= Time.deltaTime * 1f; done = false; } // -- timer is not done until time is 0
        else done = true;
        return countdown / set_time; // -- Returns time remaining (0 to 1) 
    }

    // -- Set function for set_timer
    public bool Set(float set_timer_time = 0.01f)
    {
        countdown = set_timer_time;
        set_time = set_timer_time; // set_time can also be set by using variable. 

        return true;
    }
}
