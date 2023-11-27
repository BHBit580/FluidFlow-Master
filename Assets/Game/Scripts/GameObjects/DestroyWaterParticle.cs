using UnityEngine;

public class DestroyWaterParticle : MonoBehaviour
{
    [SerializeField] private float minYDistance = -500f;    
    void Update()
    {
        foreach (Transform child in transform)                   //FOR PERFORMANCE REASONS, IT WILL DELETE THE PARTICLES THAT ARE TOO FAR AWAY FROM THE CAMERA
        {
            if (child.position.y < minYDistance)
            {
                Destroy(child.gameObject);
            }
        }
    }
}