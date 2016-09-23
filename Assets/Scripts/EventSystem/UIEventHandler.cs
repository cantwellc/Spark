using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class UIEventHandler : MonoBehaviour {

    public Text notificationText;
    public Character character;

    private GameObject PopupWindow;
    private UnityAction R;

    void Awake()
    {
        PopupWindow = transform.Find("Canvas/Popup window").gameObject;
        R = new UnityAction(RKey);
    }

	// Use this for initialization
    
    void OnEnable()
    {
        EventManager.StartListening(EventManager.Events.CHEAT_MODE, CheatMode);
    }

    void OnDisable()
    {
        EventManager.StopListening(EventManager.instance.Events.CHEAT_MODE, CheatMode);
    }

    void RKey()
    {
        Time.timeScale = 0;
        PopupWindow.SetActive(true);
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

    void CheatMode()
    {
        StartCoroutine(CheatModeMessage(character.ToggleCheatCode()));
    }

}
