﻿using Hyperledger.Indy.SignusApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Hyperledger.Indy.Test.PairwiseTests
{
    [TestClass]
    public class PairwiseIntegrationTestBase : IndyIntegrationTestWithSingleWallet
    {
        protected string myDid;
        protected string theirDid;
        protected const string PAIR_TEMPLATE = "{{\"my_did\":\"{0}\",\"their_did\":\"{1}\"}}";

        [TestInitialize]
        public async Task CreateDids()
        {
            var result = await Signus.CreateAndStoreMyDidAsync(wallet, "{}");
            myDid = result.Did;

            result = await Signus.CreateAndStoreMyDidAsync(wallet, "{}");
            theirDid = result.Did;

            await Signus.StoreTheirDidAsync(wallet, string.Format("{{\"did\":\"{0}\"}}", theirDid));
        }
    }
}
