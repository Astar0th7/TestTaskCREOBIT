using System;

namespace Game.Scripts.Root.Services.Progress.Data
{
    [Serializable]
    public class GameFirstData
    {
        public int CountClicks;

        public GameFirstData()
        {
            Reset();
        }

        public void Reset()
        {
            CountClicks = 0;
        }
    }
}