using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour {

    public Transform target;            // The position that that camera will be following.
    public float smoothing = 5f;        // The speed with which the camera will be following.
    public Text image;
    Vector3 offset;                     // The initial offset from the target.
   
    PhotonView photonView;
    void Awake()
    {

        //offset = transform.position - target.position;
        

        photonView = GetComponent<PhotonView>();

        if (photonView.IsMine)
        {
            //print("Ismine");
            gameObject.GetComponent<Camera>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Camera>().enabled = false;
            gameObject.GetComponent<AudioListener>().enabled = false;
        }
    }

    void FixedUpdate()
    {
        CamFollow();
       
        
    }

   
    public void CalcOffcet()
    {
        // Calculate the initial offset.
        offset = transform.position - target.transform.position;
       
    }
    
       
    
    public void CamFollow()
    {
        
        if (photonView.IsMine)
        {  
            // Create a postion the camera is aiming for based on the offset from the target.
            Vector3 targetCamPos = target.transform.position + offset;

            // Smoothly interpolate between the camera's current position and it's target position.
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        }
        
    }
}
