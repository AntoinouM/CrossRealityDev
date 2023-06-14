using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGenerator : MonoBehaviour
{
    [SerializeField] private int targetNumberOfSpheres = 10;
    [SerializeField] private float minSize = 0.5f;
    [SerializeField] private float maxSize = 1.5f;
    [SerializeField] private Color color1 = Color.white;
    [SerializeField] private Color color2 = Color.gray;
    [SerializeField] private float delayBetweenIteration = 0.05f;
    [SerializeField] private float minDestroyTime = 2f;
    [SerializeField] private float maxDestroyTime = 5f;
    [SerializeField] private float minElevationSpeed = 0.1f;
    [SerializeField] private float maxElevationSpeed = 0.5f;
    [SerializeField] private float spreadRange = 2f;


    private int _currentNumberOfSpheres = 0;
    private bool _generatingSpheres = true;
    private MovmentComponent _playerMovementComponent;
    private MeshRenderer _meshRenderer;
    [SerializeField] private Transform _feet;

    private void Start()
    {
        _playerMovementComponent = transform.parent.GetComponent<MovmentComponent>();
        _meshRenderer = GetComponent<MeshRenderer>();
        StartCoroutine(GenerateSpheres());
    }

    private IEnumerator GenerateSpheres()
    {
        while (_currentNumberOfSpheres < targetNumberOfSpheres)
        {
            //if (isGrounded && isMoving)
            {
                GenerateSphere();
                _currentNumberOfSpheres++;
            }
            yield return new WaitForSeconds(delayBetweenIteration); // Delay between generating spheres
        }

        while (_generatingSpheres)
        {
            //if (isGrounded && isMoving)
            {
                GenerateSphere();
            }
            yield return new WaitForSeconds(delayBetweenIteration); // Delay between generating spheres
        }
    }

    private void GenerateSphere()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = new Vector3(_feet.position.x, _feet.position.y, _feet.position.z - Random.Range(0f, 1f));
        sphere.transform.localScale = Vector3.one * Random.Range(minSize, maxSize);
        Renderer sphereRenderer = sphere.GetComponent<Renderer>();
        sphereRenderer.material.color = RandomColorInRange(color1, color2);
        sphereRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off; // Disable shadow casting

        Rigidbody sphereRigidbody = sphere.AddComponent<Rigidbody>();
        sphereRigidbody.velocity = new Vector3(Random.Range(-spreadRange, spreadRange), Random.Range(minElevationSpeed, maxElevationSpeed), 0f);
        
        float destroyTime = Random.Range(minDestroyTime, maxDestroyTime);
        Destroy(sphere, destroyTime);
    }

    private Color RandomColorInRange(Color minColor, Color maxColor)
    {
        float h, s, v;
        Color.RGBToHSV(minColor, out h, out s, out v);
        float h2, s2, v2;
        Color.RGBToHSV(maxColor, out h2, out s2, out v2);
        float randomH = Random.Range(h, h2);
        return Color.HSVToRGB(randomH, s, v);
    }
}
