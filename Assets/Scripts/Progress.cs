using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour
{
    //public int Coins;
    //public int Level;
    //public Color BackgroundColor;
    //public bool IsMusicOn;

    public static Progress Instance;
    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
        Load();
    }
    public void SetLevel(int level) {
        //Level = level;
        Save();
    }
    public void AddCoins(int value) {
        //Coins += value;
        Save();
    }
    [ContextMenu("DeliteFile")]
    public void DeliteFile() {
        SaveSystem.DeliteFile();
    }
    [ContextMenu("Save")]
    public void Save() {
        SaveSystem.Save(this);
    }
    [ContextMenu("Load")]
    public void Load() {
      ProgressData progressData = SaveSystem.Load();
        if (progressData != null) {
           // Level = progressData.Level;
           // Coins = progressData.Coins;
           // IsMusicOn = progressData.IsMusicOn;
            Color color = new Color();
            color.r = progressData.BackgroundColor[0];
            color.g = progressData.BackgroundColor[1];
            color.b = progressData.BackgroundColor[2];
            color.a = progressData.BackgroundColor[3];
            //BackgroundColor = color;
        }
        else {
           // Coins = 0;
           // Level = 1;
           // BackgroundColor = Color.blue * 0.5f;
           // IsMusicOn = true;
        }
        
    }
}
