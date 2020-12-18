using System;
using Xunit;

namespace Application1.Tests
{
    public class ExtensionTest
    {

    [Fact]
    public void TestingExtension()
    {
        var actual="";
        var expected=".csv";

        string createText = "No,Date,Timestamp,Level,Message" + Environment.NewLine;
        actual = Writer.pathGetter(createText); 
        Assert.Equal(actual,expected);


    }
}
}
