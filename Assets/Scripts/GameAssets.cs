using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;
    public static GameAssets Instance
    {
        get
        {
            if (_i == null) _i = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
            return _i;
        }
    }
    
    

    #region "Game Resources"
    //Effect Prefabs
    [Header("Effects")]
    public Transform pfDamagePopup;
    public GameObject circlePrefab;
    public GameObject pfCoin;

    #endregion
}

