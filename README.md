# Folder Tree Builder

A simple C# console application that generates a visual folder and file structure from a given directory. It supports optional inline comments for each file or folder—perfect for documenting project structures.

## Features

- Tree-style folder visualization using ASCII (+--, |--, \--)
- Add descriptive comments to any file or folder
- Exclude folders like bin, obj, .git via input
- Output to console and also write to a text file (tree_output.txt)
- Easy to integrate into build or documentation pipelines

## Usage

1. Clone the repo:

```bash
git clone https://github.com/yourusername/DirectoryTreeGenerator.git
cd DirectoryTreeGenerator
````

2. Build and run:

```bash
dotnet run
```

3. Follow the prompts:

```
Enter folder path: C:\Projects\MyApp
Enter optional separator (e.g., '...') or leave blank for just space: ...
Enter folder names to exclude (comma-separated, e.g., bin, obj): bin, obj, .git
```

> All folders listed will be skipped during tree generation (case-insensitive).

## Sample Output

```
+-- llm.py                  ... Your comments here
+-- requirements.txt        ... Your comments here
+-- tests                   ... Your comments here
|   |-- unit_tests.cs       ... Your comments here
|   \-- integration.cs      ... Your comments here
+-- wrapper.js              ... Your comments here
```

## Output

* The full tree is also saved to a file called tree_output.txt in the same directory as the executable.

## License

MIT

## Contributions

Pull requests welcome! Feel free to open issues or suggest features.
