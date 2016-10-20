using UnityEngine;
using UnityEngine.Analytics;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class PlayerDeadAnalytics : MonoBehaviour {

	public void OnPlayerDeath()
    {
        GameObject obj = this.gameObject;
        
        AnalyticsResult res = Analytics.CustomEvent("PlayerDead"+ SceneManager.GetActiveScene().name, new Dictionary<string, object>
        {
            { "position", obj.transform.position },
          });
        print(res.ToString());
        //string pos = obj.transform.position.ToString().Trim('(',')', ' ');
        //pos = pos.Replace(",", string.Empty);
        //GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, SceneManager.GetActiveScene().name, pos);
    }
}
