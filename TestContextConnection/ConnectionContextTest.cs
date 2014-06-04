using System;
using Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Protocol;
using Framework;

namespace TestContextConnection
{
    [TestClass]
    public class ConnectionContextTest
    {
        [TestMethod]
        public void TestConnectionContext()
        {
            IVpnProtocol vpn = new OpenVPN("Server1", 2222);
            var ctx = new Context(new ConnectionStateDisconnected(vpn), vpn);
            Assert.IsFalse(ctx.IsConnected());
            ctx.Connect();
            Assert.IsTrue(ctx.IsConnected());
            ctx.Connect();
            ctx.Disconnect();
            Assert.IsFalse(ctx.IsConnected());
        }
    }
}
