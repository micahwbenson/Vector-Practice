using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoVScript : MonoBehaviour
{
    public Transform obj;
    private void OnDrawGizmos()
    {
        //Oh, wow it does work . . . that is interesting!!!
        Camera cam = GetComponent<Camera>();

        Vector2 relObjPos = obj.position - cam.transform.position; // Gives you the specific location of the object to work off - relative to the camera, right?

        float opposite = relObjPos.y;
        float adjacent = relObjPos.x; //These are coordinate measures - I guess because you are working in the local space of the camera . . .

        // tan(angle) = o/a; -- need to reset this with algebra
        // angle = atan (o/a);

        //Apply this to the camera because it's not using it
        float angRad = Mathf.Atan(opposite / adjacent);

        //FoV on Camera is in degrees - multiple angle by two to actually get the full angle value
        cam.fieldOfView = 2 * angRad * Mathf.Rad2Deg;
    }
}
