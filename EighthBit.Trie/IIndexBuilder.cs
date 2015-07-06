namespace EighthBit.Collection
{
    public interface IIndexBuilder<in TK, TN, out TI>
    {
        bool ShouldNormalize();
        TN Normalize(TK key);
        TI[] Build(TN key, int level);
    }
}