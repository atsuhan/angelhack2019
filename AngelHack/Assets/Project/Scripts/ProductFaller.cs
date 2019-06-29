using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductFaller : MonoBehaviour
{
  [SerializeField]
  GameObject instanceParrent;

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
    if (Input.GetKeyDown(KeyCode.Space))
    {
      InstantiateProductPrefab(1);
    }
  }

  void InstantiateProductPrefab(int modalId)
  {
    Instantiate(
      productPrefabs[modalId],
      GetProductInitRandomPos(),
      Random.rotation,
      instanceParrent.transform
    );
  }

  Vector3 GetProductInitRandomPos()
  {
    Vector3 upperPos = upperArea.transform.position;
    float upperLengthX = upperArea.transform.localScale.x * 10;
    float upperLengthZ = upperArea.transform.localScale.z * 10;
    float posX = Random.Range(upperPos.x - (upperLengthX / 2), upperPos.x + (upperLengthX / 2));
    float posZ = Random.Range(upperPos.z - (upperLengthZ / 2), upperPos.z + (upperLengthZ / 2));
    return new Vector3(posX, upperPos.y, posZ);
  }
}
