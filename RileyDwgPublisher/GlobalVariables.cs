using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RileyDwgPublisher
{
    class GlobalVariables
    {
        public static string  pdfDirectory = "";
        public static bool saveDwgs = true;
        public static bool outputPDFs = true;
        public static bool serverType = false;
        public static bool dateOverride = false;
        public static List<DrawingDetails> DwgDets = new List<DrawingDetails>();
        public static string caddCurrentLoc = "";
        public static bool FreezeSignatures = false;
        public static bool freezeAfter = false;
        public static bool ommitRegisterEntry = false;
        public static string dayBox = "";
        public static string monthBox = "";
        public static string yearBox = "";
    }

    public class DrawingDetails
    {
        public string DesignedBy { get; set; }
        public string CheckedBy { get; set; }
        public string DirectorSigned { get; set; }
        public string DaySigned { get; set; }
        public string MonthSigned { get; set; }
        public string YearSigned { get; set; }
        public string DatePublished { get; set; }
        public string DwgNumber { get; set; }
        public string DwgTitle { get; set; }
        public string DwgFileName { get; set; }
        public string DwgRev { get; set; }
        public string FilePath { get; set; }
        public string DwgStatus { get; set; }
        public string LayOutName { get; set; }

    }

    public class SignatureData
    {
        public string DesignedBy { get; set; }
        public string CheckedBy { get; set; }
        public string DirectorSigned { get; set; }
        public string DaySigned { get; set; }
        public string MonthSigned { get; set; }
        public string YearSigned { get; set; }
        public List<string> Dwgs { get; set; }
    }

    public class SignatureDDYYMM
    {
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
    }
}
