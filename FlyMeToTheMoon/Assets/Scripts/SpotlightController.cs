using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using Debug = UnityEngine.Debug; // This line specifies using the UnityEngine.Debug class


public class SpotlightController : MonoBehaviour
{
    //public XRController controller;
    private XRController xrController;//to try to fix the assignment issue
    private InputDevice handDevice;
    public Light spotlight;
    private bool isSpotlightOn = false;

    void Start()
    {
        // Get the XRController component from the hand controller game object
        xrController = GetComponent<XRController>();

        // Set the public XRController variable to the private variable
        //SetXRController(xrController);

        // Check if the controller is null
        if (handDevice == null)
        {
            Debug.LogError("input device is not set!");
            return;
        }

        // Get the input device associated with this controller
        handDevice = InputDevices.GetDeviceAtXRNode(xrController.controllerNode);

        // Get the spotlight component
        //spotlight = GetComponentInChildren<Light>();
        Debug.Log("get spotlight");
    }

    public void SetXRController(XRController controller)
    {
        this.xrController = controller;
    }

    void Update()
    {
        // Check if the primary button on the controller is pressed
        if (handDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool isButtonPressed) && isButtonPressed)
        {
            // Toggle the spotlight on and off
            isSpotlightOn = !isSpotlightOn;
            spotlight.enabled = isSpotlightOn;
        }
    }
}
