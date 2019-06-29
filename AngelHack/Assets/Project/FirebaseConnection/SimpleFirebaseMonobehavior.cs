using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFirebaseUnity;
using MiniJSON;

public abstract class SimpleFirebaseMonobehavior : MonoBehaviour
{

    public delegate void OnGetOK(Dictionary<string,object> d, List<string> key);
    public event OnGetOK onGetOK;

    public ProductFaller productFaller;

    protected void GetOKHandler(Firebase sender, DataSnapshot snapshot)
    {
        DebugLog("[OK] Get from key: <" + sender.FullKey + ">");
        DebugLog("[OK] Raw Json: " + snapshot.RawJson);

        
        var json = Json.Deserialize (snapshot.RawJson) as Dictionary<string, object>;
        
        Dictionary<string, object> dict = snapshot.Value<Dictionary<string, object>>();
        List<string> keys = snapshot.Keys;



        //Debug.Log(dict.Count);
        if (keys != null)
            foreach (string key in keys)
            {
                DebugLog(key + " = " + dict[key].ToString());

                if(key == "modelId"){
                  productFaller.InstantiateProductPrefab(int.Parse(dict[key].ToString()));
                }


                foreach(var d2 in dict.Values)
                {
                    Debug.Log("fffffffffff " + d2.ToString());
                }
            }
        if(onGetOK != null)
        {
            onGetOK(dict,keys);
        }
    }

    protected void GetFailHandler(Firebase sender, FirebaseError err)
    {
        DebugError("[ERR] Get from key: <" + sender.FullKey + ">,  " + err.Message + " (" + (int)err.Status + ")");
    }

    protected void SetOKHandler(Firebase sender, DataSnapshot snapshot)
    {
        DebugLog("[OK] Set from key: <" + sender.FullKey + ">");
    }

    protected void SetFailHandler(Firebase sender, FirebaseError err)
    {
        DebugError("[ERR] Set from key: <" + sender.FullKey + ">, " + err.Message + " (" + (int)err.Status + ")");
    }

    protected void UpdateOKHandler(Firebase sender, DataSnapshot snapshot)
    {
        DebugLog("[OK] Update from key: <" + sender.FullKey + ">");
    }

    protected void UpdateFailHandler(Firebase sender, FirebaseError err)
    {
        DebugError("[ERR] Update from key: <" + sender.FullKey + ">, " + err.Message + " (" + (int)err.Status + ")");
    }

    protected void DelOKHandler(Firebase sender, DataSnapshot snapshot)
    {
        DebugLog("[OK] Del from key: <" + sender.FullKey + ">");
    }

    protected void DelFailHandler(Firebase sender, FirebaseError err)
    {
        DebugError("[ERR] Del from key: <" + sender.FullKey + ">, " + err.Message + " (" + (int)err.Status + ")");
    }

    protected void PushOKHandler(Firebase sender, DataSnapshot snapshot)
    {
        DebugLog("[OK] Push from key: <" + sender.FullKey + ">");
    }

    protected void PushFailHandler(Firebase sender, FirebaseError err)
    {
        DebugError("[ERR] Push from key: <" + sender.FullKey + ">, " + err.Message + " (" + (int)err.Status + ")");
    }

    protected void GetRulesOKHandler(Firebase sender, DataSnapshot snapshot)
    {
        DebugLog("[OK] GetRules");
        DebugLog("[OK] Raw Json: " + snapshot.RawJson);
    }

    protected void GetRulesFailHandler(Firebase sender, FirebaseError err)
    {
        DebugError("[ERR] GetRules,  " + err.Message + " (" + (int)err.Status + ")");
    }


    protected void DebugLog(string str)
    {
        Debug.Log(str);
    }

    protected void DebugWarning(string str)
    {
        Debug.LogWarning(str);
    }

    protected void DebugError(string str)
    {
        Debug.LogError(str);
    }
}
