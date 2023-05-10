using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 offset;

    private void Update()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z) + offset;
        }
    }
}