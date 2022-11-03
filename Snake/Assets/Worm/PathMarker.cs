using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Class used to make a path for worm body */
public class PathMarker : MonoBehaviour
{
    public struct Marker
    {
        public Vector3 Position;
        public Quaternion Rotation;

        public Marker(Vector3 position, Quaternion rotation)
        {
            Position = position;
            Rotation = rotation;
        }
    }

    public List<Marker> markers = new List<Marker>();

    void FixedUpdate()
    {
        markers.Add(new Marker(transform.position, transform.rotation));
    }

    public void ClearMarkers()
    {
        markers.Clear();
        markers.Add(new Marker(transform.position, transform.rotation));
    }
}
