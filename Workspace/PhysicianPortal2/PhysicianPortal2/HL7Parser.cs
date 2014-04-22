//namespace PhysicianPortal2
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Web;
//    using UnityEngine;
//    using System.Collections;

//public class HL7Parser
//{

//    private char GetChar;
//    private int FieldCount;
//    private string SegTerm;
//    private string MsgTerm;
//    private string FieldSep;
//    private string CompSep;
//    private string RepSep;
//    private string EscChar;
//    private string SubSep;
//    private string StringValue;
//    private bool GetSegId;
//    private bool GotRecord;
//    private string MsgID;
//    private string MsgDate;
//    private string MsgType;
//    private string MsgEvent;
//    private string PtID;
//    private string ClientID;
//    private string Accession;
//    private string AccessNum;
//    private string MsgTime;
//    private string GetDay;
//    private string GetMonth;
//    private string GetYear;
//    private string TempArray;
//    private string FacID;
//    private string PtGender;
//    private string PtDOB;
//    private string PtLastName;
//    private string PtFirstName;
//    private int SurvMRN;
//    private int IncMRN



//    public HL7Parser()
//    {
//        MsgTerm = Chr(28);  // File Separator;
//        SegTerm = Chr(13);  // carriage return;
//        FieldSep = "|";
//        CompSep = "^";
//        RepSep = "~";
//        EscChar = "\\";
//        SubSep = "+";


//        FieldCount = 0;
//        GotRecord = false;
//        GetSegId = true;

//        MsgDate = "";
//        MsgEvent = "";
//        MsgTime = "";
//        FacID = "";
//        PtGender = "";
//        PtDOB = "";
//        PtLastName = "";
//        PtFirstName = "";

//        GetDay = "";
//        GetMonth = "";
//        GetYear = "";
//        TempArray = "";



//        //''''''
//        //* Edit output (temp file) path here *****  Need to also edit below *
//        ActiveXObject oOutputFSO = new ActiveXObject("Scripting.FileSystemObject");   //Object used for output file.;
//        sOutputFilePath = "C:\Projects\TD Clients to AMG\Report Files\ClientList_InProgress.temp"   //Directory && file name for log file.

//        //'''''
//        //* Edit input path here *****
//        oReadFSO = new ActiveXObject("Scripting.FileSystemObject")   'Object used for input files.;
//        sGetFilePath = "C:\Projects\TD Clients to AMG\Data Files\"   
//    }






//        if(oOutputFSO.FileExists(sOutputFilePath)){   //Check if(log file already exists
//        oOutputFile = oOutputFSO.OpenTextFile(sOutputFilePath, 8)   //if(log file exists){ open it.;
//        }else{
//        oOutputFile = oOutputFSO.CreateTextFile(sOutputFilePath) ;
//         // Write file headers;
//         oOutputFile.Write("DATE" + '\t' + "TIME" + '\t' + "CLIENT ID" + '\r\n');
//}



//oFolder = oReadFSO.GetFolder(sGetFilePath)
//oFileCollection = oFolder.Files;
//For Each oFile in oFileCollection;
//oInputFile = oReadFSO.OpenTextFile(oFile, 1) ;

// Do Until oInputFile.AtEndOfStream;

//  GetChar = oInputFile.Read(1);
  

//  if((GetChar = SegTerm) || (GetChar = FieldSep) || (GetChar = MsgTerm)){

//   if(GetChar == FieldSep){
//    FieldCount = FieldCount + 1;
//   }

//   if(GetSegId){
//    SegId = StringValue;
////    GotRecord = True
//    GetSegId = False;
//    FieldCount = 0;
//   }

//   if(GetChar == SegTerm){
//    GetSegId = True;
//    FieldCount = FieldCount + 1;
//   }

