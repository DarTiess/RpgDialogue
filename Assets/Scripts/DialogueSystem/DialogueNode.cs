using System.Xml.Serialization;

namespace DialogueSystem
{
    [System.Serializable]
    public class DialogueNode
    {
        [XmlElement("npctext")]
        public string NpcText;
    
        [XmlArray("answers")]
        [XmlArrayItem("answer")]
        public Answer[] Answers;
    }
}