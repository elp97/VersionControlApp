using VersionControlApp;

string versionType = args.Length > 0 ? args[0] : "";
string filePath = "../../../ProjectDetails.json";
UpdateVersionNo updateVersionMethod = new UpdateVersionNo();
updateVersionMethod.UpdateVersionNumber(versionType, filePath);