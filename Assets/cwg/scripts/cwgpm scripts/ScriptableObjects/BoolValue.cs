//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
//[System.Serializable]
public class BoolValue : ScriptableObject
    //, ISerializationCallbackReceiver
{
    public bool initialValue;
    //  [NonSerialized]
    public bool RuntimeValue;

/*
    public void OnAfterDeserialize()
    {
        RuntimeValue = initialValue;
    }

    public void OnBeforeSerialize()
    { }
*/
    //this did not help
    //private void OnEnable()
    // {
    //    initialValue = RuntimeValue;
    //}
}
