// From https://unity3dt.wordpress.com/2015/08/28/interstellar-black-hole-gargantua-tutorial/

using UnityEngine;

public class CameraFacingBillboard : MonoBehaviour
{
    public Camera camera;

    void Update()
    {
        if (camera == null) camera = Camera.main;
        transform.LookAt(transform.position + camera.transform.rotation * Vector3.forward,
        camera.transform.rotation * Vector3.up);
    }
}