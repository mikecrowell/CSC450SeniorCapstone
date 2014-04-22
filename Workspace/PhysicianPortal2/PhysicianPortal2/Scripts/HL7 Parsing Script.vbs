Dim GetChar
Dim FieldCount
Dim SegTerm
Dim MsgTerm
Dim FieldSep
Dim CompSep
Dim RepSep
Dim EscChar
Dim SubSep
Dim StringValue
Dim GetSegId
Dim GotRecord
Dim MsgID
Dim MsgDate
Dim MsgType
Dim MsgEvent
Dim PtID
Dim ClientID
Dim Accession
Dim AccessNum
Dim MsgTime
Dim GetDay
Dim GetMonth
Dim GetYear
Dim TempArray
Dim FacID
Dim PtGender
Dim PtDOB
Dim PtLastName
Dim PtFirstName
Dim SurvMRN
Dim IncMRN






MsgTerm = Chr(28)  ' File Separator
SegTerm = Chr(13)  ' carriage return
FieldSep = "|"
CompSep = "^"
RepSep = "~"
EscChar = "\"
SubSep = "&"


FieldCount = 0
GotRecord = False
GetSegId = True

MsgDate = ""
MsgEvent = ""
MsgTime = ""
FacID = ""
PtGender = ""
PtDOB = ""
PtLastName = ""
PtFirstName = ""
SurvMRN = ""
IncMRN = ""
GetDay = ""
GetMonth = ""
GetYear = ""
TempArray = ""
GetHour = ""
GetMin = ""


'''''''
'* Edit output (temp file) path here *****  Need to also edit below *
Set oOutputFSO = CreateObject("Scripting.FileSystemObject")   'Object used for output file.
sOutputFilePath = "C:\Projects\TD Clients to AMG\Report Files\ClientList_InProgress.temp"   'Directory and file name for log file.

''''''
'* Edit input path here *****
Set oReadFSO = CreateObject("Scripting.FileSystemObject")   'Object used for input files.
sGetFilePath = "C:\Projects\TD Clients to AMG\Data Files\" 



If oOutputFSO.FileExists(sOutputFilePath) Then   'Check if log file already exists
	Set oOutputFile = oOutputFSO.OpenTextFile(sOutputFilePath, 8)   'If log file exists then open it.
Else
	Set oOutputFile = oOutputFSO.CreateTextFile(sOutputFilePath) 
	' Write file headers
	oOutputFile.Write("DATE" & vbTab & "TIME" & vbTab & "CLIENT ID" & vbCr & vbLf)
End If



Set oFolder = oReadFSO.GetFolder(sGetFilePath)
Set oFileCollection = oFolder.Files
For Each oFile in oFileCollection
	Set oInputFile = oReadFSO.OpenTextFile(oFile, 1)	
	
	Do Until oInputFile.AtEndOfStream
	
		GetChar = oInputFile.Read(1)
		

		If (GetChar = SegTerm) Or (GetChar = FieldSep) Or (GetChar = MsgTerm) Then
     
			If GetChar = FieldSep Then
				FieldCount = FieldCount + 1
			End If
			
			If GetSegId Then
				SegId = StringValue
'				GotRecord = True
				GetSegId = False
				FieldCount = 0
			End If
						
			If GetChar = SegTerm Then
				GetSegId = True
				FieldCount = FieldCount + 1
			End If
			
			'If GetChar = MsgTerm Then
			If segId = "MSH" Then
				If GotRecord Then
					Write_To_File
					MsgEvent = ""
 					MsgDate = ""
					FacID = ""
					PtDOB = ""
					PtGender = ""
					PtLastName = ""
					PtFirstName = ""
					SurvMRN = ""
					IncMRN = ""
					GetDay = ""
					GetMonth = ""
					GetYear = ""
					TempArray = ""
					ptID = ""
					Accession = ""
					GotRecord = False
				End If
			End If
			
			Select Case SegId
				Case "MSH"
					GotRecord = False
					MSH_Segment
				Case "PID"
					PID_Segment
				Case "PV1"
					PV1_Segment
				Case "OBR"
					OBR_Segment
				Case "MRG"
					MRG_Segment					
			End Select
			
			StringValue = ""
			
		ElseIf GetChar <> Chr(11) Then
			StringValue = StringValue & GetChar
		End If
	
	
	Loop
        	
        If GotRecord Then Write_To_File
        oInputFile.Close		
Next	


oOutputFile.Close
' **** Edit here to reflect path and file name of temp file and new report file ******
oOutputFSO.MoveFile "C:\Projects\TD Clients to AMG\Report Files\ClientList_InProgress.temp" , "C:\Projects\TD Clients to AMG\Report Files\ClientList.txt"


'Destroy Objects to prevent memory leaks
Set oOutputFSO = Nothing
Set oReadFSO = Nothing
Set oFolder = Nothing
Set oFileCollection = Nothing
Set oInputFile = Nothing
Set oOutputFile = Nothing



'----- Subroutines ---------------


' HL7 Segments

' -- MSH --
Sub MSH_Segment()

	Select Case FieldCount
		Case 1
			GotRecord = True
		Case 6
			GetYear = Left(StringValue, 4)
			GetMonth = Mid(StringValue, 5, 2)
			GetDay = Mid(StringValue, 7, 2)
			GetHour = Mid(StringValue, 9, 2)
			GetMin = Mid(StringValue, 11, 2)
			MsgDate = GetMonth & "/" & GetDay & "/" & GetYear
			MsgTime = GetHour & ":" & GetMin

		Case 8
			TempArray = ""
			TempArray = Split(StringValue, "^")		
			MsgEvent = TempArray(1)			
		Case 9
			
	End Select

End Sub

' -- PID -- 
Sub PID_Segment()

	Select Case FieldCount
		Case 3
			ptID = StringValue
		Case 5
			TempArray = ""
			TempArray = Split(StringValue, "^")		
			PtLastName = TempArray(0)
			PtFirstName = TempArray(1)			
		Case 7
			GetYear = ""
			GetMonth = ""
			GetDay = ""		
			GetYear = Left(StringValue, 4)
			GetMonth = Mid(StringValue, 5, 2)
			GetDay = Mid(StringValue, 7, 2)
			PtDOB = GetMonth & "/" & GetDay & "/" & GetYear								
		Case 8
			PtGender = StringValue			
	End Select

End Sub

' -- PV1 --
Sub PV1_Segment()

	Select Case FieldCount
		Case 3
			TempArray = ""
			TempArray = Split(StringValue, "^")		
			ClientID = TempArray(3)	

	End Select
	
End Sub

' -- OBR --
Sub OBR_Segment()

	Select Case FieldCount
		Case 20
			Accession = StringValue
	End Select
	
End Sub

' -- MRG --
Sub MRG_Segment()

	Select Case FieldCount
		Case 1
			TempArray = ""
			TempArray = Split(StringValue, "^")		
			IncMRN = TempArray(0)
	End Select
	
End Sub


' Write data from HL7 transaction as a record in the output file.
Sub Write_To_File()

	oOutputFile.Write(MsgDate & vbTab & MsgTime & vbTab & ClientID & vbCr & vbLf)

End Sub


