using UnityEngine;
using System.Collections;

public class DrawLine : MonoBehaviour {
	private LineRenderer _lineRenderer;
	private float _distance;
	public float drawLineWhenDistanceIsLessThan;
	public Transform origin;



	// Use this for initialization
	void Start () 
	{
		_lineRenderer = GetComponent<LineRenderer> ();
		//
		_lineRenderer.SetWidth(0.45f, 0.45f);
		_lineRenderer.SetColors(Color.red, Color.red);
		Material whiteDiffuseMat = new Material(Shader.Find("Particles/Additive"));
		_lineRenderer.material = whiteDiffuseMat;


	}
	
	// Update is called once per frame
	void Update () 
	{
		_distance = Vector3.Distance (origin.position, Character.current.transform.position);
		if (_distance < drawLineWhenDistanceIsLessThan)
		{
			_lineRenderer.SetPosition(0, origin.position);
			_lineRenderer.GetComponent<Renderer> ().enabled = true;
			_lineRenderer.SetPosition (1, Character.current.transform.position);
		} 
		else
		{
			_lineRenderer.GetComponent<Renderer> ().enabled = false;
		}
	}
}
