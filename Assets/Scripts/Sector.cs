using UnityEngine;

public class Sector : MonoBehaviour
{
    public bool IsGood = true;
    public Material GoodMaterial;
    public Material BadMaterial;
    public GameObject Splash;

    private void UpdateMaterial()
    {
        Renderer sectorRenderer = GetComponent<Renderer>();
        sectorRenderer.sharedMaterial = IsGood ? GoodMaterial : BadMaterial;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            Vector3 normal = collision.contacts[0].normal.normalized;
            float dot = Vector3.Dot(normal, Vector3.up);
            Instantiate(Splash, transform.position, Quaternion.identity);
            if (dot < 0.5)
            {
                if (IsGood)
                    player.Bounce();
                                
                else
                    player.Die();
            }
                
        }
            Debug.Log(collision.contacts[0].normal.normalized);


        
         
    }

    private void OnValidate()
    {
        UpdateMaterial();
    }
} 