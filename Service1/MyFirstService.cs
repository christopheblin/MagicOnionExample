using MagicOnion;
using MagicOnion.Server;
using Service1Def;

class MyFirstService : ServiceBase<IMyFirstService>, IMyFirstService
{
    public async UnaryResult<SumResponse> Sum(SumRequest r)
    {
        Logger.Debug($"Received Sum: {r.x}, {r.y}");
        return new SumResponse() { res = r.x + r.y };
    }
}