using System;
using Xunit;

namespace Application1.Tests
{
    public class ValidateTest
    {
        
        [Fact]
        public void TestingPath()
        {
            //arrange
            Validator v= new Validator();
            string dir_path=@"C:\Users\shriyab\Downloads\2020_02\2020_02";
            //act and assert
            Assert.Equal(true, new Validator().validate(dir_path));

        }
    }
}
