using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private int frames = 0;
    private bool destroy = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            destroy = true;
        }
    }
    private void Update()
    {
        if (destroy)
        {
            frames++;
        }
        if (frames == 100)
        {
            Destroy(this.gameObject);
            destroy = false;
            frames = 0;
        }
    }
}
