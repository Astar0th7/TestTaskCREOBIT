using System;

namespace Game.Scripts.Root.Services.Progress.Data
{
    [Serializable]
    public class GameSecondData
    {
        public DateTime Time;
        
        public GameSecondData()
        {
            Reset();
        }

        public void Reset()
        {
            Time = new DateTime();
        }
    }
}