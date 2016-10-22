using UnityEngine;
using System.Collections;
using UnityEngine.Analytics;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MetricsManager : MonoBehaviour {

    int deathCount = 0;
    float fuelCount = 0;
    float startTime;
    float fuelLeft;

    static MetricsManager current;

    void Awake()
    {
        current = this;
    }

    public static void PickedUpFuel(float fuelAmount)
    {
        current.fuelCount+= fuelAmount;
    }

    public static bool ShouldReset()
    {
        if (current.deathCount == 0 && current.fuelCount == 0) return true;
        return false;
    }

    public static void Reset()
    {
        current.deathCount = 0;
        current.fuelCount = 0;
        current.startTime = Time.time;
        current.fuelLeft = 0;
    }

    public static void SetTime()
    {
        current.startTime = Time.time;
    }

    public void UploadMetrics()
    {
        float usedTime = Time.time - startTime;
        fuelLeft = Character.current.GetComponent<FuelReservoir>().fuelCount;

        AnalyticsResult res = Analytics.CustomEvent("Metrics" + SceneManager.GetActiveScene().name, new Dictionary<string, object>
        {
            { "DeathCount", deathCount },
            { "FuelPickedUp", fuelCount },
            { "TimeUsed", usedTime },
            { "FuelLeft", fuelLeft }
          });
        print(res.ToString());

        startTime = Time.time;
    }

    void PlayerDead()
    {
        deathCount++;
    }
	// Use this for initialization
	void Start () {
        EventManager.StartListening(EventManager.Events.GOAL_REACHED, UploadMetrics);
        EventManager.StartListening(EventManager.Events.PLAYER_DEAD, PlayerDead);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
