using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControlDetection : MonoBehaviour
{
    public class DragObject
    {
        public Transform obj;
        public int fingerID;
        public Vector3 dragOffset;
        public Vector3 startPos;
        public Plane dragPlane;
    }
    public Dictionary<int, DragObject> draggedObjects = new Dictionary<int, DragObject>();
    private void Update()
	{
    }
}
