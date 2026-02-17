using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }

    private GameState currentState;
    private GameState previousState;
    private int night = 1;
    public NightManager nightManager;
    public OrderManager orderManager;
    public EconomyManager economyManager;
    public UpgradeManager upgradeManager;

    //testing
    [Header("Testing")]
    public DrinkRecipe testRecipe;
    public List<DrinkStep> perfectSteps;
    public List<DrinkStep> mediumSteps;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        InitializeGame();
    }

    public void InitializeGame()
    {
        currentState = GameState.MainMenu;
    }
    public void RequestStateChange(GameState state)
    {

    }

    public void ChangeState(GameState state)
    {
        OnStateExited(currentState);
        previousState = currentState;
        currentState = state;
        Debug.Log($"State changed: {previousState} -> {currentState}");
        OnStateEntered(state);
    }
    public void OnStateEntered(GameState state)
    {
        //load correct scene
    }
    public void OnStateExited(GameState state)
    {
        //clean up data of current scene
    }
    public void StartNight()
    {
        ChangeState(GameState.NightActive);
        nightManager.BeginNight();
    }
    public void EndNight()
    {
        ChangeState(GameState.NightEnd);
        if (!economyManager.CheckRentSuccess(Mathf.RoundToInt(night / 4) * 500)) 
        {
            TriggerFailState();
        }
        orderManager.currentOrders.Clear();
        orderManager.selectedOrder = null;
        

        //show end of night summary and upgrade menu 
        economyManager.nightEarnings = 0;

    }
    public void TriggerFailState()
    {
        ChangeState(GameState.FailState);
    }
    public GameState GetCurrentState()
    {
        return currentState;
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartNight();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EndNight();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            orderManager.GenerateOrder();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            orderManager.selectedOrder = testRecipe;
            orderManager.SubmitDrink(perfectSteps);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            orderManager.selectedOrder = testRecipe;
            orderManager.SubmitDrink(mediumSteps);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            economyManager.AddMoney(99);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            economyManager.CheckRentSuccess(1000);
        }
    }
}

public enum GameState
{
    MainMenu,
    NightStart,
    NightActive,
    NightEnd,
    FailState,
}