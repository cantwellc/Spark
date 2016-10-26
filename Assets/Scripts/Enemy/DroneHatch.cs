using UnityEngine;
using System.Collections;

public class DroneHatch : MonoBehaviour {

    public Transform droneSpawnPoint;
//    public float droneSpawnDirectionInDegree;
    public float droneSpawnIntervalInSecond;
    public int droneSpawnCountsPerSpawn;
    public float droneSmallSpawnInterval;
    public float pushDroneForce;
    public GameObject dronePrefab;

    public float _spawnIntervalRemain;
    public float _remainingDrones;
    public float _smallSpawnIntervalRemain;
    public bool canSpawn;
    // Use this for initialization
    void Start () {
        canSpawn = false;
        _spawnIntervalRemain = 0;
        _remainingDrones = droneSpawnCountsPerSpawn;
        _smallSpawnIntervalRemain = droneSmallSpawnInterval;
    }
	
	// Update is called once per frame
	void Update () {
        if (_spawnIntervalRemain > 0) _spawnIntervalRemain -= Time.deltaTime;
        if (_smallSpawnIntervalRemain > 0) _smallSpawnIntervalRemain -= Time.deltaTime;

        if (canSpawn)
        {
            if(_spawnIntervalRemain <= 0)
            {
                if(_smallSpawnIntervalRemain <= 0)
                {
                    GameObject drone = (GameObject) Instantiate(dronePrefab);
                    drone.transform.position = transform.position;
                    //Vector3 impulse = new Vector3(pushDroneForce * Mathf.Cos(droneSpawnDirectionInDegree * Mathf.Deg2Rad), 0, pushDroneForce * Mathf.Sin(droneSpawnDirectionInDegree * Mathf.Deg2Rad));
                    Vector3 impulse = transform.forward * pushDroneForce;
                    drone.GetComponent<Rigidbody>().AddForce(impulse, ForceMode.Impulse);
                    _remainingDrones--;
                    _smallSpawnIntervalRemain = droneSmallSpawnInterval;
                    if (_remainingDrones == 0)
                    {
                        _spawnIntervalRemain = droneSpawnIntervalInSecond;
                        _remainingDrones = droneSpawnCountsPerSpawn;
                        _smallSpawnIntervalRemain = droneSmallSpawnInterval;
                    }
                }
            }
        }
	}

    public void StartShooting()
    {
        canSpawn = true;
    }

    public void StopShooting()
    {
        canSpawn = false;
    }

    public void Reload()
    {
        _spawnIntervalRemain = 0;
        _remainingDrones = droneSpawnCountsPerSpawn;
        _smallSpawnIntervalRemain = droneSmallSpawnInterval;
    }
}
