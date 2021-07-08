using UnityEngine;

namespace Schwer.ItemSystem {
    [CreateAssetMenu(menuName = "Item System/Crafting Recipe")]
    public class Recipe : ScriptableObject {
        public Item output = default;
        [Min(1)]public int outputAmount = 1;
        [Space]
        public Inventory input = new Inventory();

        public bool Matches(Inventory ingredients) {
            // Exit early if the number of different items do not match
            if (input.Count != ingredients.Count) return false;

            // Compare amounts for each item
            foreach (var item in ingredients.Keys) {
                if (input[item] != ingredients[item]) return false;
            }

            return true;
        }

#if UNITY_EDITOR
        // Needed in order to allow changes to the Inventory in the editor to be saved.

        private void OnEnable() => input.OnContentsChanged += MarkDirtyIfChanged;
        private void OnDisable() => input.OnContentsChanged -= MarkDirtyIfChanged;

        private void MarkDirtyIfChanged(Item item, int count) => UnityEditor.EditorUtility.SetDirty(this);
#endif
    }
}
