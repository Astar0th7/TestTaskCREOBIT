using Game.Scripts.Root.Services.Progress.Data;

namespace Game.Scripts.Root.Services.Progress
{
    public interface IProgressService
    {
        ProgressData Data { get; set; }
    }
}