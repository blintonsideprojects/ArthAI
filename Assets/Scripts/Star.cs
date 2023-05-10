using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Star : MonoBehaviour
{
    [SerializeField] private string starName;
    [SerializeField] private int starSize;
    [SerializeField] private Sprite starSprite;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InitializeStar();
    }

    public void InitializeStar()
    {
        gameObject.name = starName;
        int randomSize = Random.Range(1, 11); // Random size between 1 and 10
        transform.localScale = new Vector3(randomSize, randomSize, 1);
        spriteRenderer.sprite = starSprite;
    }
}