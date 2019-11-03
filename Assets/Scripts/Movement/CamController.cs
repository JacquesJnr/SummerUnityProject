using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public GameObject defaultCam;
    public GameObject zoomInCam;
    public GameObject zoomOutCam;
    private GameObject player;
    public Camera currentCam;


    private void Update()
    {
        player = GameObject.Find("Player");
        
    }

    //void Default()
    //{
    //    defaultCam.SetActive(true);
    //    zoomInCam.SetActive(false);
    //    zoomOutCam.SetActive(false);
    //}

    //void ZoomIn()
    //{
    //    defaultCam.SetActive(false);
    //    zoomInCam.SetActive(true);
    //    zoomOutCam.SetActive(false);
    //}

    //void ZoomOut()
    //{
    //    defaultCam.SetActive(false);
    //    zoomInCam.SetActive(false);
    //    zoomOutCam.SetActive(true);
    //}

}
