using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public GameObject defaultCam;
    public GameObject zoomInCam;
    public GameObject zoomOutCam;

    void Default()
    {
        defaultCam.SetActive(true);
        zoomInCam.SetActive(false);
        zoomOutCam.SetActive(false);
    }

    void ZoomIn()
    {
        defaultCam.SetActive(false);
        zoomInCam.SetActive(true);
        zoomOutCam.SetActive(false);
    }

    void ZoomOut()
    {
        defaultCam.SetActive(false);
        zoomInCam.SetActive(false);
        zoomOutCam.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DefaultZoom")
        {
            print("Reset Camera");
            Default();
        }

        if (other.gameObject.tag == "ZoomIn")
        {
            print("Zoom In");
            ZoomIn();
        }

        if (other.gameObject.tag == "ZoomOut")
        {
            print("Zoom Out");
            ZoomOut();
        }
    }
}
