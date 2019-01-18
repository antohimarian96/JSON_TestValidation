using System;
using Xunit;

namespace JSON_TextValidation.Test
{
    public class TestProgram
    {
        [Fact]
        public void ValidationText_WhenTheStartAndTheEndAreQuotationMarks()
        {
            Assert.True(Program.ValidationText("\"Ana are mere\""));
        }

        [Fact]
        public void ValidationText_WhenTheStartAndTheEndAreQuotationMarksAndTextContainOneSpecificValidTextInTheEnd()
        {
            Assert.True(Program.ValidationText("\"Ana are mere\\u0097\nAnother line\""));
        }

        [Fact]
        public void ValidationText_WhenTheStartIsQuotationMarkButTheEndDont()
        {
            Assert.False(Program.ValidationText("\"Ana are mere"));
        }

        [Fact]
        public void ValidationText_WhenTheEndIsQuotationMarkButTheStartDont()
        {
            Assert.False(Program.ValidationText("Ana are mere\""));
        }

        [Fact]
        public void ValidationText_WhenSecondCharacterIsSlash()
        {
            Assert.False(Program.ValidationText("\"\\Ana are mere\""));
        }

        [Fact]
        public void ValidationText_WhenHalfCharacterIsQuotationMark()
        {
            Assert.False(Program.ValidationText("\"Ana\"Ana\""));
        }
    }

}
