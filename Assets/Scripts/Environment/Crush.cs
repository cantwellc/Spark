using UnityEngine;
using System.Collections;

public class Crush : MonoBehaviour {

	public enum CrushingOptions
	{
		OnlyTop,
		OnlyBottom,
		Both
	}

	public CrushingOptions crushingOptions;
	public float speed;
	public bool startCrushing = false;
	private Transform _topWall;
	private Transform _bottomWall;



	// Use this for initialization
	void Start () 
	{
		foreach (Transform t in  transform)
		{
			if (t.name == "WallTopGameObject")
			{
				_topWall = t;
			} 
			else if (t.name == "WallBottomGameObject")
			{
				_bottomWall = t;
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (startCrushing)
		{

			if (crushingOptions == CrushingOptions.Both)
			{
				_topWall.transform.localScale = new Vector3 (_topWall.localScale.x, _topWall.localScale.y, _topWall.localScale.z  + (-1 * Time.deltaTime * speed));
				_bottomWall.transform.localScale = new Vector3 (_bottomWall.localScale.x, _bottomWall.localScale.y, _bottomWall.localScale.z  + (-1 * Time.deltaTime * speed)); 

			} 
			else if (crushingOptions == CrushingOptions.OnlyBottom)
			{
				_bottomWall.transform.localScale = new Vector3 (_bottomWall.localScale.x, _bottomWall.localScale.y, _bottomWall.localScale.z  + (-1 * Time.deltaTime * speed)); 

			} 
			else if (crushingOptions == CrushingOptions.OnlyTop)
			{
				_topWall.transform.localScale = new Vector3 (_topWall.localScale.x, _topWall.localScale.y, _topWall.localScale.z + (-1 * Time.deltaTime * speed));

			}
		}
	}
	public void StartCrushing()
	{
		startCrushing = true;
	}
	public void StopCrushing()
	{
		startCrushing = false;
	}
}
