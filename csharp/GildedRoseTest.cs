using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }

        [Test]
        public void DegradeNormalItem()
        {
            var item = new Item { Name = "normal", SellIn = 1, Quality = 5 };
            var app = new GildedRose(null);

            // check decreases by 1
            app.DegradeNormalItem(item);

            Assert.AreEqual(4, item.Quality);
            Assert.AreEqual(0, item.SellIn);

            // check decreases by 2 when past sell by
            app.DegradeNormalItem(item);

            Assert.AreEqual(2, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }

        [Test]
        public void AgeBrie()
        {
            var item = new Item { Name = GildedRose.AgedBrie, SellIn = 1, Quality = 47 };
            var app = new GildedRose(null);

            // check increases by 1 when before sell in
            app.AgeBrie(item);

            Assert.AreEqual(48, item.Quality);
            Assert.AreEqual(0, item.SellIn);

            // check increases by 2 when after sell in
            app.AgeBrie(item);

            Assert.AreEqual(50, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }


        [Test]
        public void DegradeConjuredItem()
        {
            var item = new Item { Name = "Conjured", SellIn = 1, Quality = 5 };
            var app = new GildedRose(null);

            // Check decreases by 2
            app.DegradeConjuredItem(item);

            Assert.AreEqual(3, item.Quality);
            Assert.AreEqual(0, item.SellIn);

            // Check decreases by 4 after sellin
            app.DegradeConjuredItem(item);

            Assert.AreEqual(0, item.Quality);
            Assert.AreEqual(-1, item.SellIn);
        }

        [Test]
        public void AgeBackstagePass_LessThan10Days_LessThan5Days()
        {
            var item = new Item { Name = GildedRose.BackstagePasses, SellIn = 6, Quality = 1 };
            var app = new GildedRose(null);

            app.AgeBackstagePass(item);

            Assert.AreEqual(3, item.Quality);
            Assert.AreEqual(5, item.SellIn);

            app.AgeBackstagePass(item);

            Assert.AreEqual(6, item.Quality);
            Assert.AreEqual(4, item.SellIn);
        }

        [Test]
        public void AgeBackstagePass_MoreThan10Days()
        {
            var item = new Item { Name = GildedRose.BackstagePasses, SellIn = 20, Quality = 1 };
            var app = new GildedRose(null);

            app.AgeBackstagePass(item);

            Assert.AreEqual(2, item.Quality);
            Assert.AreEqual(19, item.SellIn);
        }

    }
}
