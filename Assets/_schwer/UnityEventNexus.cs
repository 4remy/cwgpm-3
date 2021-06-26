using UnityEngine;

public class UnityEventNexus : ScriptableObject {
    // UnityEvents require a reference to an object.
    // Since a ScriptableObject is an asset and not a scene object,
    // it can be referenced across scenes and within prefabs.
    public void Log(string message) => Debug.Log(message);
}
