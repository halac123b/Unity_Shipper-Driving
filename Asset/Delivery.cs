using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Delivery : MonoBehaviour
{
    bool hasPacket = false;
    [SerializeField] float destroyDelay = 1.0f;
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 packageColor = new Color32(1, 1, 1, 1);
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageColor;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("The car hit something!");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && hasPacket == false)
        {
            Debug.Log("Packaged is collected");
            hasPacket = true;
            spriteRenderer.color = packageColor;
            Destroy(other.gameObject, destroyDelay);
        }
        else if (other.tag == "Customer" && hasPacket == true)
        {
            Debug.Log("Package delivered");
            hasPacket = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
