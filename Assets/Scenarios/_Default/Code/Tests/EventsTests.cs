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
        [Test]
        public void TestLifeEvents()
        {
            Life.OnBorn += (sender, eventArgs) => {
                Assert.That(sender, Is.SameAs(Life));
                Assert.That(eventArgs.Father, Is.TypeOf<Life>());
                Assert.That(eventArgs.Mother, Is.TypeOf<Life>());
            };
            Life.OnGrown += (sender, eventArgs) => {
                Assert.That(sender, Is.SameAs(Life));
                Assert.That(eventArgs, Is.SameAs(EventArgs.Empty));
            };
            Life.OnReproduced += (sender, partner) => {
                Assert.That(sender, Is.SameAs(Life));
                Assert.That(partner, Is.TypeOf<Life>());
            };
            Life.OnDied += (sender, cause) => {
                Assert.That(sender, Is.SameAs(Life));
                Assert.That(cause, Is.TypeOf<Life.DeathCause>());
            };

            Life.Live();
        }
    }
}