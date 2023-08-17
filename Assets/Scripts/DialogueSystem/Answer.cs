using System.Xml.Serialization;

namespace DialogueSystem
{
    [System.Serializable]
    public class Answer
    {
        [XmlAttribute("tonode")]
        public int NextNode;
        [XmlElement("text")]
        public string Text;
        [XmlElement("end")]
        public string End;
    }
}