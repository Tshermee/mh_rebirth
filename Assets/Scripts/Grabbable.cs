using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class Grabbable : MonoBehaviour 
{
	public event Action OnForcedRelease;
	public event Action OnGrabbed;
	public event Action OnReleased;

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
		if (OnGrabbed != null)
			OnGrabbed ();
		return true;
	}

	public void Release ()
	{
		rigidbody.isKinematic = false;
		isGrabbed = false;
		transform.SetParent (null);
		if (OnReleased != null)
			OnReleased ();
	}

	public void Lock (Transform lockPosition)
	{
		isLocked = true;
		rigidbody.isKinematic = true;
		transform.SetParent (lockPosition);
		transform.localPosition = Vector3.zero;
		if (OnReleased != null)
			OnReleased ();
		if (OnForcedRelease != null)
			OnForcedRelease ();
	}
}
