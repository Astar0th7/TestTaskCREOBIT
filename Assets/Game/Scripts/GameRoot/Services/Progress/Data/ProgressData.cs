using System;

namespace Game.Scripts.Root.Services.Progress.Data
{
    [Serializable]
    public class ProgressData
    {
        public GameFirstData GameFirstData;
        public GameSecondData GameSecondData;

        public ProgressData()
        {
            GameFirstData = new GameFirstData();
            GameSecondData = new GameSecondData();
        }
    }
}