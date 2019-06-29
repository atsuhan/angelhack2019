using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductFaller : MonoBehaviour
{
  [SerializeField]
  GameObject upperArea;

  [SerializeField]
  GameObject lowerArea;

  [SerializeField]
  List<GameObject> productPrefabs = new List<GameObject>();

  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKey(KeyCode.Space))
    {
      CreateProductInstance(1);
    }
  }

  void CreateProductInstance(int modalId)
  {
    Instantiate(productPrefabs[modalId], Vector3.zero, Quaternion.identity, upperArea.transform);
  }
}
