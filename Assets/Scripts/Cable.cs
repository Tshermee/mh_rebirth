using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour 
{
	[SerializeField]
	private Rigidbody[] rigidbodies;
	[SerializeField]
	private float maxDistance = 0.3f;
	[SerializeField]
	private float spring;
	
	private void Start () 
	{
		Rigidbody last = rigidbodies[0];
		for (int i = 1; i < rigidbodies.Length; i++)
		{
			SpringJoint joint = rigidbodies[i].gameObject.AddComponent<SpringJoint> ();
			joint.connectedBody = last;
			joint.maxDistance = maxDistance;
			joint.spring = spring;
			last = rigidbodies [i];
		}	
	}

	private void SetValues (SpringJoint joint)
	{
		joint.maxDistance = 0.5f;
		joint.minDistance = 0.5f;
		joint.spring = 30f;
	}
}
