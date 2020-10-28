using System.Collections;
using System.Collections.Generic;
using UISystems;
using UnityEngine;
using UnityEngine.UI;

public class Ball_Collision : MonoBehaviour
{

    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        BoxCollider[] boxColliders = other.gameObject.transform.GetComponentsInChildren<BoxCollider>();
        Rigidbody[] objChild = other.gameObject.transform.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody Cube in objChild)
        {
            //Cube.gameObject.tag = "piece";
            //Cube.gameObject.GetComponent<Collider>().isTrigger = false;
            StartCoroutine(WaitAndDestroy(Cube.gameObject));
            Cube.constraints = RigidbodyConstraints.None;
            Cube.mass = 1.0f;
            Cube.drag = 0f;
            Cube.angularDrag = 0.05f; ;
            Cube.useGravity = true;
            StartCoroutine(enumerator());
        }
        foreach (BoxCollider box in boxColliders)
        {
            box.enabled = false;
        }
    }
    private IEnumerator WaitAndDestroy(GameObject obje)
    {
        yield return new WaitForSeconds(1);
        obje.SetActive(false);
    }
}
