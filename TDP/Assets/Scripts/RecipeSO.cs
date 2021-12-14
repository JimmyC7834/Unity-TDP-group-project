using System;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Recipe")]
public class RecipeSO : DescriptionBaseSO
{
    [Serializable]
    public struct Ingredient
    {
        public ResourceObject.Type resourceType;
        public int amount;
    }

    public Ingredient[] ingredients = default;

    public bool Craftable(int[] resourceCount)
    {
        for (int i = 0; i < ingredients.Length; i++)
        {
            // check the amount of needed ingredients
            if (resourceCount[(int) ingredients[i].resourceType] < ingredients[i].amount)
            {
                return false;
            }
        }

        return true;
    }

    public void ConsumeIngredients(int[] resourceCount)
    {
        for (int i = 0; i < ingredients.Length; i++)
            resourceCount[(int) ingredients[i].resourceType] -= ingredients[i].amount;
    }
}
