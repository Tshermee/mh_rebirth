using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (LineRenderer))]
[RequireComponent (typeof (Grabbable))]
public class Connectable : MonoBehaviour 
{
	[SerializeField]
	private GameObject target;
	[SerializeField]
	private LineRenderer line;
	private Grabbable grabbable;

	private void Awake ()
	{
		grabbable = GetComponent<Grabbable> ();
	}

	private void Start ()
	{
		line.enabled = false;
		line.SetPosition (0, target.transform.position);
		grabbable.OnGrabbed += OnGrabbed;
		grabbable.OnReleased += OnReleased;
	}

    private void OnReleased()
    {
		line.enabled = false;
    }

    private void OnGrabbed()
    {
		line.enabled = true;
    }

    private void OnTriggerEnter (Collider other)
	{
		if (other.gameObject == target)
			grabbable.Lock (target.transform);
	}

	private void Update ()
	{
		line.SetPosition (1, transform.position);
	}
}
