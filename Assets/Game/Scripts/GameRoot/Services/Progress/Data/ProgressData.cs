using System;

namespace Game.Scripts.Root.Services.Progress.Data
{
    [Serializable]
    public class ProgressData
    {
        public GameFirstData GameFirstData;

        public ProgressData()
        {
            GameFirstData = new GameFirstData();
        }
    }
}