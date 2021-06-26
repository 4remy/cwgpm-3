using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class RandomScript : MonoBehaviour
{
    [HideInInspector] // HideInInspector makes sure the default inspector won't show these fields.
    public BoolValue boolValue;

    [HideInInspector]
    public InputField iField;

    [HideInInspector]
    public GameObject Template;

    // ... Update(), Awake(), etc
}

#if UNITY_EDITOR
[CustomEditor(typeof(RandomScript))]
public class RandomScript_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector(); // for other non-HideInInspector fields

        RandomScript script = (RandomScript)target;

        script.boolValue = EditorGUILayout.ObjectField("Bool Value", script.boolValue, typeof(BoolValue), false) as BoolValue;
        if (script.boolValue != null)
        {
            // draw checkbox for the bool
            script.boolValue.initialValue = EditorGUILayout.Toggle("Bool Value Initial Value", script.boolValue.initialValue);
            if (script.boolValue.initialValue) // if bool is true, show other fields
            {
                script.iField = EditorGUILayout.ObjectField("I Field", script.iField, typeof(InputField), true) as InputField;
                script.Template = EditorGUILayout.ObjectField("Template", script.Template, typeof(GameObject), true) as GameObject;
            }
        }
    }
}
#endif
