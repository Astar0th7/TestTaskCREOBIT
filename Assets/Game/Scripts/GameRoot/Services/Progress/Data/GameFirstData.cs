using System;

namespace Game.Scripts.Root.Services.Progress.Data
{
    [Serializable]
    public class GameFirstData
    {
        public int ClickCount;

        public event Action<int> ClickCountValueChangeEvent; 

        public GameFirstData()
        {
            Reset();
        }

        public void Reset()
        {
            ClickCount = 0;
        }

        public void Click()
        {
            ClickCount++;
            ClickCountValueChangeEvent?.Invoke(ClickCount);
        }
    }
}