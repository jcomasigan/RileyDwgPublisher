using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.PlottingServices;    
using System.IO;

namespace RileyDwgPublisher
{

    class SignatureUpdate
    {
        //list of dwgs and their layout
        static List<string> dwgPath = new List<string>();
        static List<string> dwgsLayouts = new List<string>();

        #region Legacy Block Updater
        public static int UpdateAttributesInBlock(Database db, ObjectId btrId, SignatureData sigData)
        {
            //Signature Block Attribute Names
            //HAS TO BE CAPS SO WE CAN IGNORE CASE IN CHECKING
            string blockName = "SIGNATURES";
            string blockNameOld = "SIGNED";
            string designedAttb = "DES";
            string checkedAttb = "DWG";
            string directorAttb = "DIRECTOR";
            string directorAttbMispell = "DRIECTOR"; //there are two variations. One with typo
            string dayAttb = "DAY";
            string monthAttb = "MONTH";
            string yearAttb = "YEAR";
            // return the number of attributes modified
            int changedCount = 0;
            Transaction tr = db.TransactionManager.StartTransaction();
            List<ObjectId> objList = new List<ObjectId>();
            using (tr)
            {
                BlockTableRecord btr = (BlockTableRecord)tr.GetObject(btrId, OpenMode.ForRead);
                foreach (ObjectId entId in btr)
                {                  
                    Entity ent = tr.GetObject(entId, OpenMode.ForRead) as Entity;
                    if (ent != null)
                    {
                        BlockReference br = ent as BlockReference;
                        if (br != null)
                        {
                            if (br.Name == "SIGNATURES")
                            {
                                br.UpgradeOpen();
                                br.Layer = "SIGNATURES";
                                br.DowngradeOpen();
                            }
                            BlockTableRecord bd = (BlockTableRecord)tr.GetObject(br.BlockTableRecord, OpenMode.ForRead);
                            if (bd.Name.ToUpper() == blockName)
                            {
                                objList.Add(bd.ObjectId);
                                foreach (ObjectId arId in br.AttributeCollection)
                                {
                                    DBObject obj = tr.GetObject(arId, OpenMode.ForRead);
                                    AttributeReference ar = obj as AttributeReference;
                                    if (ar != null)
                                    {
                                        #region Attributes Of The Block
                                        //if it's designed
                                        if (ar.Tag.ToUpper() == designedAttb)
                                        {
                                            ar.UpgradeOpen();
                                            ar.TextString = sigData.DesignedBy;
                                            // Begin alignment code
                                            Database wdb = HostApplicationServices.WorkingDatabase;
                                            HostApplicationServices.WorkingDatabase = db;
                                            ar.AdjustAlignment(db);
                                            HostApplicationServices.WorkingDatabase = wdb;
                                            // End alignment code
                                            ar.DowngradeOpen();
                                            changedCount++;
                                        }
                                        //if it's checked
                                        if (ar.Tag.ToUpper() == checkedAttb)
                                        {
                                            ar.UpgradeOpen();
                                            ar.TextString = sigData.CheckedBy;
                                            // Begin alignment code
                                            Database wdb = HostApplicationServices.WorkingDatabase;
                                            HostApplicationServices.WorkingDatabase = db;
                                            ar.AdjustAlignment(db);
                                            HostApplicationServices.WorkingDatabase = wdb;
                                            // End alignment code
                                            ar.DowngradeOpen();
                                            changedCount++;
                                        }
                                        //if it's director
                                        if (ar.Tag.ToUpper() == directorAttb)
                                        {
                                            ar.UpgradeOpen();
                                            ar.TextString = sigData.DirectorSigned;
                                            // Begin alignment code
                                            Database wdb = HostApplicationServices.WorkingDatabase;
                                            HostApplicationServices.WorkingDatabase = db;
                                            ar.AdjustAlignment(db);
                                            HostApplicationServices.WorkingDatabase = wdb;
                                            // End alignment code
                                            ar.DowngradeOpen();
                                            changedCount++;
                                        }
                                        //if it's driector (misspelled)
                                        if (ar.Tag.ToUpper() == directorAttbMispell)
                                        {
                                            ar.UpgradeOpen();
                                            ar.TextString = sigData.DirectorSigned;
                                            // Begin alignment code
                                            Database wdb = HostApplicationServices.WorkingDatabase;
                                            HostApplicationServices.WorkingDatabase = db;
                                            ar.AdjustAlignment(db);
                                            HostApplicationServices.WorkingDatabase = wdb;
                                            // End alignment code
                                            ar.DowngradeOpen();
                                            changedCount++;
                                        }
                                        //if it's day
                                        if (ar.Tag.ToUpper() == dayAttb)
                                        {
                                            ar.UpgradeOpen();
                                            ar.TextString = sigData.DaySigned;
                                            // Begin alignment code
                                            Database wdb = HostApplicationServices.WorkingDatabase;
                                            HostApplicationServices.WorkingDatabase = db;
                                            ar.AdjustAlignment(db);
                                            HostApplicationServices.WorkingDatabase = wdb;
                                            // End alignment code
                                            ar.DowngradeOpen();
                                            changedCount++;
                                        }
                                        //if it's month
                                        if (ar.Tag.ToUpper() == monthAttb)
                                        {
                                            ar.UpgradeOpen();
                                            ar.TextString = sigData.MonthSigned;
                                            // Begin alignment code
                                            Database wdb = HostApplicationServices.WorkingDatabase;
                                            HostApplicationServices.WorkingDatabase = db;
                                            ar.AdjustAlignment(db);
                                            HostApplicationServices.WorkingDatabase = wdb;
                                            // End alignment code
                                            ar.DowngradeOpen();
                                            changedCount++;
                                        }
                                        //if it's year
                                        if (ar.Tag.ToUpper() == yearAttb)
                                        {
                                            ar.UpgradeOpen();
                                            ar.TextString = sigData.YearSigned;
                                            // Begin alignment code
                                            Database wdb = HostApplicationServices.WorkingDatabase;
                                            HostApplicationServices.WorkingDatabase = db;
                                            ar.AdjustAlignment(db);
                                            HostApplicationServices.WorkingDatabase = wdb;
                                            // End alignment code
                                            ar.DowngradeOpen();
                                            changedCount++;
                                        }
                                        #endregion
                                    }
                                }
                            }
                            if (bd.Name.ToUpper() == blockNameOld)
                            {
                                objList.Add(bd.ObjectId);
                                foreach (ObjectId arId in br.AttributeCollection)
                                {
                                    DBObject obj = tr.GetObject(arId, OpenMode.ForRead);
                                    AttributeReference ar = obj as AttributeReference;
                                    if (ar != null)
                                    {
                                        #region Attributes Of The Block
                                        //if it's designed
                                        if (ar.Tag.ToUpper() == designedAttb)
                                        {
                                            ar.UpgradeOpen();
                                            ar.TextString = sigData.DesignedBy;
                                            // Begin alignment code
                                            Database wdb = HostApplicationServices.WorkingDatabase;
                                            HostApplicationServices.WorkingDatabase = db;
                                            ar.AdjustAlignment(db);
                                            HostApplicationServices.WorkingDatabase = wdb;
                                            // End alignment code
                                            ar.DowngradeOpen();
                                            changedCount++;
                                        }
                                        //if it's checked
                                        if (ar.Tag.ToUpper() == checkedAttb)
                                        {
                                            ar.UpgradeOpen();
                                            ar.TextString = sigData.CheckedBy;
                                            // Begin alignment code
                                            Database wdb = HostApplicationServices.WorkingDatabase;
                                            HostApplicationServices.WorkingDatabase = db;
                                            ar.AdjustAlignment(db);
                                            HostApplicationServices.WorkingDatabase = wdb;
                                            // End alignment code
                                            ar.DowngradeOpen();
                                            changedCount++;
                                        }
                                        //if it's director
                                        if (ar.Tag.ToUpper() == directorAttb)
                                        {
                                            ar.UpgradeOpen();
                                            ar.TextString = sigData.DirectorSigned;
                                            // Begin alignment code
                                            Database wdb = HostApplicationServices.WorkingDatabase;
                                            HostApplicationServices.WorkingDatabase = db;
                                            ar.AdjustAlignment(db);
                                            HostApplicationServices.WorkingDatabase = wdb;
                                            // End alignment code
                                            ar.DowngradeOpen();
                                            changedCount++;
                                        }
                                        //if it's driector (misspelled)
                                        if (ar.Tag.ToUpper() == directorAttbMispell)
                                        {
                                            ar.UpgradeOpen();
                                            ar.TextString = sigData.DirectorSigned;
                                            // Begin alignment code
                                            Database wdb = HostApplicationServices.WorkingDatabase;
                                            HostApplicationServices.WorkingDatabase = db;
                                            ar.AdjustAlignment(db);
                                            HostApplicationServices.WorkingDatabase = wdb;
                                            // End alignment code
                                            ar.DowngradeOpen();
                                            changedCount++;
                                        }
                                        //if it's day
                                        if (ar.Tag.ToUpper() == dayAttb)
                                        {
                                            ar.UpgradeOpen();
                                            ar.TextString = sigData.DaySigned;
                                            // Begin alignment code
                                            Database wdb = HostApplicationServices.WorkingDatabase;
                                            HostApplicationServices.WorkingDatabase = db;
                                            ar.AdjustAlignment(db);
                                            HostApplicationServices.WorkingDatabase = wdb;
                                            // End alignment code
                                            ar.DowngradeOpen();
                                            changedCount++;
                                        }
                                        //if it's month
                                        if (ar.Tag.ToUpper() == monthAttb)
                                        {
                                            ar.UpgradeOpen();
                                            ar.TextString = sigData.MonthSigned;
                                            // Begin alignment code
                                            Database wdb = HostApplicationServices.WorkingDatabase;
                                            HostApplicationServices.WorkingDatabase = db;
                                            ar.AdjustAlignment(db);
                                            HostApplicationServices.WorkingDatabase = wdb;
                                            // End alignment code
                                            ar.DowngradeOpen();
                                            changedCount++;
                                        }
                                        //if it's year
                                        if (ar.Tag.ToUpper() == yearAttb)
                                        {
                                            ar.UpgradeOpen();
                                            ar.TextString = sigData.YearSigned;
                                            // Begin alignment code
                                            Database wdb = HostApplicationServices.WorkingDatabase;
                                            HostApplicationServices.WorkingDatabase = db;
                                            ar.AdjustAlignment(db);
                                            HostApplicationServices.WorkingDatabase = wdb;
                                            // End alignment code
                                            ar.DowngradeOpen();
                                            changedCount++;
                                        }
                                        #endregion
                                    }
                                }
                            }
                            #region New Title Block
                            //New Block
                            if (bd.Name.ToUpper() == "TITLA3L")
                            {
                                objList.Add(bd.ObjectId);
                                foreach (ObjectId arId in br.AttributeCollection)
                                {
                                    DBObject obj = tr.GetObject(arId, OpenMode.ForRead);
                                    AttributeReference ar = obj as AttributeReference;
                                    if (ar != null)
                                    {
                                        #region Attributes Of The Block
                                        //if it's designed
                                        if (ar.Tag.ToUpper() == "DES")
                                        {
                                            ar.UpgradeOpen();
                                            ar.TextString = sigData.DesignedBy;
                                            // Begin alignment code
                                            Database wdb = HostApplicationServices.WorkingDatabase;
                                            HostApplicationServices.WorkingDatabase = db;
                                            ar.AdjustAlignment(db);
                                            HostApplicationServices.WorkingDatabase = wdb;
                                            // End alignment code
                                            ar.DowngradeOpen();
                                            changedCount++;
                                        }
                                        //if it's checked
                                        if (ar.Tag.ToUpper() == "DWG")
                                        {
                                            ar.UpgradeOpen();
                                            ar.TextString = sigData.CheckedBy;
                                            // Begin alignment code
                                            Database wdb = HostApplicationServices.WorkingDatabase;
                                            HostApplicationServices.WorkingDatabase = db;
                                            ar.AdjustAlignment(db);
                                            HostApplicationServices.WorkingDatabase = wdb;
                                            // End alignment code
                                            ar.DowngradeOpen();
                                            changedCount++;
                                        }
                                        //if it's director
                                        if (ar.Tag.ToUpper() == "DRIECTOR")
                                        {
                                            ar.UpgradeOpen();
                                            ar.TextString = sigData.DirectorSigned;
                                            // Begin alignment code
                                            Database wdb = HostApplicationServices.WorkingDatabase;
                                            HostApplicationServices.WorkingDatabase = db;
                                            ar.AdjustAlignment(db);
                                            HostApplicationServices.WorkingDatabase = wdb;
                                            // End alignment code
                                            ar.DowngradeOpen();
                                            changedCount++;
                                        }
                                        //if it's day
                                        if (ar.Tag.ToUpper() == "DAY")
                                        {
                                            ar.UpgradeOpen();
                                            ar.TextString = sigData.DaySigned;
                                            // Begin alignment code
                                            Database wdb = HostApplicationServices.WorkingDatabase;
                                            HostApplicationServices.WorkingDatabase = db;
                                            ar.AdjustAlignment(db);
                                            HostApplicationServices.WorkingDatabase = wdb;
                                            // End alignment code
                                            ar.DowngradeOpen();
                                            changedCount++;
                                        }
                                        //if it's month
                                        if (ar.Tag.ToUpper() == "MONTH")
                                        {
                                            ar.UpgradeOpen();
                                            ar.TextString = sigData.MonthSigned;
                                            // Begin alignment code
                                            Database wdb = HostApplicationServices.WorkingDatabase;
                                            HostApplicationServices.WorkingDatabase = db;
                                            ar.AdjustAlignment(db);
                                            HostApplicationServices.WorkingDatabase = wdb;
                                            // End alignment code
                                            ar.DowngradeOpen();
                                            changedCount++;
                                        }
                                        //if it's year
                                        if (ar.Tag.ToUpper() == "YEAR")
                                        {
                                            ar.UpgradeOpen();
                                            ar.TextString = sigData.YearSigned;
                                            // Begin alignment code
                                            Database wdb = HostApplicationServices.WorkingDatabase;
                                            HostApplicationServices.WorkingDatabase = db;
                                            ar.AdjustAlignment(db);
                                            HostApplicationServices.WorkingDatabase = wdb;
                                            // End alignment code
                                            ar.DowngradeOpen();
                                            changedCount++;
                                        }
                                        #endregion
                                    }
                                }
                            }
                            #endregion
                            changedCount += UpdateAttributesInBlock(db, br.BlockTableRecord, sigData); // nested blocks shoudlnt need but try

                        }
                    }
                }
                #region Signature Block Thaw
                //turn the signature layer on
                LayerTable layerSigs;
                string layerNameS = "SIGNATURES";
                string layerNameSold = "SIGNED";
                layerSigs = tr.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
                LayerTableRecord layTRS;
                if (layerSigs.Has(layerNameS))
                {
                    layTRS = tr.GetObject(layerSigs[layerNameS], OpenMode.ForWrite) as LayerTableRecord;
                    layTRS.IsFrozen = false;
                    layTRS.IsHidden = false;
                    layTRS.IsOff = false;
                }
                try
                {
                    layTRS = tr.GetObject(layerSigs["SIGNATURES"], OpenMode.ForWrite) as LayerTableRecord;
                    layTRS.IsFrozen = false;
                    layTRS.IsHidden = false;
                    layTRS.IsOff = false;
                }
                catch
                {
                }
                if (layerSigs.Has(layerNameSold))
                {
                    layTRS = tr.GetObject(layerSigs[layerNameSold], OpenMode.ForWrite) as LayerTableRecord;
                    layTRS.IsFrozen = false;
                    layTRS.IsHidden = false;
                    layTRS.IsOff = false;
                }
                try
                {
                    layTRS = tr.GetObject(layerSigs[layerNameSold], OpenMode.ForWrite) as LayerTableRecord;
                    layTRS.IsFrozen = false;
                    layTRS.IsHidden = false;
                    layTRS.IsOff = false;
                }
                catch
                {
                }
                #endregion
                tr.Commit();

            }           
            return changedCount;
        }



