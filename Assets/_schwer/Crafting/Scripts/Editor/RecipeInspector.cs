using UnityEditor;
using UnityEngine;

namespace SchwerEditor.ItemSystem {
    using Schwer.ItemSystem;
    
    //! Copied from `InventoryInspector` — could probably be polished up
    [CustomEditor(typeof(Recipe))]
    public class RecipeInspector : Editor {
        private static Item item;
        private static int amount = 1;

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();
            GUILayout.Space(5);
            
            var recipe = (Recipe)target;
            DrawControls(recipe);
        }

        private void DrawControls(Recipe recipe) {
            EditorGUILayout.LabelField("Editor", EditorStyles.boldLabel);

            if (GUILayout.Button("Clear Recipe")) {
                recipe.input.Clear();
                Debug.Log("Cleared '" + recipe.name + "'.");
            }

            DrawItemControls(recipe);
        }

        private void DrawItemControls(Recipe recipe) {
            EditorGUILayout.BeginVertical("box");

            item = (Item)EditorGUILayout.ObjectField("Item", item, typeof(Item), false);
            amount = EditorGUILayout.IntField("Amount", amount);

            var invName = "'" + recipe.name + "'";
            var itemName = "'" + ((item != null) ? item.name : "(Item)") + "'";

            EditorGUI.BeginDisabledGroup(item == null);
            if (GUILayout.Button("Set " + itemName + " to " + amount + "x")) {
                recipe.input[item] = amount;
                Debug.Log("Set " + invName + " " + itemName + " to " + amount + "x.");
            }
            if (GUILayout.Button("Remove all of " + itemName)) {
                if (recipe.input.Remove(item)) {
                    Debug.Log("Removed all of " + itemName + " from " + invName + ".");
                }
                else {
                    Debug.Log(invName + " does not have any of " + itemName + " to remove.");
                }
            }
            EditorGUI.EndDisabledGroup();

            EditorGUILayout.EndVertical();
        }
    }
}
