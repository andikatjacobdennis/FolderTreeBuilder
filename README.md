# FolderTreeBuilder

A simple C# console application that generates a visual folder and file structure from a given directory. It supports optional inline comments for each file or folder—perfect for documenting project structures.

## Features

- Tree-style folder visualization (`+--`, `├──`, `└──`)
- Add descriptive comments to any file or folder
- Output to console or save to file
- Easy to integrate into build or documentation pipelines

## Usage

1. Clone the repo:

```bash
git clone https://github.com/yourusername/DirectoryTreeGenerator.git
cd DirectoryTreeGenerator
```

2. Build and run:

```bash
dotnet run
```

3. Enter a folder path when prompted. Example:

```plaintext
Enter folder path: C:\Projects\MyApp
```

## Sample Output

```
+-- llm.py                  # Your comments here
+-- requirements.txt        # Your comments here
+-- tests                   # Your comments here
│   └── test_debugger.py
+-- wrapper.js              # JavaScript wrapper for invoking Python scripts
```

## License

MIT.

## Contributions

Pull requests welcome! Feel free to open issues or suggest features.
