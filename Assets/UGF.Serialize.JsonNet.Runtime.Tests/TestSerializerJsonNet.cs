﻿using System;
using System.Collections;
using System.Threading.Tasks;
using NUnit.Framework;
using UGF.Serialize.Runtime;
using UnityEngine;
using UnityEngine.TestTools;

namespace UGF.Serialize.JsonNet.Runtime.Tests
{
    public class TestSerializerJsonNet
    {
        [Serializable]
        private class Target
        {
            [SerializeField] private bool m_boolValue = true;
            [SerializeField] private int m_intValue = 10;
            [SerializeField] private float m_floatValue = 10.5F;

            public bool BoolValue { get { return m_boolValue; } set { m_boolValue = value; } }
            public int IntValue { get { return m_intValue; } set { m_intValue = value; } }
            public float FloatValue { get { return m_floatValue; } set { m_floatValue = value; } }
        }

        [Test]
        public void Serialize()
        {
            var serialize = new SerializerJsonNet();
            var target = new Target();

            string text = serialize.Serialize(target);

            Assert.NotNull(text);
            Assert.Greater(text.Length, 0);
        }

        [Test]
        public void Deserialize()
        {
            var serialize = new SerializerJsonNet();
            var target = new Target();

            string text = serialize.Serialize(target);
            var target0 = serialize.Deserialize<Target>(text);

            Assert.AreEqual(target.BoolValue, target0.BoolValue);
            Assert.AreEqual(target.IntValue, target0.IntValue);
            Assert.AreEqual(target.FloatValue, target0.FloatValue);
        }

        [UnityTest]
        public IEnumerator SerializeAsync()
        {
            var serialize = new SerializerJsonNet();
            var target = new Target();

            Task<string> task = serialize.SerializeAsync(target);

            while (!task.IsCompleted)
            {
                yield return null;
            }

            string text = task.Result;

            Assert.NotNull(text);
            Assert.Greater(text.Length, 0);
        }

        [UnityTest]
        public IEnumerator DeserializeAsync()
        {
            var serialize = new SerializerJsonNet();
            var target = new Target();

            string text = serialize.Serialize(target);

            Task<Target> task = serialize.DeserializeAsync<Target>(text);

            while (!task.IsCompleted)
            {
                yield return null;
            }

            Target target0 = task.Result;

            Assert.AreEqual(target.BoolValue, target0.BoolValue);
            Assert.AreEqual(target.IntValue, target0.IntValue);
            Assert.AreEqual(target.FloatValue, target0.FloatValue);
        }

        [Test]
        public void Copy()
        {
            var serializer = new SerializerJsonNet();
            var target = new Target();

            Target copy = SerializeUtility.Copy(target, serializer);

            Assert.NotNull(copy);
            Assert.AreNotEqual(copy, target);
            Assert.AreNotSame(copy, target);
            Assert.AreEqual(copy.BoolValue, target.BoolValue);
            Assert.AreEqual(copy.IntValue, target.IntValue);
            Assert.AreEqual(copy.FloatValue, target.FloatValue);
        }
    }
}
