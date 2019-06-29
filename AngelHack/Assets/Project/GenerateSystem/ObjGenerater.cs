using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjGenerater : MonoBehaviour
{
    [SerializeField] private Transform rootObj;
    private IGeneratableObj[] generatables = new IGeneratableObj[]{};
    void Start()
    {
        generatables = GetComponentsInChildren<IGeneratableObj>();
    }

    public void Generate(string targetID)
    {
        for(int i=0; i<generatables.Length; i++)
        {
            if(generatables[i].IsMatchID(targetID))
            {
                generatables[i].Generate(rootObj);
            }
        }
    }
}
