using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour
{
    private bool shouldLerp = false;
    public bool isPuddle = true;

    public Vector2 startPos;
    public Vector2 endPos;

    public float timeStartedLepring;
    public float lerpTime;

    public void StartLerping()
    {
        timeStartedLepring = Time.time;
        this.gameObject.tag = "Untagged";
        shouldLerp = true;
    }

    void Update()
    {
        if(this.gameObject.tag == "puddle")
        {
            isPuddle = true;
        }
        else
        {
            isPuddle = false;
        }

        if (shouldLerp)
        {
            transform.position = Lerp(startPos, endPos, timeStartedLepring, lerpTime);
        }
    }

    public Vector3 Lerp(Vector3 start, Vector3 end, float timeStartedLepring, float lerpTime = 1)
    {
        float timeSinceStarted = Time.time - timeStartedLepring;

        float percentageComplete = timeSinceStarted / lerpTime;

        var result = Vector3.Lerp(start, end, percentageComplete);

        return result;
    }
}
