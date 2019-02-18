using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GetBounds : MonoBehaviour
{
    public Tilemap tilemap;
    private Camera cam;
    private Vector3 cameraPosition;
    private float cameraWidth;
    private float cameraHeight;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        cameraPosition = cam.transform.position; //The center of the camera
        //Debug.Log(tilemap.localBounds.min); // Bottom left Vector3
        //Debug.Log(tilemap.localBounds.max); // Top right Vector3
        cameraHeight = cam.orthographicSize;
        cameraWidth = Mathf.Floor(cameraHeight * cam.aspect);
        Debug.LogFormat("Height is: {0} and Width is: {1}", cameraHeight, cameraWidth);
    }

    // Update is called once per frame
    void Update()
    {
        // Move variables from Start so they are updated

        // Adjust tilemap Vector3 by camera height and width

        // Ensure camera cannot move greater than maximum x and y and less than minimum x and y
        // Through Clamp?
    }
}
