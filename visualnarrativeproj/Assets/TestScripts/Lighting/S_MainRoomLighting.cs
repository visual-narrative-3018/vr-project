using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class S_MainRoomLighting : MonoBehaviour {

    // Lights in the main room
    public Light[] startingLights;
    public Light[] statueLights;
    public Light[] leadingLights;

    // Intensities for each light
    public float startingLightIntensity;
    public float statueLightIntensity;
    public float leadingLightsIntensity;

    // Let's us know which lights are on
    private bool isStartingLightsOn = true;
    private bool isLeadingLightsOn  = false;
    private bool isStatueLightsOn   = false;

    // Listener for when the opening audio finishes
    private Action someListener;

    // Use this for initialization
    void Start () {

        foreach (Light light in startingLights)
        {
            light.intensity = startingLightIntensity;
        }

        foreach (Light light in statueLights)
        {
            light.intensity = 0;
        }

        foreach (Light light in leadingLights)
        {
            light.intensity = 0;
        }

        // Initialize the listener
        EventManager.StartListening("mainroomLeadingLights", turningLeadingLightsOn);
    }

    void turningLeadingLightsOn()
    {
        if (isLeadingLightsOn)
            Debug.Log("Leading lights got turned before they were supposed to! Argh!");

        foreach (Light light in leadingLights)
        {
            light.intensity = leadingLightsIntensity;
        }

        isLeadingLightsOn = true;
    }

    // Update is called once per frame
    void Update () {

        // Turn off starting light and turn on statue light
        if (Input.GetKeyDown("[4]") && isStartingLightsOn)
        {
            Debug.Log("4 key pressed");
            foreach (Light light in startingLights)
            {
                light.intensity = 0;
            }

            foreach (Light light in statueLights)
            {
                light.intensity = statueLightIntensity;
            }

            isStartingLightsOn = false;
            isStatueLightsOn = true;
        }
    }
}
