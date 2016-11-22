using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class UIEventHandler : MonoBehaviour {
    
    public Text notificationText;
    public Text countdownText;
    public GameObject ESC_Panel;
    public GameObject inGameText;


    private bool _cheatMode = false;

	// Use this for initialization
    
    void OnEnable()
    {

        StartListeningEvents();
    }

    void OnDisable()
    {
        StopListeningEvents();

    }

    void RKey()
    {
        Time.timeScale = 0;
    }

    public void RestartButton()
    {
      //  EventManager.TriggerEvent("Restart Button Pressed");
    }

    public void CancelButton()
    {
      //  EventManager.TriggerEvent("Cancel Button Pressed");
    }

    IEnumerator CheatModeMessage(bool CheatMode)
    {
        if (CheatMode)
        {
            notificationText.text = "Cheat Mode Enabled!";
        }
        else
        {
            notificationText.text = "Cheat Mode Disabled!";
        }
        notificationText.enabled = true;
        notificationText.color = Color.red;
        yield return new WaitForSeconds(1.2f);
        notificationText.enabled = false;
    }

    IEnumerator Countdown(int seconds)
    {
       /* notificationText.text = "You ran out fuel!";
        notificationText.color = Color.red;
        notificationText.enabled = true;
        countdownText.enabled = true;
        countdownText.color = Color.red;*/
        while (seconds > 0)
        {
            //countdownText.text = seconds.ToString();
            yield return new WaitForSeconds(1f);
            seconds -= 1;
        }

        countdownText.enabled = false;
    }

    void CheatMode()
    {
        _cheatMode = !_cheatMode;
        StartCoroutine(CheatModeMessage(_cheatMode));
    }

    void DeadNotification()
    {
		GameObject playerDead = GameObject.Find ("LevelText");
		GameObject playerDeadImage = (playerDead.transform.Find ("Image")).gameObject;
		playerDeadImage.SetActive (true);
       	// notificationText.text = "You have died!";
        //notificationText.color = Color.red;
        //notificationText.enabled = true;
    }

    void DeathCountdown()
    {
        StartCoroutine(Countdown(5));
    }

    void StopDeathCountdown()
    {
        countdownText.enabled = false;
        notificationText.enabled = false;
    }

    //void OnPause()
    //{
    //    inGameText.SetActive(false);
    //    ESC_Panel.SetActive(true);
    //    Cursor.visible = true;
    //}

    //void OnResume()
    //{
    //    inGameText.SetActive(true);
    //    ESC_Panel.SetActive(false);
    //    EventManager.TriggerEvent(EventManager.Events.RESUME_GAME);
    //    Cursor.visible = false;
    //}

    // called in OnEnable()
    void StartListeningEvents()
    {
        EventManager.StartListening(EventManager.Events.B_KEY, CheatMode);
        EventManager.StartListening(EventManager.Events.PLAYER_DEAD, DeadNotification);
        EventManager.StartListening(EventManager.Events.DEATH_COUNTDOWN, DeathCountdown);
        EventManager.StartListening(EventManager.Events.STOP_DEATH_COUNTDOWN, StopDeathCountdown);
        EventManager.StartListening(EventManager.Events.R_KEY, StopDeathCountdown);
        EventManager.StartListening(EventManager.Events.GOAL_REACHED, StopDeathCountdown);
        //EventManager.StartListening(EventManager.Events.PAUSE_GAME, OnPause);
        //EventManager.StartListening(EventManager.Events.RESUME_GAME, OnResume);
    }

    // called in OnDisable()
    void StopListeningEvents()
    {
        EventManager.StopListening(EventManager.Events.B_KEY, CheatMode);
        EventManager.StopListening(EventManager.Events.PLAYER_DEAD, DeadNotification);
        EventManager.StopListening(EventManager.Events.DEATH_COUNTDOWN, DeathCountdown);
        EventManager.StopListening(EventManager.Events.STOP_DEATH_COUNTDOWN, StopDeathCountdown);
        EventManager.StopListening(EventManager.Events.R_KEY, StopDeathCountdown);
        EventManager.StopListening(EventManager.Events.GOAL_REACHED, StopDeathCountdown);
        //EventManager.StopListening(EventManager.Events.PAUSE_GAME, OnPause);
        //EventManager.StopListening(EventManager.Events.RESUME_GAME, OnResume);
    }

}
