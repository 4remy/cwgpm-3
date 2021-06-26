using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject
{
    public string fullName;
    public Sprite portrait;
    
    [SerializeField] private AnimatorOverrideController _overrideController;
    public AnimatorOverrideController overrideController => _overrideController;
}
