using System.Collections;
using System.Collections.Generic;
using UISystems;
using UnityEngine;
using UnityEngine.UI;

public class UpstairsCheck : MonoBehaviour
{
    public GameObject[] upStairs;
    public GameObject[] floorParts;

    void Update()
    {
        if (floorCheck())
        {
             StartCoroutine(bekle(upStairs));
        }
    }

    private IEnumerator bekle(GameObject[] upstairs)
    {
        yield return new WaitForSeconds(1);
        Debug.Log("bekledi");
       foreach (var floor in upStairs)
       {
           Rigidbody[] objChild = floor.transform.GetComponentsInChildren<Rigidbody>(); 
           foreach (Rigidbody Cube in objChild)
           {
               Cube.gameObject.tag = "piece";
               Debug.Log("bekledi");
               Cube.gameObject.GetComponent<Collider>().isTrigger = false;
               Cube.constraints = RigidbodyConstraints.None;
              Cube.mass = 1.0f;
              Cube.drag = 0f;
              Cube.angularDrag = 0.05f; 
              Cube.useGravity = true;
           }
       }
        
    }
    public bool floorCheck()
    {
        foreach (var part in floorParts)
        {
            if (part.GetComponent<BoxCollider>().enabled == true)
            {
                return false;
            }

        }
        return true;
    }
  
    
}
