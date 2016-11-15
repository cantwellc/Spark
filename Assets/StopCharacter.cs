using UnityEngine;
using System.Collections;

public class StopCharacter : MonoBehaviour {


	public void Stop()
	{
		if (Vector3.Magnitude (Character.current.GetComponent<Rigidbody> ().velocity) > 2.0f)
		{

			GameObject initialCheckpoint = GameObject.Find ("InitialCheckpointWithAnimation");
			initialCheckpoint.GetComponent<CharacterAnimationPlay> ().ReEnableInput ();
			Vector3 normalizedVelocity = Character.current.GetComponent<Rigidbody> ().velocity.normalized;
			Vector3 forceToApply = normalizedVelocity * -20;
			Character.current.GetComponent<Rigidbody> ().AddForce(forceToApply, ForceMode.Impulse);
			Debug.Log ("Running this");

			/*Character.current.GetComponent<Rigidbody> ().velocity = Character.current.GetComponent<Rigidbody> ().velocity / 3;

			Character.current.GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;*/
		}
		//Debug.Log (Character.current.GetComponent<Rigidbody> ().velocity);
		//Character.current.GetComponent<Rigidbody> ().velocity = new Vector3(0,0,0);

	}
}
