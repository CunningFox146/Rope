using Rope.Infrastructure;

namespace Rope.Services.Sound
{
    public interface ISoundPlayer : IService
    {
        void Play(SoundData soundData);
    }
}