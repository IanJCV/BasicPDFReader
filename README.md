# BasicPDFReader

I was tired of other PDF readers being clunky and way too big for just displaying a book. 

Installation:
- Download the latest zip from [Releases](https://github.com/AutismSpirit/BasicPDFReader/releases)
- Unpack into a folder
- Launch PDFReader.exe


**Right click and drag on the directories to move.**

**Middle click and drag on the directories to resize.**

**Right click on the directory tree for options.**

---

## Hotkeys 

- F5 to refresh the current directory
- O to open
- T for Always on Top



***Put any suggestions in issues.***


## KNOWN ISSUES / TROUBLESHOOTING
- Dragging and resizing doesn't work on the PDF view, currently you can manipulate the window only using the directory view.
- Resizing is clunky.
- If you get an error while loading the directory, or any permission issues, reset the directory path or delete the file in "%appdata%/JCVPDF Reader", or run this command:

` del "%appdata%\JCVPDF Reader\folders.txt" `


## TODO
- [ ] CLEAN THE CODE!
- [ ] Figure out an installer and discarding/packing all the unnecessary DLLs. *If you know how to do this, please put it in suggestions!*
- [ ] Tabs
- [ ] Better memory management
- [ ] More file directories, maybe directory bookmarks
- [ ] Better menus


## MAYBE
- Rewrite the thing in C++
