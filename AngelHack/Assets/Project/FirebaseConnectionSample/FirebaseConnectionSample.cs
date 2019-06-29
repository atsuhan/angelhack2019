using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;

public class FirebaseConnectionSample : MonoBehaviour
{
    void Start()
    {
        Connect();
    }

    public void SetDBURL()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://angelhack2019-d8bc0.firebaseio.com/");
    }
    public void Connect()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
        var dependencyStatus = task.Result;
        if (dependencyStatus == Firebase.DependencyStatus.Available) {
            // Create and hold a reference to your FirebaseApp,
            // where app is a Firebase.FirebaseApp property of your application class.
            Firebase.FirebaseApp app = Firebase.FirebaseApp.DefaultInstance;
            

            // Set a flag here to indicate whether Firebase is ready to use by your app.
        } else {
            UnityEngine.Debug.LogError(System.String.Format(
            "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
            // Firebase Unity SDK is not safe to use here.
        }
        });
    }
}   
