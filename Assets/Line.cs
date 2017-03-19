using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Line : MonoBehaviour {

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCol;

    List<Vector2> points;

    public void UpdateLine(Vector2 mousePosition)
    {
        if (points == null)
        {
            points = new List<Vector2>();
            SetPoint(mousePosition);
            return;
        }
        // Check if the mouse has moved enough for us to insert new point
        //If it has: Insert point at mouse position

        if (Vector2.Distance(points.Last(),mousePosition)> .1f)
        {
            SetPoint(mousePosition);
        }
    }

    void SetPoint(Vector2 point)
    {
        points.Add(point);

        lineRenderer.numPositions = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);

        if (points.Count > 1)
        {
            edgeCol.points = points.ToArray();
        }
        

    }

}
