using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NesneHareket : MonoBehaviour
{
    public float hareketHizi=2f;

    void Update()
    {
        transform.Translate(Vector3.down*hareketHizi*Time.deltaTime);

        if(transform.position.y < -Screen.height)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("YokEdici"))
        {
            Destroy(gameObject);
        }
    }
}
