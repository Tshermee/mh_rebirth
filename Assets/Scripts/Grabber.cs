using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour 
{
	[SerializeField]
	private string grabbableTag = "Grabbable";
	[SerializeField]
	private OVRInput.Controller controller;
	[SerializeField]
	private OVRInput.Button button;
	[SerializeField]
	private Transform anchor;
	private List<Grabbable> inRange;
	private Grabbable grabbing;

	private void Awake()
	{
		 inRange = new List<Grabbable> ();
	}

	private void Update ()
	{
		if (!grabbing && OVRInput.GetDown (button, controller))
			TryGrab ();
		else if (grabbing && OVRInput.GetUp (button, controller))
			Drop ();
	}

	private void TryGrab ()
	{
		if (inRange.Count > 0)
		{
			Grabbable grabbable = inRange[inRange.Count - 1];
			if (grabbable.TryGrab (anchor))
			{
				grabbable.OnForcedRelease += OnLocked;
				grabbing = grabbable;
			}
		}
	}

    private void OnLocked()
    {
		grabbing = null;
    }

    private void Drop ()
	{
		if (grabbing)
		{
			grabbing.Release ();
			grabbing = null;
		}
	}

	private void OnTriggerEnter (Collider other)
	{
		Grabbable grabbable;
		if (other.CompareTag (grabbableTag) && (grabbable = other.GetComponent<Grabbable> ()) && grabbable.CanGrab)
			inRange.Add (grabbable);
		if (inRange.Count > 0)
			GetComponent<Renderer> ().material.color = Color.green;
	}

	private void OnTriggerExit (Collider other)
	{
		Grabbable grabbable;
		if (other.CompareTag (grabbableTag) && (grabbable = other.GetComponent<Grabbable> ()))
			inRange.Remove (grabbable);
		if (inRange.Count == 0)
			GetComponent<Renderer> ().material.color = Color.white;
	}
}
