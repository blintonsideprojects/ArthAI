using TMPro;
using UnityEngine;

public class CoordinateDisplay : MonoBehaviour
{
    [SerializeField] private GameObject starship;
    [SerializeField] private TextMeshProUGUI coordinateText;

    private void Update()
    {
        Vector3 shipPosition = starship.transform.position;
        coordinateText.text = $"X: {shipPosition.x:0.00}, Y: {shipPosition.y:0.00}";
    }
}