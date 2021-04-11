using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

/// <summary>
/// Summary description for ServerFile
/// </summary>
public class ServerFileHelper
{
    public ServerFileHelper()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string createIfNotExist(string path, bool isDirection = true)
    {
        try
        {
            if (isDirection)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return "";
            }
            else
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                }
                return "";
            }

        }
        catch (Exception ex) { return ex.Message; }
    }
    public static bool isExistFile(string path, bool isDirection = true)
    {
        try
        {
            if (isDirection)
            {
                if (!Directory.Exists(path))
                {
                    return true;
                }
                return false;
            }
            else
            {
                if (File.Exists(path))
                {
                    return true;
                }
                return false;
            }

        }
        catch (Exception ex) { return false; }
    }
    public static string deleteFile(string path)
    {
        try
        {
            if (!File.Exists(path))
            {
                File.Delete(path);
                return "";
            }
            else
                return "File's not exist!";
        }
        catch (Exception ex) { return ex.Message; }
    }
    public static void deleteFileIfExist(string path)
    {
        try
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
        catch (Exception ex) { }
    }
}