using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wulka.Agent;
using Wulka.Domain;

namespace Wulka.Test
{
    [TestClass]
    public abstract class ServiceTestFixtureBase
    {


        public virtual void Try_GetServiceEndpoints()
        {
            var res = GetServiceEndpoints();
            if (res == null || !res.Any()) throw new Exception("No Endpoints found");
            foreach (var point in res)
            {
                Console.WriteLine("{0}:{1}", point.ContractNamespace, point.ContractName);
            }
        }



        public SerializableEndpoint[] GetServiceEndpoints()
        {
            return DiscoPortal
                .Disco
                .GetEndpoints(GetContractType());
        }

        protected abstract string GetContractType();

    }
}
