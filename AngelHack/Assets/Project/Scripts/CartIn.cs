using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartIn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.tag == "Cart") {
      gameObject.GetComponent<Rigidbody>().isKinematic = true;
      gameObject.GetComponent<CartIn>().enabled=false;
      gameObject.GetComponent<OVRGrabbable>().enabled = false;
      gameObject.GetComponent<Collider>().isTrigger = true;
      gameObject.tag = "Cart";
      gameObject.transform.parent = other.gameObject.transform;
    }
  }

}
