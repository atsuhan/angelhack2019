using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SimpleFirebaseUnity;


public class FirebaseDataGateway : SimpleFirebaseMonobehavior
{
    public List<GoodsItem> parsedItems = new List<GoodsItem>();
    private Firebase firebase;
    private Firebase app;
    private Firebase goods;

    void Start()
    {
        Initialize("https://angelhack2019-d8bc0.firebaseio.com");
        StartCoroutine(Request(2f));
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

        app = firebase.Child("app",true);
        goods = app.Child("goods",true);

        onGetOK += (dic,keys) => 
        {
            Debug.Log("ssssssssssss"+dic["dfdertaerff"]);
            
        };
    }

    public void RequestValue(Firebase target)
    { 
        target.GetValue();
    }
    public void RequestValueFromChild(Firebase targetRoot, string targetKey)
    {
        targetRoot.Child(targetKey,true).GetValue();
    }

    private IEnumerator Request(float waitTime)
    {
        while(true)
        {
            RequestValue(goods);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
