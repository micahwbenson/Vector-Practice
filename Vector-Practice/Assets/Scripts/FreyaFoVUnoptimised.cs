using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreyaFoVUnoptimised : MonoBehaviour
{
    public FoVPoint[] points;

    private void OnDrawGizmos()
    {
        Camera cam = GetComponent<Camera>();

        Vector2 camDir = cam.transform.forward;
        Vector2 camPos = cam.transform.position;

        //First one is guaranteed to be smaller than this value
        float outermostAngle = float.MinValue;
        Vector2 ptOutermost = default; //Nice a value you can use
        float radius = 0f;
        foreach (FoVPoint fovPt in points)
        {
            //Gizmos.DrawLine(transform.position, point.position);
            //We need to find the outermost point -- what is the most efficient way to do this . . .
            //We can use the dot product for this -- OMG OF COURSE SO USEFUL . . . mad, I didn't think of this
            Vector2 pt = (Vector2)fovPt.transform.position - camPos; // we want it relative to the camera instead of holding a vector from world space, cool -- needed to cast the vector2 here for some reason, not quite sure why
            Vector2 dirToPt = pt.normalized; //remember you need to work with a normalized vector for a dot to work properly -- if we don't the result of the dot product will be changed it wont be in a 0 to 1 range
            float angleToPoint = Mathf.Acos(Vector2.Dot(camDir, dirToPt)); ;
            if (angleToPoint > outermostAngle)
            {
                outermostAngle = angleToPoint;
                ptOutermost = fovPt.transform.position;
                radius = fovPt.radius;
            }

            DrawPointRadii(fovPt);
        }

        //You can get the angle out of two normalized vectors with the DOT omg . . .
        //float angRad = Mathf.Acos(lowestDot);


        //Could have just gotten the dirToPt magnitude here . . .
        float distanceToPoint = Vector2.Distance(camPos, ptOutermost);

        //Could have just done this calculation inside of the ForEach so I could grab the radius there
        outermostAngle = outermostAngle + (Mathf.Asin(radius / distanceToPoint));

        cam.fieldOfView = outermostAngle * 2 * Mathf.Rad2Deg;

        //Ignoring range checking and the other robust code you would need for this to work in real life
        Gizmos.DrawLine(transform.position, ptOutermost);
    }
    //Showing the radius of each point
    void DrawPointRadii(FoVPoint outermost)
    {
        FoVPoint outermostRadius = outermost.GetComponent<FoVPoint>();
        Vector2 radius = outermostRadius.radius * Vector2.up; // How can I specifically get the radius of this object -- ok this should convert the radius into a usable vector, I think . . . ok, once you start to understand some of this it can be quite fun
        Gizmos.DrawWireSphere(outermostRadius.transform.position, outermostRadius.radius);
    }

    Vector2 grabRadius(Transform outermost)
    {
        FoVPoint outermostRadius = outermost.GetComponent<FoVPoint>();
        Vector2 radius = outermostRadius.radius * Vector2.up; // How can I specifically get the radius of this object -- ok this should convert the radius into a usable vector, I think . . . ok, once you start to understand some of this it can be quite fun
        return radius;
    }
}
