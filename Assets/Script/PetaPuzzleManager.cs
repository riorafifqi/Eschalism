using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetaPuzzleManager : MonoBehaviour
{
    public static string petaPass = "";
    public string Password;
    private bool isFixed = false;
    private bool allIsPresed;
    public GameObject[] tombolPeta;
    public Item item1;
    public Item item2;
    public DescriptionItem paper;
    private void Awake()
    {
        System.Text.StringBuilder pw = new System.Text.StringBuilder();

        petaPass = "";
        Password = RandomWord();
        tombolPeta = GameObject.FindGameObjectsWithTag("tombolPeta");

        for (int i = 0; i < Password.Length; i++)
        {
            if (i % 2 == 0 && i > 0)
            {
                pw.Append(", ");
            }
            pw.Append(Password[i]);
        } 
        paper.description = pw.ToString();
    }

    private void Update()
    {
        allIsPresed = true;
        for (int i = 0; i < tombolPeta.Length; i++)
        {
            if (!tombolPeta[i].GetComponent<ButtonPeta>().isPressed)
            {
                allIsPresed = false;
                break;
            }
        }
        if(allIsPresed && petaPass == Password)
        {
            if(!isFixed)
            {
                Debug.Log("a");
                Inventory.instance.Add(item1);
                Inventory.instance.Add(item2);
            }
            isFixed = true;
        }
    }
    public string RandomWord()
    {
        System.Random rnd = new System.Random();
        string[] words = { "NA", "AN", "SA", "AF", "EU"};
        string result = "";

        for (int i = 0; i < words.Length; i++)
        {
            int j = rnd.Next(i, words.Length);
            string temp = words[i];
            words[i] = words[j];
            words[j] = temp;
            result += words[i];
        }

        return result;
    }
}
