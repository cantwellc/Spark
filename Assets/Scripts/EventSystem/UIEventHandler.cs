using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class UIEventHandler : MonoBehaviour {

    public Character character;
    public Text notificationText;
    public Text countdownText;



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
        notificationText.text = "You ran out fuel, ship explodes in:";
        notificationText.color = Color.red;
        notificationText.enabled = true;
        countdownText.enabled = true;
        countdownText.color = Color.red;
        while (seconds > 0)
        {
            countdownText.text = seconds.ToString();
            yield return new WaitForSeconds(1f);
            seconds -= 1;
        }

        countdownText.enabled = false;
    }

    void CheatMode()
    {
        StartCoroutine(CheatModeMessage(character.ToggleCheatCode()));
    }

    void DeadNotification()
    {
        notificationText.text = "You have died! Press R to restart.";
        notificationText.color = Color.red;
        notificationText.enabled = true;
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

    // called in OnEnable()
    void StartListeningEvents()
    {
        EventManager.StartListening(EventManager.Events.CHEAT_MODE, CheatMode);
        EventManager.StartListening(EventManager.Events.PLAYER_DEAD, DeadNotification);
        EventManager.StartListening(EventManager.Events.DEATH_COUNTDOWN, DeathCountdown);
        EventManager.StartListening(EventManager.Events.STOP_DEATH_COUNTDOWN, StopDeathCountdown);
    }

    // called in OnDisable()
    void StopListeningEvents()
    {
        EventManager.StopListening(EventManager.Events.CHEAT_MODE, CheatMode);
        EventManager.StopListening(EventManager.Events.PLAYER_DEAD, DeadNotification);
        EventManager.StopListening(EventManager.Events.STOP_DEATH_COUNTDOWN, StopDeathCountdown);
    }

}
