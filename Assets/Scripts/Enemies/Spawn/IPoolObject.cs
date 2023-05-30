namespace Enemies.Spawn
{
    public interface IPoolObject
    {
        public bool InUse { get; set; }
        public void Clear();
    }
}