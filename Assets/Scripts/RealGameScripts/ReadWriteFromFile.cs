using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ReadWriteFromFile : MonoBehaviour
{
    public static ReadWriteFromFile instance;
    void Awake() { instance = this; }
    public void AppendText(string file, string text)
    {
        try
        {
            if (!File.Exists(file))
            {
                File.WriteAllText(file, text);
            }
            else
            {
                using (var writer = new StreamWriter(file, true))
                {
                    writer.WriteLine(text);
                }
            }
        }
        catch
        {
            Debug.Log("File is not written to");
        }

    }

    public string[] ReadText(string file)
    {
        try
        {
            if (file != null)
            {
                string[] lines = File.ReadAllLines(file);
                return lines;
            }
            return null;
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
            return null;
        }

    }
}
