using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCursor : MonoBehaviour
{

    // Cached component references
    CameraRaycaster myCameraRaycast;

	// Use this for initialization
	void Start()
    {
        myCameraRaycast = GetComponent<CameraRaycaster>();
	}
	
	// Update is called once per frame
	void Update()
    {
      //  print(myCameraRaycast.layerHit);
    }
}
