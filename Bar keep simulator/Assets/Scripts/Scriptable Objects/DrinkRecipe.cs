using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(menuName = "Drink/Recipe")]
public class DrinkRecipe : ScriptableObject
{
    public string drinkName;
    public string description;
    public int basePrice;
    public int difficultyRating;//for information in recipe book

    public List<DrinkStep> steps;
    public Sprite icon;
}
