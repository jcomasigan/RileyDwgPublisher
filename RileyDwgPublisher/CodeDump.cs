using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RileyDwgPublisher
{
    class CodeDump
    {

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
                                        if (ar.Tag.ToUpper() == "CADFILE")
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
                                        if (ar.Tag.ToUpper() == "CADFILE")
                                        {
                                            dwgDets.DwgStatus = ar.TextString;
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
                                        if (ar.Tag.ToUpper() == "SIGNATURES")
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
                                        if (ar.Tag.ToUpper() == "CADFILE")
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
                                        if (ar.Tag.ToUpper() == "SIGNATURES")
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
                                        if (ar.Tag.ToUpper() == "CADFILE")
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
                            #endregion
                        }
                    }
                }
                tr.Commit();
            }
            return dwgDets;
        }




        public static void FrzSignatureLayer(Database db)
        {
            Transaction tr = db.TransactionManager.StartTransaction();
            using (tr)
            {
                #region Signature Block Thaw
                //turn the signature layer on just double check
                LayerTable layerSig;
                string layerName = "SIGNATURES";
                layerSig = tr.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
                LayerTableRecord layTR;
                if (layerSig.Has(layerName))
                {
                    layTR = tr.GetObject(layerSig[layerName], OpenMode.ForWrite) as LayerTableRecord;
                    layTR.IsFrozen = false;
                    layTR.IsHidden = false;
                    layTR.IsOff = false;
                }
                try
                {
                    layTR = tr.GetObject(layerSig[layerName], OpenMode.ForWrite) as LayerTableRecord;
                    layTR.IsFrozen = false;
                    layTR.IsHidden = false;
                    layTR.IsOff = false;
                }
                catch
                {
                }
                //End signature layer on
                #endregion
                tr.Commit();
            }


        }


        public static void FreezeSigDwgs(SignatureData sigData)
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            string attbName = "SIGNATURES";
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
                            ed.WriteMessage("\n\nProcessing file: " + fileName);
                            db.ReadDwgFile(fileName, FileShare.ReadWrite, false, "");
                            int attributesChanged = 0;
                            FrzSignatureLayer(db);
                            ed.WriteMessage("\nUpdated {0} instance{1} of " + "attribute {2}.", attributesChanged, attributesChanged == 1 ? "" : "s", attbName);
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
                            ed.WriteMessage("\nProblem processing file: {0} - \"{1}\"", fileName, ex.Message);
                            problem++;
                        }
                    }
                }
            }
        }














    }
}

