namespace VersionControlApp.Tests
{
    public class UpdateVersionNoTests
    {
        [Fact]
        public void UpdateVersionNo_CorrectFile_Success()
        {
            string versionType = "minor";
            string filePath = "../../../ProjectDetails.json";
            UpdateVersionNo updateVersionMethod = new UpdateVersionNo();
            
            var exception = Record.Exception(() => updateVersionMethod.UpdateVersionNumber(versionType, filePath));

            Assert.Null(exception);
        }

        [Fact]
        public void UpdateVersionNo_NoFileFound_Fail()
        {
            string versionType = "minor";
            string fileName = "FailTest.json";
            string filePath = $"../../../{fileName}";

            UpdateVersionNo updateVersionMethod = new UpdateVersionNo();

            var exception = Assert.Throws<FileNotFoundException>(() => updateVersionMethod.UpdateVersionNumber(versionType, filePath));

            Assert.Contains("Could not find file", exception.Message);
            Assert.Contains(fileName, exception.FileName);
        }

        [Fact]
        public void UpdateVersionNo_EmptyFile_Fail()
        {
            string versionType = "minor";
            string fileName = "EmptyFile.json";
            string filePath = $"../../../{fileName}";
            UpdateVersionNo updateVersionMethod = new UpdateVersionNo();

            var exception = Assert.Throws<Exception>(() => updateVersionMethod.UpdateVersionNumber(versionType, filePath));

            Assert.Equal($"Unable to read {fileName} file.", exception.Message);
        }

        [Fact]
        public void IncrementVersionNo_Minor_Success()
        {
            string versionType = "minor";
            string versionNo = "1.2.3";
            UpdateVersionNo updateVersionMethod = new UpdateVersionNo();

            var result = updateVersionMethod.IncrementVersionNo(versionType, versionNo);

            Assert.Equal("1.3.0", result);
        }

        [Fact]
        public void IncrementVersionNo_UppercaseMinor_Success()
        {
            string versionType = "MINOR";
            string versionNo = "1.2.3";
            UpdateVersionNo updateVersionMethod = new UpdateVersionNo();

            var result = updateVersionMethod.IncrementVersionNo(versionType, versionNo);

            Assert.Equal("1.3.0", result);
        }

        [Fact]
        public void IncrementVersionNo_Patch_Success()
        {
            string versionType = "patch";
            string versionNo = "1.2.3";
            UpdateVersionNo updateVersionMethod = new UpdateVersionNo();

            var result = updateVersionMethod.IncrementVersionNo(versionType, versionNo);

            Assert.Equal("1.2.4", result);
        }

        [Fact]
        public void IncrementVersionNo_UppercasePatch_Success()
        {
            string versionType = "PATCH";
            string versionNo = "1.2.3";
            UpdateVersionNo updateVersionMethod = new UpdateVersionNo();

            var result = updateVersionMethod.IncrementVersionNo(versionType, versionNo);

            Assert.Equal("1.2.4", result);
        }

        [Fact]
        public void IncrementVersionNo_WrongInput_Success()
        {
            string versionType = "random";
            string versionNo = "1.2.3";
            UpdateVersionNo updateVersionMethod = new UpdateVersionNo();

            var result = updateVersionMethod.IncrementVersionNo(versionType, versionNo);

            Assert.Equal("1.2.3", result);
        }

        [Fact]
        public void IncrementVersionNo_EmptyInput_Success()
        {
            string versionType = "";
            string versionNo = "1.2.3";
            UpdateVersionNo updateVersionMethod = new UpdateVersionNo();

            var result = updateVersionMethod.IncrementVersionNo(versionType, versionNo);

            Assert.Equal("1.2.3", result);
        }

    }
}
