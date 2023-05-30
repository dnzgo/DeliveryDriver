using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery: MonoBehaviour
{

    [SerializeField]
    Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField]
    Color32 noPackageColor = new Color32(1, 1, 1, 1);

    [SerializeField]
    float destroyDelay = .1f;

    bool hasPackage;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(collision.gameObject, destroyDelay);
        }
        if (collision.tag == "Customer" && hasPackage)
        {
            Debug.Log("delivered package");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }

    }

}
