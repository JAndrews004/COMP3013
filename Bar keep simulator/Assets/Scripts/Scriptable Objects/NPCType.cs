using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "NPCType")]
public class NPCType : ScriptableObject
{
    public string npcName;
    public float patienceTime;
    public float tipModifier;
    public PersonalityTag personalityTag;

}

public enum PersonalityTag
{
    None,
    Polite,
    Rude,
    Impatient,
    //etc
}