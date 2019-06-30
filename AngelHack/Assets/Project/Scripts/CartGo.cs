using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartGo : MonoBehaviour
{

  [SerializeField] Animator cartGo;
  [SerializeField] GameObject done;
  // Start is called before the first frame update
  void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetKeyDown(KeyCode.C) || (OVRInput.GetDown(OVRInput.RawButton.A) && OVRInput.GetDown(OVRInput.RawButton.B)))
    {
      cartGo.Play("CartGo");
      Invoke("DelayMethod", 4);
      
    }

  }


  void DelayMethod() {
    done.SetActive(true);
  }
}
