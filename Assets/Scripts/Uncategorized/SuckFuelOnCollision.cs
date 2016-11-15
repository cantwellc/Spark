using UnityEngine;
using System.Collections;

public class SuckFuelOnCollision : MonoBehaviour
{
	private CharacterHealth _characterHealth= null;
	public float suckAmount;
	// Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
		if (Character.current != null && _characterHealth == null)
		{
			_characterHealth = Character.current.GetComponent<CharacterHealth> ();
		}
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
			other.GetComponent<Health>().TakeDamage(suckAmount*Time.deltaTime);
			AudioManager.instance.Play ("shock");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
           // other.GetComponent<Health>().TakeDamage(suckAmount * Time.deltaTime);
			if (Random.Range (0, 2) % 2 == 0)
			{
				_characterHealth.TakeDamageWithVFX (suckAmount * Time.deltaTime, "WallLightning");
			} 
			else
			{
				_characterHealth.TakeDamage (suckAmount * Time.deltaTime);
			}
        }
    }
}