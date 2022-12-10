using System.Collections.Generic;
using NUnit.Framework;
using UGF.RuntimeTools.Runtime.Contexts;
using UGF.Serialize.Runtime;
using UnityEngine;

namespace UGF.Serialize.JsonNet.Runtime.Tests
{
    public class TestCustomSerializer
    {
        [SerializeType("target")]
        private class Target
        {
            public List<object> Targets { get; set; } = new List<object>();
        }

        [SerializeType("target1")]
        private class Target1
        {
            public int IntValue { get; set; } = 10;
            public float FloatValue { get; set; } = 10.5F;
        }

        [SerializeType("target2")]
        private class Target2
        {
            public bool BoolValue { get; set; } = true;
            public int IntValue { get; set; } = 10;
        }

        [Test]
        public void SerializeAndDeserialize()
        {
            var builder = Resources.Load<SerializerAsset>("SerializerJsonNetCustom");
            var serializer = builder.Build<ISerializer<string>>();

            var target = new Target()
            {
                Targets =
                {
                    new Target1(),
                    new Target2()
                }
            };

            string result = serializer.Serialize(target, new Context());
            string expected = Resources.Load<TextAsset>("SerializerJsonNetCustomResult").text;

            Assert.AreEqual(expected, result);

            var result2 = serializer.Deserialize<Target>(result, new Context());

            Assert.NotNull(result2);
            Assert.IsNotEmpty(result2.Targets);
            Assert.AreEqual(2, result2.Targets.Count);
            Assert.IsInstanceOf<Target1>(result2.Targets[0]);
            Assert.IsInstanceOf<Target2>(result2.Targets[1]);
            Assert.Pass(result);
        }
    }
}
