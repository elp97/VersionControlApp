namespace VersionControlApp.Model
{
    public class ProjectDetails
    {
        public string Version { get; set; } = String.Empty;
        public Patch? Patch { get; set; }
    }

    public class Patch
    {
        public string? Name { get; set; }
        public string? Directory { get; set; }
        public string? Ordinal { get; set; }
        public string[]? Scripts { get; set; }
    }
}

