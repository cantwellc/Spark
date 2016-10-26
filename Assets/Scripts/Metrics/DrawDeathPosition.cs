using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class DrawDeathPosition : MonoBehaviour {

    public string fileName;
    public GameObject posPrefab;

    public bool toDraw = false;
    public bool toClear = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(toDraw)
        {
            string pos, level;

            StreamReader reader = new StreamReader("Assets/Resources/Metrics/" + fileName, Encoding.Default);

            using(reader)
            {
                do
                {
                    pos = reader.ReadLine();
                    //level = reader.ReadLine();
                    //if (SceneManager.GetActiveScene().name != level) continue;
                    if (pos != null)
                    {
                        pos = pos.Trim('(', ')');
                        pos = pos.Replace(" ", string.Empty);
                        string[] posArray = pos.Split(',');
                        Vector3 position = new Vector3(float.Parse(posArray[0]), float.Parse(posArray[1]), float.Parse(posArray[2]));
                        GameObject obj = (GameObject)Instantiate(posPrefab, transform);
                        obj.transform.position = position;
                        obj.transform.parent = this.transform;
                    }
                }
                while (pos != null);

                reader.Close();
            }

            toDraw = false;
        }
        if(toClear)
        {
            for(int i=transform.childCount-1;i>=0;i--)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }

            toClear = false;
        }
	}
}
