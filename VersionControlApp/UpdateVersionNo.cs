using Newtonsoft.Json;
using VersionControlApp.Model;

namespace VersionControlApp
{
    public class UpdateVersionNo
    {
        public void UpdateVersionNumber(string versionType, string filePath)
        {
            ProjectDetails projectDetailsObj = GetProjectDetails(filePath);
            string versionNo = projectDetailsObj.Version;
            projectDetailsObj.Version = IncrementVersionNo(versionType, versionNo);
            SaveUpdatedProjectDetails(projectDetailsObj, filePath);
        }
        private ProjectDetails GetProjectDetails(string filePath)
        {
            string fileText = File.ReadAllText(filePath);
            ProjectDetails? jsonObj = JsonConvert.DeserializeObject<ProjectDetails>(fileText);
            if (jsonObj == null)
            {
                string fileName = Path.GetFileName(filePath);
                throw new Exception($"Unable to read {fileName} file.");
            }
            return jsonObj;
        }

        public string IncrementVersionNo(string versionType, string versionNo)
        {
            string[] versionParts = versionNo.Split('.');
            int major = Convert.ToInt32(versionParts[0]);
            int minor = Convert.ToInt32(versionParts[1]);
            int patch = Convert.ToInt32(versionParts[2]);

            if (versionType.ToLower() == "minor")
            {
                minor++;
                patch = 0;
            }
            else if (versionType.ToLower() == "patch")
            {
                patch++;
            }
            versionNo = $"{major}.{minor}.{patch}";
            return versionNo;
        }

        private void SaveUpdatedProjectDetails(ProjectDetails projectDetailsObj, string filePath)
        {
            string output = JsonConvert.SerializeObject(projectDetailsObj, Formatting.Indented);
            File.WriteAllText(filePath, output);
        }
    }
}
