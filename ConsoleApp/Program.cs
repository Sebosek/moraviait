using MoraviaIT.ConsoleApp.Converters;
using MoraviaIT.ConsoleApp.Exceptions;
using MoraviaIT.ConsoleApp.IO;
using MoraviaIT.ConsoleApp.Services;

var files = new Files();
var deserialize = new XmlDeserializeConverter();
var serializer = new JsonSerializeConverter();
var reader = new FileReader(files, Path.Combine(Environment.CurrentDirectory, "./Document.xml"));
var writer = new FileWriter(files, Path.Combine(Environment.CurrentDirectory, "./Document.json"));

try
{
    var document = await reader.ReadAsync(deserialize);
    await writer.WriteAsync(document, serializer);
}
catch (MoraviaException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine("Unable to convert files");
    Console.WriteLine(ex.Message);
}
