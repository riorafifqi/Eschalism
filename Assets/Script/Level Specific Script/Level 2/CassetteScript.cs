using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Cassette")]
public class CassetteScript : ScriptableObject
{
    public AudioClip morseClip;
    public string morseCode;
}
