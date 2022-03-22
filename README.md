<p align="center">
  <img width="64" align="center" src="https://icons.iconarchive.com/icons/papirus-team/papirus-apps/64/viber-icon.png">
</p>
<h1 align="center">
  SRX.ViTool
</h1>
<p align="center">
  Viber tool for PC.
</p>

## Introduction
Simple .NET 5 C# console that organizes the annoying Viber downloads folder where all files are stored in one folder.

## Features
- Sets date prefix to the files names.
- Organizes all files into month folders "MM_yyyy".
- Deletes auto generated folders and leaves the root folder clean.
- If it detects that the file was already organized, it will be moved to "Duplicates" folder.

## Console Arguments

- **-dateprefix** Sets date prefix to the file name (ex: test.jpg will be renamed to 21_01_2022_test.jpg)
- **-viberdir C:\ViberDownloads** It will use this directory.
- **-useCurrentDir** It will use the directory where the .exe is located.
- **-deletePTT** It will delete the auto generated PTT directory if its empty.
- **-deleteTemp** It will delete the auto generated Temporary directory if its empty.

## How to contribute
If you want to contribute to this project, you are welcome!
To do so, you need to follow the following simple steps:
- Fork the project.
- Create a brench with prefix either Feature_ or BugFix_ or whatever the issue it is.
- Do the changes.
- Make a pull request.