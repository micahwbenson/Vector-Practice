using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoVScript : MonoBehaviour
{
    public Transform[] obj;

    private void OnDrawGizmos()
    {
        //Oh, wow it does work . . . that is interesting!!!
        Camera cam = GetComponent<Camera>();

        //FoV on Camera is in degrees - multiple angle by two to actually get the full angle value
        float camAngle = MaxAngle();
        cam.fieldOfView = 2 * camAngle * Mathf.Rad2Deg;
    }

    float MaxAngle()
    {
        float minAngle;
        float maxAngle = 0;
        for (int i = 0; i < obj.Length; i++)
        {
            Vector2 relObjPos = obj[i].position; // Gives you the specific location of the object to work off - relative to the camera, right?

            float opposite = relObjPos.y;
            float adjacent = relObjPos.x; //These are coordinate measures - I guess because you are working in the local space of the camera . . .

            // tan(angle) = o/a; -- need to reset this with algebra
            // angle = atan (o/a);

            //Apply this to the camera because it's not using it
            float angle = Mathf.Atan(opposite / adjacent);
            minAngle = angle;

            if (minAngle > maxAngle)
            {
                maxAngle = angle;
            }
        }
        return maxAngle;
    }
}

