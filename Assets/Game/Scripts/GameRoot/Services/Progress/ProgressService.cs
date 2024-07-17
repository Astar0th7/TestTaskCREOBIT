using Game.Scripts.Root.Services.Progress.Data;

namespace Game.Scripts.Root.Services.Progress
{
    public class ProgressService : IProgressService
    {
        public ProgressData Data { get; set; }

        public ProgressService()
        {
            Data = new ProgressData();
        }
    }
}