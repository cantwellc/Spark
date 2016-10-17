using UnityEngine;
using System.Collections;

public class DrawLaser : MonoBehaviour {

	private LineRenderer _lineRenderer;
	private Renderer _lineRendererRendererComponent;
	public Transform origin;
	public bool isAttatched = false;

	void OnTriggerStay(Collider other)
	{

		if (other.gameObject.tag == "Character")
		{	
			if (isAttatched == false) 
			{
				AudioManager.instance.Play ("laser");
				isAttatched = true;
			}

			_lineRenderer.SetPosition (0, origin.position);
			_lineRendererRendererComponent.enabled = true;
			_lineRenderer.SetPosition (1, Character.current.transform.position);
		}
	} 

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Character")
		{
			AudioManager.instance.Play ("leechRelease");
			isAttatched = false;
			_lineRendererRendererComponent.enabled = false;

		}
	}

	void Start () 
	{
		_lineRendererRendererComponent = _lineRenderer = GetComponent<LineRenderer> ();
		_lineRenderer.SetWidth(0.45f, 0.45f);
	
	}
}
