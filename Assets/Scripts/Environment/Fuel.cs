using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Fuel : MonoBehaviour 
{
	public int fuelAmmount;
	public UnityEvent onGatherSfx;
	private float sizeCoefficient=1.2f;
	private Character _character;


	void Awake()
	{
        //Container scaling is a problem at the moment original scale is too high when scaling fuel it brokes the size of container ! 
		//ScaleFuel ();

	}
		
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Character")
		{		
			onGatherSfx.Invoke ();
            //Scale Fuel scales the container itself until the problem is solved this is the solution I have 
            _character = GameObject.FindGameObjectWithTag("Character").GetComponent<Character>();
            _character.AddFuel (fuelAmmount);
			Destroy (gameObject);
		}
	}
	public void ScaleFuel()
	{
		_character = GameObject.FindGameObjectWithTag ("Character").GetComponent<Character> ();
		float sizeScale =  sizeCoefficient *(float)fuelAmmount / _character.GetComponent<FuelReservoir> ().maxFuelCount;
		transform.localScale = new Vector3 (sizeScale, sizeScale, sizeScale);
	}

	public void FuelSound (string audioEvent)
	{
		AudioManager.instance.Play (audioEvent);
	}
}
