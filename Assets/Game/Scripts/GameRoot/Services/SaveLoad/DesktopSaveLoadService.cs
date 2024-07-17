using System.IO;
using Game.Scripts.Root.Services.Progress;
using Game.Scripts.Root.Services.Progress.Data;
using Game.Scripts.Utils;
using UnityEngine;

namespace Game.Scripts.Root.Services.SaveLoad
{
    public class DesktopSaveLoadService : ISaveLoadService
    {
        private const string DATA = "Data.json";
        
        private readonly IProgressService _progressService;


        public DesktopSaveLoadService(IProgressService progressService)
        {
            _progressService = progressService;
        }

        public void Save()
        {
            using StreamWriter fileStream = new(BuildPath(DATA));
            fileStream.Write(_progressService.Data.ToSerialized());
        }

        public void Load()
        {
            string path = BuildPath(DATA);
            if (!File.Exists(path))
            {
                _progressService.Data = new ProgressData();
                return;
            }   
            
            using StreamReader fileStream = new(path);
            _progressService.Data = fileStream.ReadToEnd().ToDeserialized<ProgressData>();
        }
        
        private string BuildPath(string data) => 
            Path.Combine(Application.persistentDataPath, data);
    }
}