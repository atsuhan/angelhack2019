using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFirebaseUnity;

public class SimpleFirebaseSample : SimpleFirebaseMonobehavior
{

    private Firebase firebase;

    void Start()
    {
        Initialize("https://angelhack2019-d8bc0.firebaseio.com");
        SampleCaaaaaaaall();
    }


    private void Initialize(string projectPath)
    {
        firebase = Firebase.CreateNew(projectPath);

        // Init callbacks
        firebase.OnGetSuccess += GetOKHandler;
        firebase.OnGetFailed += GetFailHandler;
        firebase.OnSetSuccess += SetOKHandler;
        firebase.OnSetFailed += SetFailHandler;
        firebase.OnUpdateSuccess += UpdateOKHandler;
        firebase.OnUpdateFailed += UpdateFailHandler;
        firebase.OnPushSuccess += PushOKHandler;
        firebase.OnPushFailed += PushFailHandler;
        firebase.OnDeleteSuccess += DelOKHandler;
        firebase.OnDeleteFailed += DelFailHandler;
    }

    private void SampleCaaaaaaaall()
    {
        Firebase app = firebase.Child("app", true);
        Firebase goods = app.Child("goods", true);
        RequestValue(goods);
    }

    public void RequestValue(Firebase target)
    { 
        target.GetValue();
    }
    public void RequestValueFromChild(Firebase targetRoot, string targetKey)
    {
        targetRoot.Child(targetKey,true).GetValue();
    }
}
