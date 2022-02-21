using System;
using System.Threading.Tasks;

using Moq;

using MoraviaIT.ConsoleApp.DTOs;
using MoraviaIT.ConsoleApp.Interfaces;
using MoraviaIT.ConsoleApp.Interfaces.Services;
using MoraviaIT.ConsoleApp.IO;

using Xunit;

namespace ConsoleApp.Tests;

public class FileReaderTests
{
    private readonly Mock<IFiles> _files;

    private readonly IReader<Document> _reader;

    public FileReaderTests()
    {
        _files = new Mock<IFiles>();
        _reader = new FileReader(_files.Object, string.Empty);
    }

    [Fact]
    public async Task ReadAsync_CorrectSetup_Success()
    {
        var converter = new Mock<IDeserializeConverter<Document>>();
        converter.Setup(a => a.Deserialize(It.IsAny<string>())).Returns(new Document());
        _files.Setup(a => a.ReadAsync(It.IsAny<string>())).Returns(Task.FromResult(string.Empty));

        var result = await _reader.ReadAsync(converter.Object);
        
        AssertReadAsync_CorrectSetup(result, converter);
    }

    [Fact]
    public Task ReadAsync_NullFileContent_ThrowsExceptionAsync()
    {
        var converter = new Mock<IDeserializeConverter<Document>>();
        _files.Setup(a => a.ReadAsync(It.IsAny<string>())).Returns(Task.FromResult<string>(null));

        return Assert.ThrowsAsync<ArgumentNullException>(() => _reader.ReadAsync(converter.Object));
    }
    
    private static void AssertReadAsync_CorrectSetup(Document result, Mock<IDeserializeConverter<Document>> converter)
    {
        Assert.NotNull(result);
        converter.Verify(a => a.Deserialize(It.IsAny<string>()));
    }
}