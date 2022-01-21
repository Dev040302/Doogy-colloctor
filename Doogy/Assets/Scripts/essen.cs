using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class essen : MonoBehaviour
{
    public static essen Instance;
    public float speed = 20.0f,forward=0.0f,horizondal=0.0f;
    public int type = 1,score=0,HS=0;
    public bool gameactive = false;
    public GameObject hiten=null;


    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    private void Start()
    {
        HS = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]

    class SaveData
    {
        public int HS;
    }

    public void SavaScore()
    {
        SaveData data = new SaveData();
        data.HS = HS;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HS = data.HS;
        }
    }
}
