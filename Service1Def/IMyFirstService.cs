using Grpc.Core;
using MagicOnion;
using MagicOnion.Client;
using MessagePack;
using System;

namespace Service1Def
{
    public interface IMyFirstService : IService<IMyFirstService>
    {
        UnaryResult<SumResponse> Sum(SumRequest r);
    }

    public abstract class MyFirstServiceClientFactory
    {
        public static IMyFirstService Build()
        {
            return MagicOnionClient.Create<IMyFirstService>(new Channel("localhost", 12301, ChannelCredentials.Insecure));
        }
    }

    [MessagePackObject]
    public class SumRequest
    {
        [Key(0)]
        public int x;
        [Key(1)]
        public int y;
    }

    [MessagePackObject]
    public class SumResponse
    {
        [Key(0)]
        public int res;
    }
}
