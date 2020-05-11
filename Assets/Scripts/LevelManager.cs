using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public enum GameState {GameExplination, InGame, TimeOver, Results }//I get an error if this is not public because of GetGameState
    GameState currGameState;

    void Start()
    {
        currGameState = GameState.GameExplination;
    }

    void Update()
    {
        
    }

    public GameState GetGameState()
    {
        return currGameState;
    }

    public void SetStateToGameExplination(){ currGameState = GameState.GameExplination; }

    public void SetStateToInGame() { currGameState = GameState.InGame; }

    public void SetStateToTimeOver(){ currGameState = GameState.TimeOver; }

    public void SetStateToResults(){ currGameState = GameState.Results; }
}
