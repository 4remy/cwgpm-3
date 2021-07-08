using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Schwer.ItemSystem {
    public class RecipeDatabase : ScriptableObject {
        // Generated via RecipeDatabaseUtility
        [field:SerializeField] private List<Recipe> recipes;
        public void Initialise(List<Recipe> recipes) {
            this.recipes = recipes;
        }

        public ReadOnlyCollection<Recipe> GetRecipes() => recipes.AsReadOnly();
    }
}
