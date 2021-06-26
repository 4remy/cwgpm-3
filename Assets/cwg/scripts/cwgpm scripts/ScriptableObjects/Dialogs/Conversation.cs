using UnityEngine;

[System.Serializable]
public struct Line
{
    public Character character;

    public Emotion emotion;

    [TextArea(2, 5)]
    public string text;

    public enum Emotion
    {
        Default,
        Happy,
        Angry,
        Annoyed,
        Sad
        // tired,
        // sad,
        // specific
    }
}

[CreateAssetMenu(fileName = "New Conversation", menuName = "Conversation")]
public class Conversation : ScriptableObject
{
    public Character speakerLeft;
    public Character speakerRight;
    public Line[] lines;
}
