using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CrossProductThing : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Vector3 headPos = transform.position;
        Vector3 lookDir = transform.forward;

        void DrawRay (Vector3 p, Vector3 dir) => Handles.DrawAAPolyLine(p, p + lookDir);

        if (Physics.Raycast(headPos, transform.forward, out RaycastHit hit))
        {
            Vector3 hitPos = hit.point;
            Vector3 normal = hit.normal;

            Handles.color = Color.green;
            Handles.DrawAAPolyLine(headPos, hitPos);
            //Drawing the normal of the surface, which is already supplied by the Raycast Data
            Handles.color = Color.blue;
            DrawRay(hitPos, hit.normal);
        }
        else
        {
            Handles.color = Color.red;
            DrawRay(headPos, lookDir);
        }
    }
}
