using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour {
    const string LEVEL_INDEX_SAVE_KEY="Level Index";

    public static int GetLastLvlSavedIndex()
    {
        return PlayerPrefs.GetInt(LEVEL_INDEX_SAVE_KEY);
    }
	
    public static void SaveCurrentLvlIndex(int currentSceneIndex)
    {
        PlayerPrefs.SetInt(LEVEL_INDEX_SAVE_KEY, currentSceneIndex);
    }

    public static void ResetSave()
    {
        PlayerPrefs.SetInt(LEVEL_INDEX_SAVE_KEY, 1);
    }
}
