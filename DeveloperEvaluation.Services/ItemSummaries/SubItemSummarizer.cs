using System;
using System.Collections.Generic;
using System.Linq;

namespace DeveloperEvaluation.Services.ItemSummaries
{
    public class SubItemSummarizer
	{
        /// <summary>
        /// Gets a sub-item summary for a given item number.
        /// </summary>
        /// <param name="itemNumber">The item number of the item to get the sub-item summary of.</param>
        public SubItemSummary[] GetSubItemSummary(string itemNumber)
        {
            return GetSubItems(itemNumber)
                ?.SelectMany(item => TransformSubItems(item, item.GetSubItems()))
                ?.ToArray()
                ?? new SubItemSummary[0];
        }

        private IEnumerable<Item> GetSubItems(string itemNumber)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<SubItemSummary> TransformSubItems(Item item, object p)
        {
            throw new NotImplementedException();
        }
    }
}
