using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class LevelView
{
    public void ShowMarker(GameObject _planeMarker, List<ARRaycastHit> hits)
    {
        if (hits.Count > 0)
        {
            _planeMarker.transform.position = hits[0].pose.position;
            _planeMarker.transform.rotation = hits[0].pose.rotation;

            _planeMarker.SetActive(true);
        }
    }
}
