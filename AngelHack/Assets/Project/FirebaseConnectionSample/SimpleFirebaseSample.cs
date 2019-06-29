using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleFirebaseUnity;

public class SimpleFirebaseSample : MonoBehaviour
{
    Firebase firebase;
    void Start()
    {
        firebase = Firebase.CreateNew("https://angelhack2019-d8bc0.firebaseio.com");  // 自分のFirebaseのアドレスを入れる
        
        firebase.OnGetSuccess += (Firebase f,DataSnapshot d) => 
        {
            Debug.Log(d.Value<string>());
        };
        firebase.Child("app").Child("goods").GetValue();
    }
}
