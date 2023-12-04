using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using FYP.Library.Common;

namespace FYP.Library.Config
{
    public class INIConfig
    {
        /// <summary>
        /// to hold ini file value (section / keyname / value)
        /// Example
        /// [section]
        /// keyname = "value"
        /// </summary>
        private struct Node
        {
            public string section, keyname, value;
        }

        private CommonFileOperation FO = new CommonFileOperation();
        private List<Node> Element = null; // Var Element List of ini file
        private static string filename; // ini file name
        private static bool ClassInit = false; // To make sure the class had been initialized

        /// <summary>
        /// ini file reader
        /// </summary>
        /// <param name="file">ini filename</param>
        public INIConfig(string file)
        {
            try
            {
                if (string.IsNullOrEmpty(file)) { throw new Exception("Invalid Data Source"); } // If the ini filename not set, i will throw this class
                if (!FO.FileExist(file)) { FO.CreateTextFile(file); } // create the ini file if it was not exist
                filename = file;
                ClassInit = true;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// read the file
        /// </summary>
        /// <returns>true = success, false = fail</returns>
        public bool Read()
        {
            try
            {
                if (!ClassInit) { throw new Exception("Invalid Data Source!"); } // Invalid data or not yet init
                using (StreamReader sr = new StreamReader(filename, Encoding.Unicode, true)) // read file in unicode
                {
                    string sec = null; // section
                    if (Element == null) { Element = new List<Node>(); } // Initialize the node if haven't created
                    else { Element.Clear(); }
                    while (true)
                    {
                        string var = sr.ReadLine();
                        if (var == null) { break; } // since no more data kill this loop
                        var = var.Trim(); // break into pieces
                        if (string.IsNullOrEmpty(var)) { Element.Add(new Node { section = "\u000A", keyname = null, value = null }); } // i found a space here
                        else if (var[0] == '#' || var[0] == ';' || (var[0] == '/' && var[1] == '/')) { Element.Add(new Node { section = "\u000B", keyname = null, value = var }); }// i was in a comment
                        else if (var[0] == '[') // finally here is section
                        {
                            int rsbIndex = var.IndexOf(']'); // setting a closing method
                            if (rsbIndex != -1)
                            {
                                sec = var.Substring(1, rsbIndex - 1).Trim();
                                if (!string.IsNullOrEmpty(sec)) { Element.Add(new Node { section = sec, keyname = string.Empty, value = null }); } // i will include you if you not empty only
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(sec)) // finally got key
                            {
                                string kn, kv; //kn = keyname, kv = keyvalue
                                int esIndex = var.IndexOf('=');
                                if (esIndex != -1)
                                {
                                    kn = var.Substring(0, esIndex).Trim(); // fetch my key
                                    if (!string.IsNullOrEmpty(kn)) // if this key is not empty
                                    {
                                        kv = var.Substring(esIndex + 1).Trim(); // fetch my value
                                        if (kv.Length >= 2) { if (kv[0] == '\u0022' && kv[kv.Length - 1] == '\u0022') { kv = kv.Substring(1, kv.Length - 2); } }// detect quotation mark
                                        Element.Add(new Node { section = sec, keyname = kn, value = kv });
                                    }
                                }
                            }
                        }
                    }
                    sr.Close();
                    return true;
                }
            }
            catch (Exception) { return false; } // the operation is fail
        }

        /// <summary>
        /// save to ini file
        /// </summary>
        /// <returns>true = success, false = fail</returns>
        public bool Save()
        {
            try
            {
                if (!ClassInit || Element == null) { throw new ApplicationException("Invalid Data Source!"); }// Invalid data or not yet init
                using (StreamWriter sw = new StreamWriter(filename, false, Encoding.Unicode))
                {
                    //searching element, and if section = \u000A is mean this is blank line, and if \u000B is mean comment line. If keyname is empty mean this is section, alternatively between key and value is cover with quotation mark
                    foreach (Node node in Element) { if (node.keyname == null) { if (node.section == "\u000A") { sw.WriteLine(); } else if (node.section == "\u000B") { sw.WriteLine(node.value); } } else { if (node.keyname == string.Empty) { sw.WriteLine("[" + node.section + "]"); } else { sw.WriteLine(node.keyname + "=\u0022" + node.value + "\u0022"); } } }
                    sw.Close();
                    return true;
                }
            }
            catch { return false; } // the operation is fail

        }

        /// <summary>
        /// Fetch key value
        /// </summary>
        /// <param name="section">section</param>
        /// <param name="keyName">keyname</param>
        /// <returns>value under string type</returns>
        public string Get(string sec, string kn)
        {
            try
            {
                if (!ClassInit || Element == null) { throw new Exception("Invalid Data Source!"); } // Invalid data or not yet init
                if (string.IsNullOrEmpty(sec) || string.IsNullOrEmpty(kn)) { return null; }// empty section or keyname
                var ValueQuery = (from node in Element where (string.Compare(node.section, sec, true) == 0 && string.Compare(node.keyname, kn, true) == 0) select node.value).ToArray();
                return (ValueQuery.Length == 0) ? null : ValueQuery[0]; // if length 0 = no such thing inside the ini file else give you the value
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// add/update section name or key name or key value, to save it Save(); must called
        /// </summary>
        /// <param name="sec">section</param>
        /// <param name="kn">key name</param>
        /// <param name="val">key value</param>
        /// <returns>true = success, false = fail</returns>
        public bool Write(string sec, string kn, string val)
        {
            try
            {
                if (!ClassInit) { throw new Exception("Invalid Data Source!"); } // Invalid data or not yet init
                bool secExist = false;
                if (string.IsNullOrEmpty(sec)) { return false; }// section is empty so nothing here can do
                if (Element == null) { Element = new List<Node>(); } // the list is not init, now create new list
                if (string.IsNullOrEmpty(kn)) { for (int i = Element.Count - 1; i >= 0; i--) { if (string.Compare(Element[i].section, sec, true) == 0 && Element[i].keyname != null) { Element.RemoveAt(i); } } } // delete entire section(from behind) since no key is found
                else // i'm update
                {
                    int InsIndex = -1;
                    for (int i = Element.Count - 1; i >= 0; i--)
                    {
                        if (string.Compare(Element[i].keyname, kn, true) == 0)
                        {
                            Element.RemoveAt(i); // delete the keyname
                            if (!string.IsNullOrEmpty(val)) // update this keyname
                            {
                                if (val.Length >= 2) { if (val[0] == '\u0022' && val[val.Length - 1] == '\u0022') { val = val.Substring(1, val.Length - 2); } } // detect quotation mark
                                Element.Insert(i, new Node { section = sec, keyname = kn, value = val }); // insert updated key and value
                            }
                            return true;
                        }
                        if (InsIndex == -1) { InsIndex = i + 1; } // end of the section as the insertion point
                    }

                    foreach (Node node in Element) { if (node.section == sec && node.keyname == string.Empty) { secExist = true; } } // fix some section cannot display, mistake of original reference

                    if (InsIndex == -1 || !secExist)
                    {
                        Element.Add(new Node { section = sec, keyname = string.Empty, value = null }); // section not exist, add it
                        Element.Add(new Node { section = sec, keyname = kn, value = val }); // add the key name and value now
                    }
                    else { Element.Insert(InsIndex, new Node { section = sec, keyname = kn, value = val }); } // section exist, add new key and value at end of section
                }
                return true;
            }
            catch { return false; } // Operation fail
        }
    }
}
