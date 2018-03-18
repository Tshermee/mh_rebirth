using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour 
{
	[SerializeField]
	private OVRInput.Controller controller;
	[SerializeField]
	private OVRInput.Button button;

	private void Update ()
	{
		if (OVRInput.GetDown (button, controller))
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
