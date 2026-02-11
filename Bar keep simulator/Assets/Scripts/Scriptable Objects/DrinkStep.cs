using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Drink/Step")]
public class DrinkStep : ScriptableObject
{
    public StepType stepType;
    public DrinkIngredient drinkIngredient;
    public GarnishType garnishType;
    public float requiredMetricMin;
    public float requiredMetricMax; //for min and max time for shaking, stiring etc
    public int orderIndex;
}

public enum StepType
{
    AddIngredient,
    AddIce,
    AddGarnish,
    Shake,
    Stir,

}