        public static int UpdateAttributesInDatabase(Database db, SignatureData sigVal, string fileProcessing)
        {            
            SignatureData sig = sigVal;
            ObjectId psId;
            Transaction tr = db.TransactionManager.StartTransaction();
            int psCount = 0;
            using (tr)
            {
                //iterate through layout?
                DBDictionary layoutDic = tr.GetObject(db.LayoutDictionaryId, OpenMode.ForRead, false) as DBDictionary;
                foreach (DBDictionaryEntry entry in layoutDic)
                {                    
                    ObjectId layoutId = entry.Value;
                    Layout layout = tr.GetObject(layoutId, OpenMode.ForRead) as Layout;
                    if (layout.LayoutName != "Model")
                    {
                        //Only plot layouts
                        BlockTable bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                        psId = layout.BlockTableRecordId;
                        int count = UpdateAttributesInBlock(db, psId, sig); //Signature updater
                        DrawingDetails dets = new DrawingDetails();
                        GetDwgDetails(db, psId, dets, fileProcessing);
                        psCount = count + psCount;
                        string layoutTitle = layout.LayoutName;
                        //Add layout and dwg to both list to retrieve later.
                        dets.LayOutName = layout.LayoutName;
                        dwgPath.Add(fileProcessing);
                        dwgsLayouts.Add(layoutTitle);
                        if (GlobalVariables.ommitRegisterEntry == false)
                        {
                            WriteToRegister(dets);
                        }

                        GlobalVariables.DwgDets.Add(dets);
                    }
                }
                tr.Commit();
            }
            return psCount;
        }




