using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundSphere : MonoBehaviour
{
    [SerializeField] private Transform planetCenter;
    [SerializeField] private float minRadius = 500;
    [SerializeField] private float maxRadius = 500;
    [SerializeField] private float rotationSpeed = 1;
    
    private Vector3 direction = new Vector3(1f, 0f, 1f).normalized;
    private float currentRadius;

    private void Start()
    {
        currentRadius = Random.Range(minRadius, maxRadius);
    }

    private void Update()
    {
        float angle = Time.time * rotationSpeed;
        Vector3 orbitPosition = Quaternion.Euler(direction * angle) * (Vector3.forward * currentRadius);
        transform.position = planetCenter.position + orbitPosition;
        
        transform.LookAt(planetCenter);
    }

    private void LateUpdate()
    {
        float distance = Vector3.Distance(transform.position, planetCenter.position);
        currentRadius = Mathf.Lerp(minRadius, maxRadius, distance / maxRadius);
    }
}
