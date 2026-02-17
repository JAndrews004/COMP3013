using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomyManager : MonoBehaviour
{
    public int currentBalance;
    public int nightEarnings =0;

    public void AddMoney(int amount)
    {
        Debug.Log($"Money added: {amount}");
        currentBalance += amount;
        nightEarnings += amount;
    }
    public int CalculateDrinkPayout(int basePrice, float accuracy)
    {
        int value = Mathf.RoundToInt(basePrice * accuracy);
        //add upgrade modifiers when made

        

        AddMoney(value);
        return value;
    }
    public void ResetNightEarnings()
    {
        nightEarnings = 0;
    }
    public bool CheckRentSuccess(int rentAmount)
    {
        if(rentAmount <= currentBalance)
        {
            currentBalance -= rentAmount;
            Debug.Log("Rent successful");
            return true;
        }
        else
        {
            Debug.Log("Rent fail");
            return false;
        }
        
    }
}