        public static void UpdateAttributeInFiles(SignatureData sigData)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            string attbName = "SIGNATURES";
            dwgsLayouts.Clear();
            dwgPath.Clear();   

            string[] fileNames = sigData.Dwgs.ToArray();
            int processed = 0, saved = 0, problem = 0;
            foreach (string fileName in fileNames)
            {
                if (fileName.EndsWith(".dwg", StringComparison.CurrentCultureIgnoreCase))
                {
                    string outputName = fileName;
                    Database db = new Database(false, false);
                    using (db)
                    {
                        try
                        {
                            ed.WriteMessage( "\n\nProcessing file: " + fileName);
                            db.ReadDwgFile(fileName, FileShare.ReadWrite, false, "");
                            int attributesChanged = 0;
                            if(GlobalVariables.FreezeSignatures == false)
                            {
                                attributesChanged = UpdateAttributesInDatabase(db, sigData, fileName);
                                ed.WriteMessage( "\nUpdated {0} instance{1} of " + "attribute {2}.", attributesChanged, attributesChanged == 1 ? "" : "s", attbName);
                            }
                            else
                            {
                                FrzSigLayInDb(db);
                            }
                            // Only save if we changed something
                            if (attributesChanged > 0)
                            {
                                ed.WriteMessage("\nSaving to file: {0}", outputName);
                                try
                                {
                                    db.SaveAs(outputName, DwgVersion.Current);
                                }
                                catch
                                {
                                    System.Windows.MessageBox.Show("Can't save drawing " + Path.GetFileName(fileName));
                                }
                                saved++;
                            }
                            processed++;
                        }
                        catch (System.Exception ex)
                        {
                            ed.WriteMessage( "\nProblem processing file: {0} - \"{1}\"", fileName, ex.Message);
                            problem++;
                        }
                    }
                }
            }

