using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
	[SerializeField] private bool isOnMoon;
	[SerializeField] private Vector3 rotation;
	[SerializeField] private float rotationSpeed = 0;

	void FixedUpdate()
	{
		if (isOnMoon) transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
		else transform.Rotate(rotation, rotationSpeed * Time.deltaTime);
	}
}