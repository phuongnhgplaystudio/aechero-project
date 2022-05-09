using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameObjects : MonoBehaviour
{
    private static GlobalGameObjects _i;
    public static GlobalGameObjects Instance
    {
        get
        {
            if (_i == null)
                _i = GameObject.FindObjectOfType<GlobalGameObjects>();
            return _i;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    #region

    [SerializeField] private GameObject player;
    public GameObject Player { get => player; set => player = value; }

    #endregion
}
