using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public int testint;
    public float f;
    public string s;
    public int[] ints;
    public List<float> floats;
    public C cl;

    [System.Serializable]
    public struct C
    {
        public int i;
        public float f;
    }
   
    void OnValidate()
    {
        PlayerPrefs.SetInt("testint", 34);
        PlayerPrefs.Save();
    }
}
