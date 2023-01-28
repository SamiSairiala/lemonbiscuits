using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingNode
{
    private Vector3 x1, x2, y1, y2;
    public PathfindingNode(Vector3 x1, Vector3 x2, Vector3 y1, Vector3 y2)
    {
        this.x1 = x1;
        this.x2 = x2;
        this.y1 = y1;
        this.y2 = y2;
    }

    public bool checkSlope(float maxDifference)
    {
        return (Mathf.Max(x1.y, x2.y, y1.y, y2.y) - Mathf.Min(x1.y, x2.y, y1.y, y2.y)) <= maxDifference;
    }
    public Vector3 GetCenter()
    {
        Vector3 center = new Vector3();
        center.x = (x1.x + x2.x + y1.x + y2.x)/ 4;
        center.y = (x1.y + x2.y + y1.y + y2.y)/ 4;
        center.z = (x1.z + x2.z + y1.z + y2.z)/ 4;
        return center;
    }
}
