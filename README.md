# Encapsulates the .NET Process class.**

__Problem:__
You need to start an EXE file from within a VBA macro sitting in an Excel spreadsheet.
You have to wait for it to complete.

__In Excel:__
You can use the Shell function. But no asynchronous option to wait for it.
You can use https://docs.microsoft.com/en-us/office/vba/access/concepts/windows-api/determine-when-a-shelled-process-ends.
But the above link does not work on newer Windows versions.

__Solution:__
Try this class library.
There are still issues with Windows versions, processor architectures and Office (Excel) versions.
