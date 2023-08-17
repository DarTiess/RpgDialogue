using System.Xml.Serialization;

[System.Serializable]
public class DialogueNode
{
    [XmlElement("npctext")]
    public string NpcText;
 
    [XmlArray("answers")]
    [XmlArrayItem("answer")]
    public Answer[] answers;
}