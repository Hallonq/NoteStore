using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{
    public static void Main(string[] args)
    {
        // input
        NotesStore.AddNote("active", "DrinkTea");
        NotesStore.AddNote("completed", "WakeUp");
        NotesStore.AddNote("others", "WorkOut");
        NotesStore.GetNotes("active");
    }
}

class NotesStore
{
    public NotesStore()
    {

    }
    public static Dictionary<string, string> notes = new Dictionary<string, string>();

    public static void AddNote(string state, string name)
    {
        if (string.IsNullOrEmpty(state))
        {
            throw new Exception("Name cannot be empty");
        }
        else if (!string.IsNullOrEmpty(state) && (state != "completed" && state != "active" && state != "others"))
        {
            throw new Exception($"Invalid state { state }");
        }
        else
        {
            notes.Add(name, state);
        }
    }

    public static void RemoveCompleted()
    {
        foreach (var item in notes)
        {
            if (item.Value == "completed")
            {
                notes.Remove(item.Key);
            }
        }
    }

    public static List<string> GetNotes(string state)
    {
        List<string> tempList = new List<string>();

        if (!string.IsNullOrEmpty(state) && (state != "completed" && state != "active" && state != "others"))
        {
            throw new Exception($"Invalid state { state }");
        }
        else
        {
            foreach (var item in notes)
            {
                if (item.Value == state)
                {
                    tempList.Add(item.Key);
                }
            }
        }

        return tempList;
    }
}
