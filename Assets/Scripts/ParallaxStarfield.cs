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

    [SerializeField] private List<GameObject> starSpritePrefabs;
    [SerializeField] private float minDepth = 5f;
    [SerializeField] private float maxDepth = 10f;
    [SerializeField] private GameObject starship;
    [SerializeField] private List<StarLayer> starLayers;
    [SerializeField] private float parallaxFactor = 0.1f;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float distanceFromShip;
    [SerializeField] private int numStars;



    private List<GameObject> currentStars = new List<GameObject>();
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
        UpdateStarfield();
    }

    private void UpdateStarfield()
    {
        for (int i = 0; i < currentStars.Count; i++)
        {
            if (Vector3.Distance(starship.transform.position, currentStars[i].transform.position) > distanceFromShip)
            {
                DestroyObject(currentStars[i]);
                currentStars[i] = GenerateStar();
                
            }
        }
    }

    private GameObject GenerateStar()
    {
        Vector3 starPos = new Vector3 ( Random.Range(starship.transform.position.x - distanceFromShip, starship.transform.position.x + distanceFromShip),
                                        Random.Range(starship.transform.position.y - distanceFromShip, starship.transform.position.y + distanceFromShip),
                                        5.0f);
        GameObject star = Instantiate(starSpritePrefabs[Random.Range(0, starSpritePrefabs.Count)], transform);
        star.transform.position = starPos;
        return star;
    }
    
    private void GenerateStarfield()
    {

        for (int i = 0; i < numStars; i++)
        {
            currentStars.Add (GenerateStar());
        }
    }
}
