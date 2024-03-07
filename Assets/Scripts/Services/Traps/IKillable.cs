using UnityEngine;

namespace Rope.Services.Traps
{
    public interface IKillable
    {
        void Kill(GameObject killer);
    }
}