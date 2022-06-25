using UnityEngine;

[System.Serializable]
public class Dialogue
{
    //public string name;
    [TextArea(3, 10)]
    public string sentence;
    public Sprite characterImage;
    public GameObject DialoguePrefab;
    public string name;
}
