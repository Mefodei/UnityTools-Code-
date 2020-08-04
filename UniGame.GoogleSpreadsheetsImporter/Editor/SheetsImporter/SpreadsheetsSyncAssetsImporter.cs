﻿namespace UniModules.UniGame.GoogleSpreadsheetsImporter.Editor.SheetsImporter
{
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class SpreadsheetsSyncAssetsImporter : ScriptableObject, ISpreadsheetAssetsHandler
    {
        public abstract void Load();

        public abstract void Import(SpreadsheetData spreadsheetData);
        
    }
}