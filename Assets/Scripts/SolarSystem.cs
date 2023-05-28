using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    [SerializeField] private GameObject starPrefab;
    [SerializeField] private GameObject planetPrefab;
    [SerializeField] private int minPlanets = 0;
    [SerializeField] private int maxPlanets = 9;
    [SerializeField] private int orbitMultiplier = 5;
    [SerializeField] private MiniMap miniMap;

    private Star star;
    public Star Star => star;
    
    private List<Planet> planets = new List<Planet>();
    public List<Planet> Planets => planets;

    public float BoundaryDistance
    {
        get { return (maxPlanets + 1) * orbitMultiplier; }
    }

    private void Start()
    {
        InitializeSolarSystem();
    }

    public void InitializeSolarSystem()
    {
        CreateStar();
        int planetCount = Random.Range(minPlanets, maxPlanets + 1);
        for (int i = 0; i < 9; i++)
        {
            CreatePlanet(i + 1);
        }

        miniMap.InitializeMiniMap(this);
    }

    private void CreateStar()
    {
        GameObject starObject = Instantiate(starPrefab, transform.position, Quaternion.identity, transform);
        star = starObject.GetComponent<Star>();
        star.InitializeStar();
    }

    private void CreatePlanet(int orbitNumber)
    {
        float orbitDistance = orbitNumber * orbitMultiplier; // Adjust this value to set the distance between orbits
        float randomAngle = Random.Range(0f, 360f);
        Vector3 planetPosition = new Vector3(transform.position.x + orbitDistance * Mathf.Cos(randomAngle * Mathf.Deg2Rad),
                                             transform.position.y + orbitDistance * Mathf.Sin(randomAngle * Mathf.Deg2Rad),
                                             transform.position.z);
        GameObject planetObject = Instantiate(planetPrefab, planetPosition, Quaternion.identity, transform);
        Planet planet = planetObject.GetComponent<Planet>();
        planet.InitializePlanet(orbitNumber);
        planets.Add(planet);
    }
}