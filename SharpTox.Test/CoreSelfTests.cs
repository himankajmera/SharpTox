﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SharpTox.Core;
using System.Threading;

namespace SharpTox.Test
{
    [TestClass]
    public class CoreSelfTests
    {
        [TestMethod]
        public void TestToxPortBind()
        {
            var tox1 = new Tox(new ToxOptions(true, false));
            var tox2 = new Tox(new ToxOptions(true, true));

            var error = ToxErrorGetPort.Ok;
            int port = tox1.GetUdpPort(out error);
            if (error != ToxErrorGetPort.NotBound)
                Assert.Fail("Tox bound to an udp port while it's not supposed to, port: {0}", port);

            port = tox2.GetUdpPort(out error);
            if (error != ToxErrorGetPort.Ok)
                Assert.Fail("Failed to bind to an udp port");

            tox1.Dispose();
            tox2.Dispose();
        }

        [TestMethod]
        public void TestToxLoadData()
        {
            var tox1 = new Tox(ToxOptions.Default);
            tox1.Name = "Test";
            tox1.StatusMessage = "Hey";

            var data = tox1.GetData();
            var tox2 = new Tox(ToxOptions.Default, data.Bytes);

            if (tox2.Id != tox1.Id)
                Assert.Fail("Failed to load tox data correctly, tox id's don't match");

            if (tox2.Name != tox1.Name)
                Assert.Fail("Failed to load tox data correctly, names don't match");

            if (tox2.StatusMessage != tox1.StatusMessage)
                Assert.Fail("Failed to load tox data correctly, status messages don't match");

            tox1.Dispose();
            tox2.Dispose();
        }

        [TestMethod]
        public void TestToxSelfName()
        {
            var tox = new Tox(ToxOptions.Default);
            string name = "Test name";
            tox.Name = name;

            if (tox.Name != name)
                Assert.Fail("Failed to set/retrieve name");

            tox.Dispose();
        }

        [TestMethod]
        public void TestToxSelfStatusMessage()
        {
            var tox = new Tox(ToxOptions.Default);
            string statusMessage = "Test status message";
            tox.StatusMessage = statusMessage;

            if (tox.StatusMessage != statusMessage)
                Assert.Fail("Failed to set/retrieve status message");

            tox.Dispose();
        }

        [TestMethod]
        public void TestToxSelfStatus()
        {
            var tox = new Tox(ToxOptions.Default);
            var status = ToxUserStatus.Away;
            tox.Status = status;

            if (tox.Status != status)
                Assert.Fail("Failed to set/retrieve status");

            tox.Dispose();
        }

        [TestMethod]
        public void TestToxNospam()
        {
            var tox = new Tox(ToxOptions.Default);
            byte[] randomBytes = new byte[sizeof(uint)];
            new Random().NextBytes(randomBytes);

            uint nospam = BitConverter.ToUInt32(randomBytes, 0);
            tox.SetNospam(nospam);

            if (nospam != tox.GetNospam())
                Assert.Fail("Failed to set/get nospam correctly, values don't match");

            tox.Dispose();
        }

        [TestMethod]
        public void TestToxEmojiId()
        {
            var tox = new Tox(ToxOptions.Default);
            Console.WriteLine("Original ID: {0}", tox.Id);

            string emojiId = tox.Id.ToEmojiString();
            Assert.IsTrue(emojiId.Length > 0, "Failed to convert tox id to emoji string");

            Console.WriteLine("Emoji ID: {0}", emojiId);

            var id = ToxId.FromEmojiString(emojiId);
            Assert.IsTrue(id != null, "Failed to convert emoji string back to tox id");
        }

        [TestMethod]
        [Timeout(120000)]
        [Ignore]
        public void TestToxProxySocks5()
        {
            var options = new ToxOptions(true, ToxProxyType.Socks5, "127.0.0.1", 9050);
            var tox = new Tox(options);
            var error = ToxErrorBootstrap.Ok;

            foreach (var node in Globals.TcpRelays)
            {
                bool result = tox.AddTcpRelay(node, out error);
                if (!result || error != ToxErrorBootstrap.Ok)
                    Assert.Fail("Failed to bootstrap, error: {0}, result: {1}", error, result);
            }

            tox.Start();
            while (!tox.IsConnected) { Thread.Sleep(10); }

            Console.WriteLine("Tox connected!");
            tox.Dispose();
        }
    }
}
