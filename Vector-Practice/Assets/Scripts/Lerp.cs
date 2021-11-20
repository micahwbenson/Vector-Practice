using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    public Transform tfStart;
    public Transform tfEnd;

    [Range(0, 1)]
    public float t = 0f;

    private void OnDrawGizmos()
    {
        Vector2 a = tfStart.position;
        Vector2 b = tfEnd.position;

        Vector2 pt = Vector2.Lerp(a, b, t);

        Gizmos.color = Color.Lerp(Color.red, Color.blue, t);

        Gizmos.DrawSphere(pt, 0.05f);

        Gizmos.DrawLine(a, b);
    }
}
