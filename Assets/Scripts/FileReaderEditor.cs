using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class FileReaderEditor : EditorWindow
{
    string filePath = "";
    string _txt = "";

    Vector2 scrollPos = new Vector2();


    [MenuItem("Window/FileReaderEditor")]
    public static void ShowWindow()
    {
        GetWindow<FileReaderEditor>("File Reader");
    }


    private void OnGUI()
    {
        GUILayout.Label("Select any file to see its content", EditorStyles.boldLabel);
        GUILayout.Space(20);
        GUILayout.Label("You can add only sprite renderer & box collider for now.", EditorStyles.boldLabel);

        //fileData = EditorGUILayout.TextField("File Data :", fileData);

        GUILayout.Space(10);
        GUILayout.Label("File Data", EditorStyles.boldLabel);

        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.MinHeight(50), GUILayout.MaxHeight(300));

        _txt = EditorGUILayout.TextArea(_txt, GUILayout.ExpandHeight(true), GUILayout.ExpandWidth(true));

        EditorGUILayout.EndScrollView();


        if (GUILayout.Button("Load File!!"))
        {
            FileLoader();
        }

        else if (GUILayout.Button("Save File !!"))
        {
            FileSaver();
        }

        else if (GUILayout.Button("Get Json data"))
        {
            GetJsonData();
        }


    }

    private void FileLoader()
    {
        filePath = EditorUtility.OpenFilePanel("Select Json file to load.", "", "json");
        Debug.Log(filePath);

        if (filePath.Length != 0)
        {
            StreamReader reader = new StreamReader(filePath);
            _txt = reader.ReadToEnd();

            JsonLoader.GetJsonObject(_txt.ToString(), Selection.activeGameObject?.transform);

            //Debug.Log(reader.ReadToEnd());
        }

    }

    private void FileSaver()
    {
        if (File.Exists(filePath))
        {
            StreamWriter writer = new StreamWriter(filePath);
            writer.WriteLine(_txt.ToString());

            writer.Close();

        }

        else
        {
            File.WriteAllText(filePath, "{\n}");

        }

        Debug.Log("File Saved!!");

    }

    private void GetJsonData()
    {
        JsonLoader.GetJsonObject(_txt.ToString(), Selection.activeGameObject?.transform);
        //GameObject obj = new GameObject("Emoji");

    }



}
