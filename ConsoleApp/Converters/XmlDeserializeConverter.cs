using MoraviaIT.ConsoleApp.DTOs;
using MoraviaIT.ConsoleApp.Interfaces;

using System.Xml.Linq;

namespace MoraviaIT.ConsoleApp.Converters;

internal class XmlDeserializeConverter : IDeserializeConverter<Document>
{
    private const string TITLE_ELEMENT = "title";

    private const string TEXT_ELEMENT = "text";
    
    public Document Deserialize(string message)
    {
        var xdoc = XDocument.Parse(message);
        if (xdoc is null) throw new ArgumentNullException(nameof(xdoc));

        return new Document
        {
            Title = xdoc.Root?.Element(TITLE_ELEMENT)?.Value,
            Text = xdoc.Root?.Element(TEXT_ELEMENT)?.Value
        };
    }
}
