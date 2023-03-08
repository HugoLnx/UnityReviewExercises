using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace ReviewEvents
{
    public class EventTests
    {
        private LifeSolution _life;
        public LifeSolution Life => _life ??= new LifeSolution();
        // private Life _life;
        // public Life Life => _life ??= new Life();

        [SetUp]
        public void ResetLife() => _life = null;

        [Test]
        public void Live_OnBornCallback_ReceivesArgsProperly()
        {
            Life.OnBorn += (sender, eventArgs) => {
                Assert.That(sender, Is.SameAs(Life));
                Assert.That(eventArgs.Father, Is.TypeOf<Life>());
                Assert.That(eventArgs.Mother, Is.TypeOf<Life>());
            };

            Life.Live();
        }

        [Test]
        public void Live_OnGrownCallback_DontReceiveArgs()
        {
            Life.OnGrown += (sender, eventArgs) => {
                Assert.That(sender, Is.SameAs(Life));
                Assert.That(eventArgs, Is.SameAs(EventArgs.Empty));
            };

            Life.Live();
        }

        [Test]
        public void Live_OnReproducedCallback_ReceivesArgsProperly()
        {
            Life.OnReproduced += (sender, partner) => {
                Assert.That(sender, Is.SameAs(Life));
                Assert.That(partner, Is.TypeOf<Life>());
            };

            Life.Live();
        }

        [Test]
        public void Live_OnDiedCallback_ReceivesArgsProperly()
        {
            Life.OnDied += (sender, cause) => {
                Assert.That(sender, Is.SameAs(Life));
                Assert.That(cause, Is.TypeOf<Life.DeathCause>());
            };

            Life.Live();
        }

        [Test]
        public void Live_OnBornCallback_IsCalled()
        {
            bool called = false;
            Life.OnBorn += (_, _) => called = true;

            Life.Live();

            Assert.True(called);
        }

        [Test]
        public void Live_OnGrownCallback_IsCalled()
        {
            bool called = false;
            Life.OnGrown += (_, _) => called = true;

            Life.Live();

            Assert.True(called);
        }

        [Test]
        public void Live_OnReproducedCallback_IsCalled()
        {
            bool called = false;
            Life.OnGrown += (_, _) => called = true;

            Life.Live();

            Assert.True(called);
        }

        [Test]
        public void Live_OnDiedCallback_IsCalled()
        {
            bool called = false;
            Life.OnDied += (_, _) => called = true;

            Life.Live();

            Assert.True(called);
        }
    }
}