# Folder Tree Builder

A simple C# console application that generates a visual folder and file structure from a given directory. It supports optional inline comments for each file or folder—perfect for documenting project structures.

## Features

- Tree-style folder visualization using ASCII (`+--`, `|--`, `\--`)
- Add descriptive comments to any file or folder
- Output to console or save to file
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

3. Enter a folder path when prompted. Example:

```
Enter folder path: C:\Projects\MyApp
```

4. (Optional) Enter a separator string (e.g., `...`) to visually align comments.

## Sample Output

```
+-- llm.py                  ... Your comments here
+-- requirements.txt        ... Your comments here
+-- tests                   ... Your comments here
|   |-- unit_tests.cs       ... Your comments here
|   \-- integration.cs      ... Your comments here
+-- wrapper.js              ... Your comments here
```

## License

MIT

## Contributions

Pull requests welcome! Feel free to open issues or suggest features.
