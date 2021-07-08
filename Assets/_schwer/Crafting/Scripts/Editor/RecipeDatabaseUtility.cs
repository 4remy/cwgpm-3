using System.Linq;
using UnityEditor;
using UnityEngine;

namespace SchwerEditor.ItemSystem {
    using Schwer.ItemSystem;

    [CustomEditor(typeof(RecipeDatabase))]
    public class RecipeDatabaseInspector : Editor {
        public override void OnInspectorGUI() {
            if (GUILayout.Button("Regenerate RecipeDatabase")) {
                RecipeDatabaseUtility.GenerateRecipeDatabase();
            }
            GUILayout.Space(5);

            var listProperty = new SerializedObject((RecipeDatabase)target).FindProperty("recipes");
            if (listProperty.propertyType == SerializedPropertyType.Generic) {
                // Use Copy() to avoid unwanted iterating.
                var listCount = listProperty.Copy().arraySize;
                GUILayout.Label("Recipes (" + listCount + ")");

                foreach (SerializedProperty itemProperty in listProperty) {
                    if (itemProperty.propertyType == SerializedPropertyType.ObjectReference) {
                        using (new EditorGUI.DisabledScope(true)) {
                            EditorGUILayout.PropertyField(itemProperty, GUIContent.none);
                        }
                    }
                }
            }
        }
    }

    public static class RecipeDatabaseUtility {
        [MenuItem("Item System/Generate Recipe Database", false, -2), MenuItem("Assets/Create/Item System/Recipe Database", false, -11)]
        public static void GenerateRecipeDatabase() {
            var recipeDB = GetRecipeDatabase();
            if (recipeDB == null) { return; }

            recipeDB.Initialise(AssetsUtility.FindAllAssets<Recipe>().ToList());
            EditorUtility.SetDirty(recipeDB);

            AssetsUtility.SaveRefreshAndFocus();
            Selection.activeObject = recipeDB;
        }

        private static RecipeDatabase GetRecipeDatabase() {
            var databases = AssetsUtility.FindAllAssets<RecipeDatabase>();

            RecipeDatabase recipeDB = null;
            if (databases.Length < 1) {
                Debug.Log("Creating a new RecipeDatabase since none exist.");
                recipeDB = ScriptableObjectUtility.CreateAsset<RecipeDatabase>();
            }
            else if (databases.Length > 1) {
                Debug.LogError("Multiple RecipeDatabases exist. Please delete the extra(s) and try again.");
            }
            else {
                recipeDB = databases[0];
            }

            return recipeDB;
        }
    }
}
