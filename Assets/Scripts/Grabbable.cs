using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class Grabbable : MonoBehaviour 
{
	private bool isLocked;
	private bool isGrabbed;
	private new Rigidbody rigidbody;

	public bool CanGrab
	{
		get
		{
			return !isLocked && !isGrabbed;
		}
	}

	private void Awake ()
	{
		rigidbody = GetComponent<Rigidbody> ();
	}

	public bool TryGrab (Transform anchor)
	{
		if (!CanGrab) return false;
		isGrabbed = true;
		transform.SetParent (anchor);
		transform.localPosition = Vector3.zero;
		rigidbody.isKinematic = true;
		return true;
	}

	public void Release ()
	{
		rigidbody.isKinematic = false;
		isGrabbed = false;
		transform.SetParent (null);
	}
}
