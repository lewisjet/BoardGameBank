using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BoardGameBank.Serialisation;
using System.IO;
using UnityEngine.SceneManagement;

public class LoadSaveFile : MonoBehaviour
{
    [SerializeField] BGBUnityCore unityCore;
    private void Awake()
    {
        if (File.Exists(Application.persistentDataPath + BGBUnityCore.PATHEXTENTION))
        {
            unityCore.players = BGB_SimpleSerialiser.UnpackSaveFile
                    (BGB_SimpleSerialiser.Load(Application.persistentDataPath + BGBUnityCore.PATHEXTENTION));
        }
        else
        {
            unityCore.players = new List<BoardGameBank.Data.BGB_Player>();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
