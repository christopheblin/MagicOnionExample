using MagicOnion;
using MessagePack;

namespace Service2Def
{
    public interface IMySecondService : IService<IMySecondService>
    {
        UnaryResult<MultiplyResponse> Multiply(MultiplyRequest r);
    }

    [MessagePackObject]
    public class MultiplyRequest
    {
        [Key(0)]
        public int x;
        [Key(1)]
        public int y;
    }

    [MessagePackObject]
    public class MultiplyResponse
    {
        [Key(0)]
        public int res;
    }
}
