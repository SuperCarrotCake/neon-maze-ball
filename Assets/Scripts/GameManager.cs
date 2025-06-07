using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager I { get; private set; }
    public GameData Data { get; private set; }
    SaveManager _saver;

    void Awake()
    {
        if (I != null) { Destroy(gameObject); return; }
        I = this; DontDestroyOnLoad(gameObject);
        _saver = new SaveManager();
        Data = _saver.Load();
    }

    public void UnlockLevel(int lvl)
    {
        if (!Data.unlockedLevels.Contains(lvl))
        {
            Data.unlockedLevels.Add(lvl);
            _saver.Save(Data);
        }
    }

    public bool IsLevelUnlocked(int lvl)
    {
        return Data.unlockedLevels.Contains(lvl);
    }

    public void StartLevel(int lvl)
    {
        if (IsLevelUnlocked(lvl))
        {
            SceneManager.LoadScene($"Level{lvl}");
            Data.lastLevelPlayed = lvl;
            _saver.Save(Data);
        }
    }

    public void PlayLastOrFirst()
    {
        int nivelAIniciar = (Data.lastLevelPlayed > 0)
                            ? Data.lastLevelPlayed
                            : 1;
        StartLevel(nivelAIniciar);
    }
    
    public void ResetGameData()
    {
        Data = new GameData();
        _saver.Save(Data);
    }
}

