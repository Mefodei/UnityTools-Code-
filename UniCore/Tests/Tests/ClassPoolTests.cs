﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    using System.Diagnostics;
    using UniGreenModules.UniCore.Runtime.ObjectPool;
    using UniGreenModules.UniCore.Runtime.ObjectPool.Extensions;
    using UniGreenModules.UniCore.Runtime.ObjectPool.Interfaces;

    public class ClassPoolTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void DespawnCollectionTest()
        {
            //arrange
            var item1 = new List<int>(){2,3,4,5,6};
            var item2 = new List<int>(){2,3,4,5,6};
            
            //action
            item1.DespawnCollection();
            item2.DespawnCollection();
            
            //assert
            Assert.That(item1.Count == 0);
            Assert.That(item2.Count == 0);
        }

        
        // A Test behaves as an ordinary method
        [Test]
        public void SpawnExistsTest()
        {
            //arrange
            var item1 = new List<int>(){2,3,4,5,6};
            var item2 = new List<int>(){2,3,4,5,6};
            
            //action
            item1.DespawnCollection();
            item2.DespawnCollection();

            var result1 = ClassPool.SpawnExists<List<int>>();
            var result2 = ClassPool.SpawnExists<List<int>>();
            var result3 = ClassPool.SpawnExists<List<int>>();

            //assert
            Assert.That(result1 != null);
            Assert.That(result2 != null);
            Assert.That(result3 == null);
            
            
        }
        
        // A Test behaves as an ordinary method
        [Test]
        public void DespawnPoolableItemTest()
        {
            
            //arrange
            var item1 = new PoolableTestItem();
            
            //action
            item1.Despawn();
            
            //assert
            Assert.That(item1.IsReleased);
        }
        
        private class PoolableTestItem : IPoolable
        {
            public bool IsReleased { get; protected set; }

            public void Release()
            {
                IsReleased = true;
            }
        }
        
    }
}