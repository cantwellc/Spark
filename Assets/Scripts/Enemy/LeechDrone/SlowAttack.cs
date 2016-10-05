using UnityEngine;
using System.Collections;

public class SlowAttack : MonoBehaviour {
	private LineRenderer _lineRenderer;
	private Renderer _lineRendererRendererComponent;
	public Transform origin;
	public float dragForce;
	private Rigidbody _characterRigidbody;
	private float _originalDrag;



	void OnTriggerStay(Collider other)
	{
		
		if (other.gameObject.tag == "Character")
        {
            //_characterRigidbody.drag = _characterRigidbody.drag + dragSpeed * Time.deltaTime;
            Character.current.GetComponent<SlowDownPhysics>().SlowDown(dragForce);
            _lineRenderer.SetPosition (0, origin.position);
			_lineRendererRendererComponent.enabled = true;
			_lineRenderer.SetPosition (1, Character.current.transform.position);
		}
	} 
		
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Character")
		{
			_lineRendererRendererComponent.enabled = false;
			_characterRigidbody.drag = 0.0f;
		}
	}

	void Start () 
	{
		_lineRendererRendererComponent = _lineRenderer = GetComponent<LineRenderer> ();

		_lineRenderer.SetWidth(0.45f, 0.45f);
		_characterRigidbody = Character.current.GetComponent<Rigidbody> ();
		_originalDrag = _characterRigidbody.drag;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
