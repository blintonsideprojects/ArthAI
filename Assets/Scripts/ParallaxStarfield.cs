using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxStarfield : MonoBehaviour
{
    [System.Serializable]
    public class StarLayer
    {
        public GameObject starSpritePrefab;
        public int starCount;
        public float minScale;
        public float maxScale;
        public float depth;
    }

    [SerializeField] private float minDepth = 5f;
    [SerializeField] private float maxDepth = 10f;
    [SerializeField] private GameObject starship;
    [SerializeField] private List<StarLayer> starLayers;
    [SerializeField] private float parallaxFactor = 0.1f;
    [SerializeField] private Camera mainCamera;

    private Vector3 previousStarshipPosition;

    private void Start()
    {
        previousStarshipPosition = starship.transform.position;
        GenerateStarfield();
    }

    private void Update()
    {
        Vector3 starshipMovement = starship.transform.position - previousStarshipPosition;
        Vector3 parallaxOffset = starshipMovement * parallaxFactor;

        transform.position += parallaxOffset;
        previousStarshipPosition = starship.transform.position;
    }

    private void GenerateStarfield()
    {
        Vector3 shipViewportPos = mainCamera.WorldToViewportPoint(starship.transform.position);

        foreach (StarLayer layer in starLayers)
        {
            for (int i = 0; i < layer.starCount; i++)
            {
                GameObject star = Instantiate(layer.starSpritePrefab, transform);
                Vector3 viewportPosition = new Vector3(
                    Random.Range(0f, 1f),
                    Random.Range(0f, 1f),
                    mainCamera.WorldToViewportPoint(transform.position).z
                );

                Vector3 starPosition = Random.Range (0, 2) > 0 ? new Vector3 (shipViewportPos.x + viewportPosition.x, shipViewportPos.y + viewportPosition.y, layer.depth) : new Vector3 (shipViewportPos.x - viewportPosition.x, shipViewportPos.y - viewportPosition.y, layer.depth);
                star.transform.position = mainCamera.ViewportToWorldPoint(starPosition);
                star.transform.position = new Vector3(star.transform.position.x, star.transform.position.y, layer.depth);
                float scale = Random.Range(layer.minScale, layer.maxScale);
                star.transform.localScale = new Vector3(scale, scale, 1f);
            }
        }
    }
}
