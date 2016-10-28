using UnityEngine;
using System.Collections;

public class DrawLaser2 : MonoBehaviour {

	private LineRenderer _lineRenderer;
	public Transform start;
	public Transform destination;
	// Use this for initialization
	void Start () 
	{
		_lineRenderer = GetComponent<LineRenderer> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		_lineRenderer.SetPosition (0, start.position);
		_lineRenderer.SetPosition (1, destination.position);
		_lineRenderer.SetWidth (.2f, .2f);

	}
}
