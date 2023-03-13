using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColour = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackageColour = new Color32 (1, 1, 1, 1);

    bool hasPackage;

    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch!");
    }

    [SerializeField] float destroyDelay = 1;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColour;
            Destroy(other.gameObject, destroyDelay);
        }

        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("delivered package");
            hasPackage = false;
            spriteRenderer.color = noPackageColour;
        }
    }
}
