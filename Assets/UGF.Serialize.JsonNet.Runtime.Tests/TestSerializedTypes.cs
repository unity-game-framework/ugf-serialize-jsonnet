using System;
using NUnit.Framework;
using UGF.Serialize.Runtime;

namespace UGF.Serialize.JsonNet.Runtime.Tests
{
    public class TestSerializedTypes
    {
        [SerializeType]
        private class Target
        {
        }

        [Test]
        public void NotVisible()
        {
            var type1 = Type.GetType("UGF.Serialize.JsonNet.Runtime.Tests.TestCustomSerializer+Target1, UGF.Serialize.JsonNet.Runtime.Tests, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null");
            var type2 = Type.GetType("UGF.Serialize.JsonNet.Runtime.Tests.TestSerializedTypes+Target, UGF.Serialize.JsonNet.Runtime.Tests, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null");

            Assert.NotNull(type1);
            Assert.NotNull(type2);

            object result1 = Activator.CreateInstance(type1);
            object result2 = Activator.CreateInstance(type2);

            Assert.NotNull(result1);
            Assert.NotNull(result2);
        }
    }

    [SerializeType("c8703a9b7b514209a05c64835ab4d0a5")]
    public class TestSerialized1
    {
    }

    [SerializeType]
    public class TestSerialized2
    {
    }

    [SerializeType("882939dac4ed40c1a3789174e0e3e2c9")]
    public class TestSerialized3
    {
    }

    [SerializeType]
    public abstract class TestSerializedAbstract
    {
    }
}
