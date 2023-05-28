using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField] private GameObject miniStarPrefab;
    [SerializeField] private GameObject miniPlanetPrefab;
    [SerializeField] private GameObject miniShipPrefab;
    [SerializeField] private float scale = 0.1f; // The scale of objects in the mini map.
    [SerializeField] private Camera miniMapCamera;
    [SerializeField] private Starship playerShip;

    private bool initialized = false;
    private GameObject miniShipObject;
    private Vector3 currentPos;
    private float scaledDistance;

    //private Vector3 parentPos;
    void Start()
    {
        currentPos = this.gameObject.GetComponent<RectTransform>().position;
        //parentPos = this.gameObject.transform.parent.GetComponent<RectTransform>().position;
        //Debug.Log (this.gameObject.GetComponent<RectTransform>().position.x);
        //Debug.Log (this.gameObject.GetComponent<RectTransform>().position.y);
    }

    public void InitializeMiniMap(SolarSystem solarSystem)
    {
        scaledDistance = solarSystem.BoundaryDistance / (this.gameObject.GetComponent<RectTransform>().rect.width/1.55f);
        Debug.Log (this.gameObject.GetComponent<RectTransform>().rect.width);
        CreateMiniShip(playerShip.GetComponent<Starship>());
        CreateMiniStar(solarSystem.Star);

        foreach (Planet planet in solarSystem.Planets)
        {
           CreateMiniPlanet(planet);
        }


        initialized = true;
    }

    private void Update()
    {
        if (initialized)
        {
            Vector3 shipScalePosition = playerShip.transform.position / scaledDistance;
            Vector3 miniShipPosition = new Vector3 (currentPos.x + shipScalePosition.x, currentPos.y + shipScalePosition.y, 1);
            miniShipObject.transform.localScale = new Vector3 (scale, scale, scale);
            miniShipObject.transform.position = new Vector3 (miniShipPosition.x, miniShipPosition.y, miniShipPosition.z);
        }
    }

    private void CreateMiniStar(Star star)
    {
        GameObject miniStarObject = Instantiate(miniStarPrefab, currentPos, Quaternion.identity, transform);
        miniStarObject.transform.localScale = new Vector3 (scale, scale, scale);
        // Initialize the mini star's representation here, if necessary.
    }

    private void CreateMiniPlanet(Planet planet)
    {
        Vector3 scalePosition = planet.transform.position / scaledDistance;
        Vector3 miniPlanetPosition = new Vector3 (currentPos.x + scalePosition.x, currentPos.y + scalePosition.y, 1);
        GameObject miniPlanetObject = Instantiate(miniPlanetPrefab, miniPlanetPosition, Quaternion.identity, transform);
        miniPlanetObject.transform.localScale = new Vector3 (scale, scale, scale);
        /*miniPlanetObject.layer = LayerMask.NameToLayer("UI");*/
        // Initialize the mini planet's representation here, if necessary.
    }

    private void CreateMiniShip(Starship ship)
    {
        Vector3 shipScalePosition = ship.transform.position / scaledDistance;
        Vector3 miniShipPosition = new Vector3 (currentPos.x + shipScalePosition.x, currentPos.y + shipScalePosition.y, 1);
        miniShipObject = Instantiate(miniShipPrefab, miniShipPosition, Quaternion.identity, transform);
        miniShipObject.transform.localScale = new Vector3 (scale, scale, scale);
        // Initialize the mini planet's representation here, if necessary.
    }
}