using UnityEngine;
using UnityEngine.Analytics;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class PlayerDeadAnalytics : MonoBehaviour {

	public void OnPlayerDeath()
    {
        GameObject obj = this.gameObject;
        
        Analytics.CustomEvent("PlayerDead", new Dictionary<string, object>
        {
            { "position", obj.transform.position },
            { "level", SceneManager.GetActiveScene().name }
          });
    }
}
