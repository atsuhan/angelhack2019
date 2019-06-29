using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class FirebaseConnectionSample : MonoBehaviour
{
    void Start()
    {
        GetDatabaseData();
    }

    public void GetDatabaseData()
    {
      Debug.Log("GetDatabaseData is called");
      FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://angelhack2019-d8bc0.firebaseio.com/");
      DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
      Debug.Log(reference);

      reference
      .GetValueAsync().ContinueWith(task => {
        if (task.IsFaulted) {
          // Handle the error...
          Debug.Log("Failed");
        }
        else if (task.IsCompleted) {
          DataSnapshot snapshot = task.Result;
          // Do something with snapshot...
          Debug.Log(snapshot.Child("test").Value);
        }
      });
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
