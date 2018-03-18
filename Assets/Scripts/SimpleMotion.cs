using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (CharacterController))]
public class SimpleMotion : MonoBehaviour 
{
	[SerializeField]
	private OVRInput.Axis2D axis = OVRInput.Axis2D.PrimaryTouchpad;
	[SerializeField]
	private OVRInput.Controller controller = OVRInput.Controller.All;
	[SerializeField]
	private float speed = 1f;
	[SerializeField]
	private Transform forward;
	private CharacterController characterController;
	private Quaternion rotation;

	private void Awake()
	{
		characterController = GetComponent<CharacterController> ();
	}

	private void Update ()
	{
		Vector2 input = OVRInput.Get(axis, controller);
		rotation = Quaternion.Euler (0f, forward.rotation.eulerAngles.y, 0f);
		Vector3 movement = rotation * new Vector3 (input.x, 0f, input.y) * (speed * Time.deltaTime);
		characterController.SimpleMove (movement);
	}
}
