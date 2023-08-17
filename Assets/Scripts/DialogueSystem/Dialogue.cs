using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace DialogueSystem
{
    [XmlRoot("dialogue")]
    public class Dialog 
    {
        [XmlElement("node")]
        public DialogueNode[] Nodes;
 
        public static Dialog Load(TextAsset xml)
        {
            XmlSerializer serializer = new XmlSerializer (typeof(Dialog));
            StringReader reader = new StringReader (xml.text);
            Dialog dial = serializer.Deserialize (reader) as Dialog;
            return dial;
        }
    }
}