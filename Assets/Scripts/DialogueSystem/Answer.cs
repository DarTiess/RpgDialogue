using System.Xml.Serialization;

[System.Serializable]
public class Answer
{
    [XmlAttribute("tonode")]
    public int nextNode;
    [XmlElement("text")]
    public string text;
    [XmlElement("end")]
    public string end;
}