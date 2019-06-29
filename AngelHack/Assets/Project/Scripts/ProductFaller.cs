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
  }

  void CreateProductInstance(int modalId)
  {

  }
}
