using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceDestroyer : MonoBehaviour
{
    private readonly WaitForSeconds _wait = new WaitForSeconds(1f);
    private ParticleSystem _particle;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("piece"))
        {
            StartCoroutine(WaitAndDestroy(other.gameObject));
        }
    
    }

    private IEnumerator WaitAndDestroy(GameObject obje)
    {
        yield return _wait;
        obje.SetActive(false);
    }
}
