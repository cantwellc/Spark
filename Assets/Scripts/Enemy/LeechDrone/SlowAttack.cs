using UnityEngine;
using System.Collections;

public class SlowAttack : MonoBehaviour {
	private LineRenderer _lineRenderer;
	public Transform origin;
	private Rigidbody _characterRigidbody;
	private float _originalDrag;



	void OnTriggerStay(Collider other)
	{
		
		if (other.gameObject.tag == "Character")
		{	
			_characterRigidbody.drag = _characterRigidbody.drag + 2f * Time.deltaTime;
			_lineRenderer.SetPosition (0, origin.position);
			_lineRenderer.GetComponent<Renderer> ().enabled = true;
			_lineRenderer.SetPosition (1, Character.current.transform.position);
		}
	} 
		
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Character")
		{
			_lineRenderer.GetComponent<Renderer> ().enabled = false;
			_characterRigidbody.drag = _originalDrag;
		}
	}




	// Use this for initialization
	void Start () 
	{
		_lineRenderer = GetComponent<LineRenderer> ();
		//
		_lineRenderer.SetWidth(0.45f, 0.45f);
		_lineRenderer.SetColors(Color.red, Color.red);
		Material whiteDiffuseMat = new Material(Shader.Find("Particles/Additive"));
		_lineRenderer.material = whiteDiffuseMat;
		_characterRigidbody = Character.current.GetComponent<Rigidbody> ();
		_originalDrag = _characterRigidbody.drag;


	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
