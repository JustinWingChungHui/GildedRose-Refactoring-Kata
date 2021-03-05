using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp
{
    public class GildedRose
    {
        public const string AgedBrie = "Aged Brie";
        public const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        public const string Sulfuras = "Sulfuras, Hand of Ragnaros";

        private List<string> SpecialItems = new List<string>
        {
            AgedBrie,
            BackstagePasses,
            Sulfuras
        };

        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }



        public void UpdateQuality()
        {
            // Normal items
            foreach (var item in Items.Where(i => !SpecialItems.Contains(i.Name)
                                            && !i.Name.Contains("Conjured")))
            {
                DegradeNormalItem(item);
            }

            // Brie
            foreach (var item in Items.Where(i => i.Name == AgedBrie))
            {
                AgeBrie(item);
            }

            // Backstage passes
            foreach (var item in Items.Where(i => i.Name == BackstagePasses))
            {
                AgeBackstagePass(item);
            }

            // Conjured Items
            foreach (var item in Items.Where(i => i.Name.Contains("Conjured")))
            {
                DegradeConjuredItem(item);
            }

        }

        /// <summary>
        /// Degrades a conjured item
        /// </summary>
        /// <param name="conjuredItem"></param>
        public void DegradeConjuredItem(Item conjuredItem)
        {
            //"Conjured" items degrade in Quality twice as fast as normal items
            // degrade rate is double if past Sellin
            var degradeRate = conjuredItem.SellIn <= 0 ? 4 : 2;
            conjuredItem.Quality = Math.Max(conjuredItem.Quality - degradeRate, 0);

            conjuredItem.SellIn -= 1;
        }

        /// <summary>
        /// Degrades a normal item
        /// </summary>
        /// <param name="item"></param>
        public void DegradeNormalItem(Item item)
        {
            // degrade rate is double if past Sellin
            var degradeRate = item.SellIn <= 0 ? 2 : 1;
            item.Quality = Math.Max(item.Quality - degradeRate, 0);

            item.SellIn -= 1;
        }

        /// <summary>
        /// Ages a backstage pass
        /// </summary>
        /// <param name="pass"></param>

        public void AgeBackstagePass(Item pass)
        {
            // "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;
            int change;

            // Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but
            // Quality drops to 0 after the concert
            if (pass.SellIn <= 0)
            {
                change = -pass.Quality;
            }
            else if (pass.SellIn <= 5)
            {
                change = 3;
            }
            else if (pass.SellIn <= 10)
            {
                change = 2;
            }
            else
            {
                change = 1;
            }

            pass.Quality = Math.Min(50, pass.Quality + change);

            pass.SellIn -= 1;        
        }


        /// <summary>
        /// Ages Brie
        /// </summary>
        /// <param name="brie"></param>
        public void AgeBrie(Item brie)
        {
            // code suggests quality doubles after sell by date
            var change = brie.SellIn <= 0 ? 2 : 1;

            // The Quality of an item is never more than 50
            brie.Quality = Math.Min(50, brie.Quality + change);

            brie.SellIn -= 1;          
        }

    }
}
