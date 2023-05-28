using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Planet : MonoBehaviour
{
    public enum SurfaceType
    {
        Rocky,
        Plains,
        Ice,
        Desert,
        Oceanic,
        Molten,
        Gas
    }

    [SerializeField] private string planetName;
    [SerializeField] private int planetSize;
    [SerializeField] private Color planetColor;
    [SerializeField] private SurfaceType surfaceType;
    [SerializeField] private Sprite[] surfaceTypeSprites;
    [SerializeField] private int orbitNumber;

    public int OrbitNumber
    {
        get { return orbitNumber; }
    }

    public Sprite PlanetSprite => surfaceTypeSprites[(int)surfaceType];

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
    }

    public void InitializePlanet(int oNumber)
    {
        gameObject.name = planetName;
        transform.localScale = new Vector3(planetSize, planetSize, 1);
        spriteRenderer.color = planetColor;
        spriteRenderer.sprite = surfaceTypeSprites[(int)surfaceType];
        orbitNumber = oNumber;
    }
}