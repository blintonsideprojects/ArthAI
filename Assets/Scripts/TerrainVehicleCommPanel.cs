using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TerrainVehicleCommPanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI titleText;

    // Start is called before the first frame update
    void Start()
    {
        titleText.text = "Ship Log";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
