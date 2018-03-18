using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VREyeRaycaster : MonoBehaviour {

	// Use this for initialization
	void Start () {

		VRInteractiveItem interactible = hit.collider.GetComponent<VRInteractiveItem>();    //attempt to get the VRInteractiveItem on the hit object
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
