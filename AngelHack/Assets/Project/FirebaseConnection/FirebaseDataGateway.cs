using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using SimpleFirebaseUnity;


public class FirebaseDataGateway : SimpleFirebaseMonobehavior
{
    private Firebase firebase;
    private Firebase app;
    private Firebase goods;

    private List<string> dataIDs = new List<string>()
    {
        "dfdertaerff",
        "dhsfiuashfiadksfj",
        "fafafafd",
        "kfjaksjfldajflk"
    };
    private List<string> dataCache = new List<string>();
    private int prevDataCount = 0;

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
            //要素数が増えた時・・
            if(dic != null && dic.Count > prevDataCount)
            {
                //この時のキー(keys)とキャッシュのキーを比べる
                foreach(var k in keys)
                {
                    //dataCacheがそのキーを含んでいないのであれば・・
                    if(!dataCache.Contains(k))
                    {
                        //そのキーを加える
                        dataCache.Add(k);
                        //kを使ってdataIDsを参照し、リストと合致するものをInstanciate
                        // Dictionary<string,object> temp = dic[k];
                        // Debug.Log(dic[k]);
                        RequestValueFromChild(goods,k);
                        // ProductFaller.InstantiateProductPrefab();
                    }
                }
            }
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
            //RequestValueFromChild(goods,"dfdertaerff");
            //ここで要素数が変わったかどうかをチェックして、変わった時に何が変わったのかを検出する
            //変わった要素のIDをキャッシュしておいて、それを参照する挙動
            RequestValue(goods);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
