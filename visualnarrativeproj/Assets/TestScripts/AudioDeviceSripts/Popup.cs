using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Popup : MonoBehaviour {

    // reference to the player
    public GameObject player;
    // Distance at which the tooltip should be activated or deactived
    public float popup_distance;

    Canvas tooltip;

	// Use this for initialization
	void Start () {
        tooltip = GetComponent<Canvas>();
        tooltip.enabled = false;
    }

    // Determines of the tooltip should be activated or not
    bool CanToolTipBeActivated()
    {
        Vector3 player_pos = VRTK_DeviceFinder.PlayAreaTransform().position;
        Vector3 popup_pos = transform.position;

        // too far away to turn on the popup
        Debug.Log("Activate check: " + Vector3.Distance(VRTK_DeviceFinder.PlayAreaTransform().position, popup_pos));
        if (Vector3.Distance(player_pos, popup_pos) > popup_distance)
            return false;

        Vector3 player_look = player.transform.forward;
        Vector3 player_popup_vector = transform.position - player.transform.position;
        float dir = Vector3.Dot(player_look, player_popup_vector);

        // player cannot see the popup
        if (dir < 0)
            return false;

        // popup is visible, we should turn it on
        return true;
    }

    // Determines if the tooltip should be deactivated or not
    bool CanToolTipBeDeactivated()
    {
        Vector3 player_pos = VRTK_DeviceFinder.PlayAreaTransform().position;
        Vector3 popup_pos = transform.position;

        // too close to turn it off
        //VRTK_DeviceFinder;
        Debug.Log("deactivate check: " + Vector3.Distance(VRTK_DeviceFinder.PlayAreaTransform().position, popup_pos));
        if (Vector3.Distance(player_pos, popup_pos) <= popup_distance)
            return false;

        Vector3 player_look = player.transform.forward;
        Vector3 player_popup_vector = transform.position - player.transform.position;
        float dir = Vector3.Dot(player_look, player_popup_vector);

        // player can see the popup
        if (dir < 0)
            return false;

        // popup is not visible, we should turn it off
        return true;
    }

    // Update is called once per frame
    void Update () {
        if (!tooltip.enabled && CanToolTipBeActivated())
            tooltip.enabled = true;
        else if (tooltip.enabled && CanToolTipBeDeactivated())
            tooltip.enabled = false; 
    }
}
