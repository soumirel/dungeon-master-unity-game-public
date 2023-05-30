public abstract class Effect
{
    public int TicksCount => ticksCount;
    public float TicksInterval => ticksInterval;

    protected int ticksCount;
    protected float ticksInterval;

    public Effect()
    {

    }

    public abstract void Apply();
}

