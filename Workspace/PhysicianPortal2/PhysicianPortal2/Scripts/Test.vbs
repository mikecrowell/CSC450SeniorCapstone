'****************************************
'**
'** Rename "About ReModule" to "About CRE"
'** Mike Crowell
'** 7/23/2013
'**
'****************************************
 
'Declare variables.
 Dim objFSO
 Dim strInputPath
 Dim strInputSearchText
 Dim strInputNewText
 Dim strPath
 Dim numReplaced
 
Const ForReading = 1
Const ForWriting = 2

 numReplaced = 0
 
Set objFSO = CreateObject("Scripting.FileSystemObject")
 
 
'== Set root directory here ============
sDirectoryPath = "C:\inetpub\"   'Root Directory for search.
'=======================================




MsgBox "Search complete. " & numReplaced & " Files have been modified."



 
