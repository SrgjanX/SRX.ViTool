# SRX.ViTool
Viber tool for PC.

## Introduction
Simple .NET 5 C# console that organizes the annoying Viber downloads folder where all files are stored in one folder.

## Features
- Sets date prefix to the files names.
- Organizes all files into month folders "MM_yyyy".

## Console Arguments

- **-dateprefix** Sets date prefix to the file name (ex: test.jpg will be renamed to 21_01_2022_test.jpg)
- **-viberdir C:\ViberDownloads** It will use this directory.
- **-useCurrentDir** It will use the directory where the .exe is located.