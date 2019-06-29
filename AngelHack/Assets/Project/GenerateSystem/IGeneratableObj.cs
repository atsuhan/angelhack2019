using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGeneratableObj
{
    bool IsMatchID(string id);
    void Generate(Transform generateRoot);
}
