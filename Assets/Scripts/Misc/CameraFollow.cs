using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public List<Transform> targets;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Transform background;
    private Vector3 backgroundSize;
    float size;
    Camera MyCamera;

    void Awake()
    {
        MyCamera = GetComponent<Camera>();
        backgroundSize = background.localScale;
    }

    Vector3 FindCenterPoint()
    { 
     if (targets.Count == 0)
         return Vector3.zero;
     if (targets.Count == 1)
         return targets[0].position;
     var bounds = new Bounds(targets[0].position, Vector3.zero);
     for (var i = 1; i<targets.Count; i++)
         bounds.Encapsulate(targets[i].position); 
     return bounds.center;
    }

    float FindDistance()
    {
        float longestDistance = 0;
        float newDistance = 0;
        float minDistance = 6;
        float maxDistance = 10;
        for(int i = 0; i < targets.Count - 1; i++)
        {
            for(int j = i + 1; j < targets.Count; j++)
            {
                newDistance = Vector3.Distance(targets[i].position, targets[j].position);
                Debug.Log(newDistance);
                if (newDistance > longestDistance) { longestDistance = newDistance;}
            }
        }
        if (longestDistance < minDistance) { longestDistance = minDistance; }
        if (longestDistance > maxDistance) { longestDistance = maxDistance; }
        return longestDistance;
    }

void FixedUpdate()
    {
        Vector3 desiredPosition = FindCenterPoint() + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        size = FindDistance();
        MyCamera.orthographicSize = size;
        background.localScale = (backgroundSize*size)/5;
    }
}