            ed.WriteMessage("\n\nSuccessfully processed {0} files, of which {1} had " + "attributes to update and an additional {2} had errors " +
                             "during reading/processing.",
                             processed, saved, problem);
            string result = "\n\nSuccessfully updated the signature block of " + processed + " files.  " + problem + " had errors during reading/processing.";
            if(GlobalVariables.outputPDFs)
            {
              PublishDwgs();
            }
            if (GlobalVariables.freezeAfter)
            {
                FreezeSigDwgs(sigData);
            }
        }
        #endregion


        public static void PublishDwgs()
        {
            string tempPath = "C:\\temp";
            for(int i = 0; i < GlobalVariables.DwgDets.Count; i++)
            {
                string fileProcessing = GlobalVariables.DwgDets[i].FilePath;
                string layoutTitle = GlobalVariables.DwgDets[i].LayOutName;
                string dwgNo = GlobalVariables.DwgDets[i].DwgNumber;
                dwgNo = ReplaceBarr(dwgNo);
                string revNo = GlobalVariables.DwgDets[i].DwgRev;
                if (System.IO.File.Exists(tempPath + "\\sigdrawings.dsd"))
                {
                   System.IO.File.Delete(tempPath + "\\sigdrawings.dsd");
                }
                PublishLayouts(fileProcessing, layoutTitle, dwgNo, revNo);

            }
        }

