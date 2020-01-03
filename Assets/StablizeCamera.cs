using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StablizeCamera : MonoBehaviour {

    public GameObject boat;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position = boat.transform.position;
        //transform.rotation = Quaternion.Inverse(UnityEngine.XR.InputTracking.GetLocalRotation(UnityEngine.XR.XRNode.CenterEye));
        //transform.position = boat.transform.position  - UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.CenterEye);
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            Debug.Log(UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.CenterEye));
            transform.position = boat.transform.position - UnityEngine.XR.InputTracking.GetLocalPosition(UnityEngine.XR.XRNode.CenterEye);



        }
    }
}
