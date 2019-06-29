using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratableObj : MonoBehaviour , IGeneratableObj
{
    [SerializeField]
    private string myID;
    public bool IsMatchID(string id)
    {
        return myID == id;
    }
    public void Generate(Transform generateRoot)
    {
        Instantiate(gameObject,generateRoot);
    }
}
