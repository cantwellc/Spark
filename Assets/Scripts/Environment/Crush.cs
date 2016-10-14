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
    private float factor;
    public bool resetAfterCollision = false;

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
        factor = _topWall.localPosition.z - _bottomWall.localPosition.z / 4;
    }
	
	// Update is called once per frame
	void Update () 
	{
		if (startCrushing)
		{

			if (crushingOptions == CrushingOptions.Both && !TheWallsTouch())
			{
				_topWall.transform.localPosition = new Vector3 (_topWall.localPosition.x, _topWall.localPosition.y, _topWall.localPosition.z  + (-1 * Time.deltaTime * speed));
				_bottomWall.transform.localPosition= new Vector3 (_bottomWall.localPosition.x, _bottomWall.localPosition.y,  _bottomWall.localPosition.z  + (Time.deltaTime * speed)); 

			} 
			else if (crushingOptions == CrushingOptions.OnlyBottom && !TheWallsTouch())
			{
				_bottomWall.transform.localPosition = new Vector3 (_bottomWall.localPosition.x, _bottomWall.localPosition.y,  _bottomWall.localPosition.z  + (Time.deltaTime * speed)); 

			} 
			else if (crushingOptions == CrushingOptions.OnlyTop && !TheWallsTouch())
			{
				_topWall.transform.localPosition = new Vector3 (_topWall.localPosition.x, _topWall.localPosition.y,  _topWall.localPosition.z + (-1 * Time.deltaTime * speed));

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

    bool TheWallsTouch()
    {
        if (_topWall.localPosition.z <= _bottomWall.localPosition.z + factor)
        {
            if (resetAfterCollision)
            {
                //
                return false;
            }
            else return true;
        }
        else
            return false;
    }
}