//   //if(GetChar == MsgTerm){
//   if(segId == "MSH"){
//    if(GotRecord){
//     Write_To_File;
//     MsgEvent = "";
//      MsgDate = "";
//     FacID = "";
//     PtDOB = "";
//     PtGender = "";
//     PtLastName = "";
//     PtFirstName = "";
//     SurvMRN = "";
//     IncMRN = "";
//     GetDay = "";
//     GetMonth = "";
//     GetYear = "";
//     TempArray = "";
//     ptID = "";
//     Accession = "";
//     GotRecord = False;
//    }
//   }

//   switch(SegId){
//    Case "MSH";
//     GotRecord = False;
//     MSH_Segment;
//    Case "PID";
//     PID_Segment;
//    Case "PV1";
//     PV1_Segment;
//    Case "OBR";
//     OBR_Segment;
//    Case "MRG";
//     MRG_Segment     ;
//   }

//   StringValue = "";

//  }else if(GetChar != Chr(11)){
//   StringValue = StringValue + GetChar;
//  }


// Loop;

//        if(GotRecord){ Write_To_File;
//        oInputFile.Close  ;
//Next 


//oOutputFile.Close;
//// **** Edit here to reflect path && file name of temp file && new report file ******
//oOutputFSO.MoveFile "C:\Projects\TD Clients to AMG\Report Files\ClientList_InProgress.temp" , "C:\Projects\TD Clients to AMG\Report Files\ClientList.txt"


////Destroy Objects to prevent memory leaks
//oOutputFSO = null
//oReadFSO = null
//oFolder = null
//oFileCollection = null
//oInputFile = null
//oOutputFile = null



////----- Subroutines ---------------


//// HL7 Segments

//// -- MSH --
//void  MSH_Segment (){

// switch(FieldCount){
//  Case 1;
//   GotRecord = True;
//  Case 6;
//   GetYear = Left(StringValue, 4);
//   GetMonth = Mid(StringValue, 5, 2);
//   GetDay = Mid(StringValue, 7, 2);
//   GetHour = Mid(StringValue, 9, 2);
//   GetMin = Mid(StringValue, 11, 2);
//   MsgDate = GetMonth + "/" + GetDay + "/" + GetYear;
//   MsgTime = GetHour + ":" + GetMin

//  Case 8;
//   TempArray = "";
//   TempArray = Split(StringValue, "^")  ;
//   MsgEvent = TempArray(1)   ;
//  case 9: {

//    break;
//  }
// }

//}

//// -- PID -- 
//void  PID_Segment (){

// switch(FieldCount){
//  Case 3;
//   ptID = StringValue;
//  Case 5;
//   TempArray = "";
//   TempArray = Split(StringValue, "^")  ;
//   PtLastName = TempArray(0);
//   PtFirstName = TempArray(1)   ;
//  Case 7;
//   GetYear = "";
//   GetMonth = "";
//   GetDay = ""  ;
//   GetYear = Left(StringValue, 4);
//   GetMonth = Mid(StringValue, 5, 2);
//   GetDay = Mid(StringValue, 7, 2);
//   PtDOB = GetMonth + "/" + GetDay + "/" + GetYear        ;
//  Case 8;
//   PtGender = StringValue   ;
// }

//}

//// -- PV1 --
//void  PV1_Segment (){

// switch(FieldCount){
//  Case 3;
//   TempArray = "";
//   TempArray = Split(StringValue, "^")  ;
//   ClientID = TempArray(3) 

// }

//}

//// -- OBR --
//void  OBR_Segment (){

// switch(FieldCount){
//  Case 20;
//   Accession = StringValue;
// }

//}

//// -- MRG --
//void  MRG_Segment (){

// switch(FieldCount){
//  Case 1;
//   TempArray = "";
//   TempArray = Split(StringValue, "^")  ;
//   IncMRN = TempArray(0);
// }

//}


//// Write data from HL7 transaction as a record in the output file.
//void  Write_To_File (){

// oOutputFile.Write(MsgDate + '\t' + MsgTime + '\t' + ClientID + '\r\n')

//}




//}

//}