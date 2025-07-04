using System.Text;

class FolderTreeWithRootPrefix
{
    static void Main()
    {
        Console.Write("Enter folder path: ");
        string? rootPath = Console.ReadLine();

        if (string.IsNullOrEmpty(rootPath) || !Directory.Exists(rootPath))
        {
            Console.WriteLine("Directory does not exist.");
            return;
        }

        Console.Write("Enter optional separator (e.g., '...') or leave blank for just space: ");
        string? separator = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(separator)) separator = " ";

        Console.Write("Enter folder names to exclude (comma-separated, e.g., bin, obj): ");
        string? excludeInput = Console.ReadLine();
        var excludedFolders = new HashSet<string>(
            (excludeInput ?? "")
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(f => f.Trim()),
            StringComparer.OrdinalIgnoreCase
        );

        StringBuilder sb = new StringBuilder();

        List<string> allNames = new List<string>();
        CollectAllNames(rootPath, allNames, excludedFolders);
        int maxNameLength = 120; // Fixed for now; can be dynamic using allNames.Max(n => n.Length) + margin

        string[] rootDirs = Directory.GetDirectories(rootPath);
        string[] rootFiles = Directory.GetFiles(rootPath);

        foreach (var dir in rootDirs)
        {
            if (excludedFolders.Contains(Path.GetFileName(dir))) continue;

            string name = Path.GetFileName(dir);
            sb.AppendLine($"+-- {AlignName(name, maxNameLength, separator)}Your comments here");
            GenerateTree(dir, sb, "|   ", maxNameLength, separator, excludedFolders);
        }

        foreach (var file in rootFiles)
        {
            string name = Path.GetFileName(file);
            sb.AppendLine($"+-- {AlignName(name, maxNameLength, separator)}Your comments here");
        }

        Console.WriteLine(sb.ToString());
        File.WriteAllText("tree_output.txt", sb.ToString());
    }

    static void GenerateTree(string path, StringBuilder sb, string indent, int maxLength, string separator, HashSet<string> excludedFolders)
    {
        maxLength = maxLength - 4;
        string[] files = Directory.GetFiles(path);
        string[] dirs = Directory.GetDirectories(path)
                                 .Where(d => !excludedFolders.Contains(Path.GetFileName(d)))
                                 .ToArray();

        for (int i = 0; i < files.Length; i++)
        {
            string name = Path.GetFileName(files[i]);
            bool isLast = (i == files.Length - 1) && dirs.Length == 0;

            sb.Append(indent);
            sb.Append(isLast ? "\\-- " : "|-- ");
            sb.AppendLine($"{AlignName(name, maxLength, separator)}Your comments here");
        }

        for (int i = 0; i < dirs.Length; i++)
        {
            string name = Path.GetFileName(dirs[i]);
            bool isLast = i == dirs.Length - 1;

            sb.Append(indent);
            sb.Append(isLast ? "\\-- " : "|-- ");
            sb.AppendLine($"{AlignName(name, maxLength, separator)}Your comments here");

            GenerateTree(dirs[i], sb, indent + (isLast ? "    " : "|   "), maxLength, separator, excludedFolders);
        }
    }

    static string AlignName(string name, int maxLength, string separator)
    {
        return name.PadRight(maxLength) + separator + " ";
    }

    static void CollectAllNames(string root, List<string> allNames, HashSet<string> excludedFolders)
    {
        foreach (var dir in Directory.GetDirectories(root))
        {
            if (excludedFolders.Contains(Path.GetFileName(dir))) continue;

            allNames.Add(Path.GetFileName(dir));
            CollectAllNames(dir, allNames, excludedFolders);
        }

        foreach (var file in Directory.GetFiles(root))
        {
            allNames.Add(Path.GetFileName(file));
        }
    }
}
