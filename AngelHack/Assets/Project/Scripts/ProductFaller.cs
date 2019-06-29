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
    if (Input.GetKeyDown(KeyCode.Space)|| OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
    {
      int modelId = Random.Range(0, 4);
      InstantiateProductPrefab(modelId);
    }
  }

  public void InstantiateProductPrefab(int modalId)
  {
    GameObject productInstance = Instantiate(
      productPrefabs[modalId],
      GetProductInitRandomPos(),
      Random.rotation,
      instanceParrent.transform
    );
  }

  Vector3 GetProductInitRandomPos()
  {
    Vector3 upperPos = upperArea.transform.position;
    float posLengthX = upperArea.transform.localScale.x * 10;
    float posLengthZ = upperArea.transform.localScale.z * 10;
    float posX = Random.Range(upperPos.x - (posLengthX / 2), upperPos.x + (posLengthX / 2));
    float posZ = Random.Range(upperPos.z - (posLengthZ / 2), upperPos.z + (posLengthZ / 2));
    return new Vector3(posX, upperPos.y, posZ);
  }
}