        private static string ReplaceBarr(string jobNo)
        {
            if (jobNo.Contains("/"))
            {
                jobNo.Replace("/", "_");
            }
            if (jobNo.Contains(@"\"))
            {
                jobNo.Replace(@"\", "_");
            }
            return jobNo;
        }

        public static void PublishLayouts(string file, string layout, string dwgNo, string revNo)
        {
            string date = GetDate();
            string tempPath = "C:\\temp";
            string fileDir = Path.GetDirectoryName(file);
            string fileTitle = dwgNo;
            ReplaceBarr(dwgNo);
            string layoutname = layout;
            using (DsdEntryCollection dsdDwgFiles = new DsdEntryCollection())
            {
                using (DsdEntry dsdDwgFile = new DsdEntry())
                {
                    
                    dsdDwgFile.DwgName = file;
                    dsdDwgFile.Layout = layout;
                    dsdDwgFile.Title = dwgNo + " (" + revNo + ")";
                    dsdDwgFile.Nps = "";
                    dsdDwgFile.NpsSourceDwg = "";
                    dsdDwgFiles.Add(dsdDwgFile);
                }
                using (DsdData dsdFileData = new DsdData())
                {
                    dsdFileData.DestinationName = fileDir + "\\" + fileTitle + "(" + revNo + ")" + ".pdf";
                    //System.Windows.MessageBox.Show(fileDir + "\\" + fileTitle + ".pdf");
                    if (Directory.Exists(fileDir + "\\PDF\\"))
                    {
                        dsdFileData.ProjectPath = fileDir + "\\PDF\\";
                    }
                    else
                    {
                        Directory.CreateDirectory(dsdFileData.ProjectPath = fileDir + "\\PDF\\");
                        dsdFileData.ProjectPath = fileDir + "\\PDF\\";
                    }
                    if(Directory.Exists(fileDir + "\\PDF\\" + date))
                    {
                        dsdFileData.ProjectPath = fileDir + "\\PDF\\" + date ;
                    }
                    else
                    {
                        Directory.CreateDirectory(dsdFileData.ProjectPath = fileDir + "\\PDF\\" + date);
                        dsdFileData.ProjectPath = fileDir + "\\PDF\\" + date;
                    }
                    dsdFileData.SheetType = SheetType.SinglePdf;
                    dsdFileData.SetDsdEntryCollection(dsdDwgFiles);
                    dsdFileData.LogFilePath = tempPath + "\\Batch.txt";
                    dsdFileData.WriteDsd(tempPath + "\\sigdrawings.dsd");
                    
                    
                    try
                    {
                        Version ver = Autodesk.AutoCAD.ApplicationServices.Application.Version;
                        if (ver.Major >= 20)
                        {
                            try
                            {
                                Application.SetSystemVariable("BACKGROUNDPLOT", 0);
                                Application.SetSystemVariable("EPDFSHX", 0);
                            }
                            catch (Autodesk.AutoCAD.Runtime.Exception es1)
                            {
                                /*
                                System.Windows.Forms.MessageBox.Show(es1.ToString());
                                Version ver = Autodesk.AutoCAD.ApplicationServices.Application.Version;
                                 * */
                            }
                        }
                        else
                        {
                            Application.SetSystemVariable("BACKGROUNDPLOT", 0);
                        }
                        using (DsdData dsdDataFile = new DsdData())
                        {
                            dsdDataFile.ReadDsd(tempPath + "\\sigdrawings.dsd");                           
                            //Works on my pc but not others
                            PlotConfig acPlCfg = PlotConfigManager.SetCurrentConfig("DWG to PDF.PC3");
                            //PlotConfig acPlCfg = PlotConfigManager.CurrentConfig;                         
                            Application.Publisher.PublishExecute(dsdDataFile, acPlCfg);
                            GlobalVariables.pdfDirectory = dsdFileData.ProjectPath = fileDir + "\\PDF\\" + date;                         
                            //end of working 
                        }
                    }
                    catch (Autodesk.AutoCAD.Runtime.Exception es)
                    {
                        System.Windows.Forms.MessageBox.Show(es.Message);
                    }
                }
            }
        }

        public static void WriteToRegister(DrawingDetails dets)
        {
            try
            {
                string newFileName = GlobalVariables.caddCurrentLoc + "\\PDF\\register.csv";

                string dwgDetails = string.Format("{0},{1},{2},{3},{4},{5} {6}",
                                                    System.DateTime.Now.ToString(), dets.DwgNumber, dets.DwgTitle, dets.DwgStatus, dets.DwgRev, dets.DirectorSigned, Environment.NewLine);
                if (!Directory.Exists(GlobalVariables.caddCurrentLoc + "\\PDF\\"))
                {
                    Directory.CreateDirectory(GlobalVariables.caddCurrentLoc + "\\PDF\\");
                }
                if (!File.Exists(newFileName))
                {
                    string registerHeader = "DATE,DWG NO,TITLE,REV DETAILS,REV,APPROVED BY" + Environment.NewLine;

                    File.WriteAllText(newFileName, registerHeader);
                }

                File.AppendAllText(newFileName, dwgDetails);
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }

        
        public static void CreateDsd(List<string> files, List<string> layouts)
        {
            string tempPath = "C:\\temp";
            string fileDir = "";
            string fileTitle = "";
            DsdEntryCollection dsdDwgFiles = new DsdEntryCollection() ;
            for (int i = 0; i < dwgPath.Count; i++)
            {
                string file = files[i];
                string layout = layouts[i];
                fileDir = Path.GetDirectoryName(file);
                //fileDir = "c:\\temp\\";
                fileTitle = Path.GetFileNameWithoutExtension(file);
                using (dsdDwgFiles = new DsdEntryCollection())
                {
                    // Define the layout
                    dsdDwgFiles = null;
                    using (DsdEntry dsdDwgFile = new DsdEntry())
                    {
                        dsdDwgFile.DwgName = file;
                        dsdDwgFile.Layout = layout;
                        dsdDwgFile.Title = fileTitle + layout;
                        dsdDwgFile.Nps = "";
                        dsdDwgFile.NpsSourceDwg = "";
                        dsdDwgFiles.Add(dsdDwgFile);
                    }
                }
             }
                    using (DsdData dsdFileData = new DsdData())
                    {
                        dsdFileData.DestinationName = fileDir + "\\" + fileTitle + ".pdf";
                        if(Directory.Exists(fileDir + "\\pdfs\\"))
                        {
                            dsdFileData.ProjectPath = fileDir + "\\pdfs\\";
                        }
                        else
                        {
                            Directory.CreateDirectory(dsdFileData.ProjectPath = fileDir + "\\pdfs\\");
                            dsdFileData.ProjectPath = fileDir + "\\pdfs\\";
                        }
                        dsdFileData.SheetType = SheetType.SinglePdf;
                        dsdFileData.SetDsdEntryCollection(dsdDwgFiles);
                        dsdFileData.LogFilePath = tempPath + "\\Batch.txt";
                        dsdFileData.WriteDsd(tempPath + "\\sigdrawings.dsd");
                    }
            }

        public static DrawingDetails GetDwgDetails(Database db, ObjectId btrId, DrawingDetails dwgDets, string file)
        {
            Transaction tr = db.TransactionManager.StartTransaction();
            using (tr)
            {
                BlockTableRecord btr = (BlockTableRecord)tr.GetObject(btrId, OpenMode.ForRead);
                foreach (ObjectId entId in btr)
                {
                    Entity ent = tr.GetObject(entId, OpenMode.ForRead) as Entity;
                    if (ent != null)
                    {
                        BlockReference br = ent as BlockReference;
                        if (br != null)
                        {
                            BlockTableRecord bd = (BlockTableRecord)tr.GetObject(br.BlockTableRecord, OpenMode.ForRead);
                            #region New Title Block
                            if (bd.Name.ToUpper() == "TITLA3L") //New Title block. Contains all details.
                            {
                                foreach (ObjectId arId in br.AttributeCollection)
                                {
                                    DBObject obj = tr.GetObject(arId, OpenMode.ForRead);
                                    AttributeReference ar = obj as AttributeReference;
                                    if (ar != null)
                                    {
                                        #region Attributes Of The Block
                                        if (ar.Tag.ToUpper() == "TITLE")
                                        {
                                            dwgDets.DwgTitle = ar.TextString;
                                        }
                                        if (ar.Tag.ToUpper() == "NO")
                                        {
                                            dwgDets.DwgNumber = ar.TextString;
                                        }
                                        if (ar.Tag.ToUpper() == "CADFILE")
                                        {
                                            dwgDets.DwgFileName = ar.TextString;
                                        }
                                        if (ar.Tag.ToUpper() == "STATUS")
                                        {
                                            dwgDets.DwgStatus = ar.TextString;
                                        }
                                        if (ar.Tag.ToUpper() == "0")
                                        {
                                            dwgDets.DwgRev = ar.TextString;
                                        }
                                        if (ar.Tag.ToUpper() == "DES")
                                        {
                                            dwgDets.DesignedBy = ar.TextString;
                                        }
                                        if (ar.Tag.ToUpper() == "DWG")
                                        {
                                            dwgDets.CheckedBy = ar.TextString;
                                        }
                                        if (ar.Tag.ToUpper() == "DRIECTOR")
                                        {
                                            dwgDets.DirectorSigned = ar.TextString;
                                        }
                                        if (ar.Tag.ToUpper() == "DAY")
                                        {
                                            dwgDets.DaySigned = ar.TextString;
                                        }
                                        if (ar.Tag.ToUpper() == "MONTH")
                                        {
                                            dwgDets.MonthSigned = ar.TextString;
                                        }
                                        if (ar.Tag.ToUpper() == "YEAR")
                                        {
                                            dwgDets.YearSigned = ar.TextString;
                                        }
                                        dwgDets.FilePath = file;
                                        #endregion
                                    }
                                }
                            }
                            #endregion
                            #region Old Title Block
                            if (bd.Name.ToUpper() == "TITL-A3L")
                            {
                                foreach (ObjectId arId in br.AttributeCollection)
                                {
                                    DBObject obj = tr.GetObject(arId, OpenMode.ForRead);
                                    AttributeReference ar = obj as AttributeReference;
                                    if (ar != null)
                                    {
                                        #region Attributes Of The Block
                                        if (ar.Tag.ToUpper() == "TITLE")
                                        {
                                            dwgDets.DwgTitle = ar.TextString;
                                        }
                                        if (ar.Tag.ToUpper() == "NO")
                                        {
                                            dwgDets.DwgNumber = ar.TextString;
                                        }
                                        if (ar.Tag.ToUpper() == "CADFILE")
                                        {
                                            dwgDets.DwgFileName = ar.TextString;
                                        }
                                        if (ar.Tag.ToUpper() == "0")
                                        {
                                            dwgDets.DwgRev = ar.TextString;
                                        }
                                        dwgDets.FilePath = file;
                                        #endregion
                                    }
                                }
                            }
                            #region Signatures Block
                            if (bd.Name.ToUpper() == "SIGNATURES")
                            {
                                foreach (ObjectId arId in br.AttributeCollection)
                                {
                                    DBObject obj = tr.GetObject(arId, OpenMode.ForRead);
                                    AttributeReference ar = obj as AttributeReference;
                                    if (ar != null)
                                    {
                                        #region Attributes Of The Block
                                        if (ar.Tag.ToUpper() == "DES")
                                        {
                                            dwgDets.DesignedBy = ar.TextString;
                                        }
                                        if (ar.Tag.ToUpper() == "DWG")
                                        {
                                            dwgDets.CheckedBy = ar.TextString;
                                        }
                                        if (ar.Tag.ToUpper() == "DIRECTOR")
                                        {
                                            dwgDets.DirectorSigned = ar.TextString;
                                        }
                                        if (ar.Tag.ToUpper() == "DRIECTOR")
                                        {
                                            dwgDets.DirectorSigned = ar.TextString;
                                        }
                                        if (ar.Tag.ToUpper() == "DAY")
                                        {
                                            dwgDets.DaySigned = ar.TextString;
                                        }
                                        if (ar.Tag.ToUpper() == "MONTH")
                                        {
                                            dwgDets.MonthSigned = ar.TextString;
                                        }
                                        if (ar.Tag.ToUpper() == "YEAR")
                                        {
                                            dwgDets.YearSigned = ar.TextString;
                                        }
                                        dwgDets.FilePath = file;
                                        #endregion
                                    }
                                }
                            }
                            #endregion
                            #region Signed Block
                            if (bd.Name.ToUpper() == "SIGNED")
                            {
                                foreach (ObjectId arId in br.AttributeCollection)
                                {
                                    DBObject obj = tr.GetObject(arId, OpenMode.ForRead);
                                    AttributeReference ar = obj as AttributeReference;
                                    if (ar != null)
                                    {
                                        #region Attributes Of The Block
                                        if (ar.Tag.ToUpper() == "DES")
                                        {
                                            dwgDets.DesignedBy = ar.TextString;
                                        }
                                        if (ar.Tag.ToUpper() == "DWG")
                                        {
                                            dwgDets.CheckedBy = ar.TextString;
                                        }
                                        if (ar.Tag.ToUpper() == "DIRECTOR")
                                        {
                                            dwgDets.DirectorSigned = ar.TextString;
                                        }
                                        if (ar.Tag.ToUpper() == "DRIECTOR")
                                        {
                                            dwgDets.DirectorSigned = ar.TextString;
                                        }
                                        if (ar.Tag.ToUpper() == "DAY")
                                        {
                                            dwgDets.DaySigned = ar.TextString;
                                        }
                                        if (ar.Tag.ToUpper() == "MONTH")
                                        {
                                            dwgDets.MonthSigned = ar.TextString;
                                        }
                                        if (ar.Tag.ToUpper() == "YEAR")
                                        {
                                            dwgDets.YearSigned = ar.TextString;
                                        }
                                        dwgDets.FilePath = file;
                                        #endregion
                                    }
                                }
                            }
                            #endregion
                            #region Status Block
                            if (bd.Name.ToUpper() == "DWG STATUS")
                            {
                                foreach (ObjectId arId in br.AttributeCollection)
                                {
                                    DBObject obj = tr.GetObject(arId, OpenMode.ForRead);
                                    AttributeReference ar = obj as AttributeReference;
                                    if (ar != null)
                                    {
                                        #region Attributes Of The Block
                                        if (ar.Tag.ToUpper() == "STATUS")
                                        {
                                            dwgDets.DwgStatus = ar.TextString;
                                        }
                                        #endregion
                                    }
                                }
                            }
                            #endregion
                            #endregion
                        }
                    }
                }
                tr.Commit();
            }
            return dwgDets;
        }

        public static string GetDate()
        {
            System.DateTime now = DateTime.Now;
            int day = now.Day;
            int month = now.Month;
            int year = now.Year;
            //format
            string dayTxt = day.ToString();
            string monthTxt = month.ToString();
            if (day < 10)
            {
                dayTxt = "0" + dayTxt;
            }
            if (month < 10)
            {
                monthTxt = "0" + monthTxt;
            }
            string yearTxt = year.ToString();
            yearTxt = yearTxt.Substring(2, 2);
            string date = string.Format("{0}.{1}.{2}", yearTxt, monthTxt, dayTxt);
            return date;
        }
        public static SignatureDDYYMM GetDateSignatureFormat()
        {
            System.DateTime now = DateTime.Now;
            int day = now.Day;
            int month = now.Month;
            int year = now.Year;
            //format
            string dayTxt = day.ToString();
            string monthTxt = month.ToString();
            if (day < 10)
            {
                dayTxt = "0" + dayTxt;
            }
            if (month < 10)
            {
                monthTxt = "0" + monthTxt;
            }
            string yearTxt = year.ToString();
            yearTxt = yearTxt.Substring(2, 2);
            SignatureDDYYMM sigDYM = new SignatureDDYYMM();
            if (GlobalVariables.dateOverride == false)
            {
                sigDYM.Day = dayTxt;
                sigDYM.Month = monthTxt;
                sigDYM.Year = yearTxt;
            }
            else
            {
                sigDYM.Day = GlobalVariables.dayBox;
                sigDYM.Month = GlobalVariables.monthBox;
                sigDYM.Year = GlobalVariables.yearBox;
            }

            return sigDYM;
        }

        public static void FrzSigLayInDb(Database db)
        {
            Transaction tr = db.TransactionManager.StartTransaction();
            using (tr)
            {
                #region Signature Block Freeze
                //turn the signature layer on
                LayerTable layerSigs;
                string layerNameS = "SIGNATURES";
                string layerNameSold = "SIGNED";
                layerSigs = tr.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
                LayerTableRecord layTRS;
                if (layerSigs.Has(layerNameS))
                {
                    layTRS = tr.GetObject(layerSigs[layerNameS], OpenMode.ForWrite) as LayerTableRecord;
                    layTRS.IsFrozen = true;
                }
                try
                {
                    layTRS = tr.GetObject(layerSigs["SIGNATURES"], OpenMode.ForWrite) as LayerTableRecord;
                    layTRS.IsFrozen = true;
                }
                catch
                {
                }
                if (layerSigs.Has(layerNameSold))
                {
                    layTRS = tr.GetObject(layerSigs[layerNameSold], OpenMode.ForWrite) as LayerTableRecord;
                    layTRS.IsFrozen = true;
                }
                try
                {
                    layTRS = tr.GetObject(layerSigs[layerNameSold], OpenMode.ForWrite) as LayerTableRecord;
                    layTRS.IsFrozen = true;
                }
                catch
                {
                }
                #endregion
                /*
                #region Signature Block Freeze
                //turn the signature layer on just double check
                LayerTable layerSig;
                string layerName = "SIGNATURES";
                layerSig = tr.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
                LayerTableRecord layTR;
                if (layerSig.Has(layerName))
                {
                    layTR = tr.GetObject(layerSig[layerName], OpenMode.ForWrite) as LayerTableRecord;
                    layTR.IsFrozen = true;               
                }
                //End signature layer on
                #endregion
                 * */
                tr.Commit();
            }
        }

        public static void FreezeSigDwgs(SignatureData sigData)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;       
            string[] fileNames = sigData.Dwgs.ToArray();
            foreach (string fileName in fileNames)
            {
                if (fileName.EndsWith(".dwg", StringComparison.CurrentCultureIgnoreCase))
                {
                    string outputName = fileName;
                    Database db = new Database(false, false);
                    using (db)
                    {
                        try
                        {
                            ed.WriteMessage("\n\nProcessing file: " + fileName);
                            db.ReadDwgFile(fileName, FileShare.ReadWrite, false, "");
                            FrzSigLayInDb(db);
                            ed.WriteMessage("Frozen Signature Layer");
                            ed.WriteMessage("\nSaving to file: {0}", outputName);
                            try
                            {
                                db.SaveAs(outputName, DwgVersion.Current);
                            }
                            catch
                            {
                                System.Windows.MessageBox.Show("Can't save drawing " + Path.GetFileName(fileName));
                            }
                        }
                        catch (System.Exception ex)
                        {
                            ed.WriteMessage("\nProblem processing file: {0} - \"{1}\"", fileName, ex.Message);
                        }
                    }
                }
            }
        }


}
}

