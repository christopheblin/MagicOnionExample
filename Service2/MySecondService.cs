using MagicOnion;
using MagicOnion.Server;
using Service1Def;
using Service2Def;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service2
{
    class MySecondService : ServiceBase<IMySecondService>, IMySecondService
    {
        private IMyFirstService adder;

        public MySecondService(IMyFirstService adder)
        {
            this.adder = adder;
        }

        public async UnaryResult<MultiplyResponse> Multiply(MultiplyRequest r)
        {
            Logger.Debug($"Received Multiply: {r.x}, {r.y}");
            //example to call another service that is injected : do not do this in real life :)
            if (r.x == 0 || r.y == 0) return new MultiplyResponse() { res = 0 };
            var sign = (r.x > 0 && r.y < 0) || (r.x < 0 && r.y > 0) ? -1 : 1;
            var res = Math.Abs(r.x);
            for (var i = 1; i < Math.Abs(r.y); i++)
            {
                res = (await this.adder.Sum(new SumRequest() { x = res, y = Math.Abs(r.x) })).res;
            }
            return new MultiplyResponse() { res = res * sign };
        }
    }
}
