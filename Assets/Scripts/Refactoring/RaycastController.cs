using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class RaycastController
{
    public List<ARRaycastHit> GetPointOfReycast(ARRaycastManager _ARRaycastManager)
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        _ARRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        return hits;
    }
}
