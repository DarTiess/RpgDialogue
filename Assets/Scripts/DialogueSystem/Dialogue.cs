using UnityEngine;
using System.Xml.Serialization;
using System.IO;
 
[XmlRoot("dialogue")]
public class Dialog 
{
    [XmlElement("node")]
    public DialogueNode[] nodes;
 
    public static Dialog Load(TextAsset _xml)
    {
        XmlSerializer serializer = new XmlSerializer (typeof(Dialog));
        StringReader reader = new StringReader (_xml.text);
        Dialog dial = serializer.Deserialize (reader) as Dialog;
        return dial;
    }
}