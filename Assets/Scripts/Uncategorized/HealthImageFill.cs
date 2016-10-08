using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthImageFill : MonoBehaviour {
    public Health health;
    public Image healthImage;
	
	// Update is called once per frame
	void Update () {
        healthImage.fillAmount = health.HealthPercent;
	}
}
