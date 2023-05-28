using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SpriteRenderer))]
public class Starship : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float rotationSpeed = 180.0f;
    [SerializeField] private SolarSystem solarSystem;

    private static Starship instance;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Update()
    {
        HandleMovement();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void HandleMovement()
    {
        float rotationInput = Input.GetAxis("Horizontal");
        float thrustInput = Input.GetAxis("Vertical");

        float solarSystemBoundary = solarSystem.BoundaryDistance;
        Vector2 newPosition = transform.up * thrustInput;
        float distanceToCenter = Vector2.Distance(newPosition, solarSystem.transform.position);

        // Rotate the starship based on A and D keys
        transform.Rotate(Vector3.forward, -rotationInput * rotationSpeed * Time.deltaTime);

Debug.Log (distanceToCenter);
        // Move the starship in the direction it's pointing with W and S keys
        if (distanceToCenter <= solarSystemBoundary)
        {
            Vector3 moveDirection = transform.up * thrustInput;
            transform.position += moveDirection * speed * Time.deltaTime;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Add any logic needed when a new scene is loaded, such as changing the ship's position
    }
}