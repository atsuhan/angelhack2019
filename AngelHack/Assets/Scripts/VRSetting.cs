using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRSetting : MonoBehaviour
{
  void Start() {
    OVRManager.tiledMultiResLevel = OVRManager.TiledMultiResLevel.LMSHigh;
    UnityEngine.XR.XRSettings.eyeTextureResolutionScale = 1.75f;
    OVRPlugin.chromatic = true;
    QualitySettings.antiAliasing = 4;
    OVRManager.display.displayFrequency = 72f;
    OVRManager.cpuLevel = 2;
    OVRManager.gpuLevel = 2;
  }
}
