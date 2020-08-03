﻿using System;
using System.IO;
using Todo.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(Todo.iOS.DbPath))]
namespace Todo.iOS
{
    public class DbPath : IDbPath
    {
        public string GetPath(string dbName)
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), dbName);
        }
    }
}