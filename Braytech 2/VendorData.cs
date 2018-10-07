using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Braytech_2
{
    public class VendorData
    {
        public Response response { get; set; }
    }

    public class Response
    {
        public int status { get; set; }
        public string message { get; set; }
        public Datum[] data { get; set; }
    }

    public class Datum
    {
        public Sale[] sales { get; set; }
        public Vendor vendor { get; set; }
        public Category[] categories { get; set; }
    }

    public class Vendor
    {
        public int vendorHash { get; set; }
        public DateTime nextRefreshDate { get; set; }
        public bool enabled { get; set; }
        public bool canPurchase { get; set; }
        public int vendorLocationIndex { get; set; }
    }

    public class Sale
    {
        public int vendorItemIndex { get; set; }
        public int quantity { get; set; }
        public int saleStatus { get; set; }
        public Cost[] costs { get; set; }
        public int?[] failureIndexes { get; set; }
        public int augments { get; set; }
        public DateTime overrideNextRefreshDate { get; set; }
        public Item item { get; set; }
    }

    public class Item
    {
        public Displayproperties displayProperties { get; set; }
        public Backgroundcolor backgroundColor { get; set; }
        public string itemTypeDisplayName { get; set; }
        public string itemTypeAndTierDisplayName { get; set; }
        public Inventory inventory { get; set; }
        public object[] perks { get; set; }
        public long[] itemCategoryHashes { get; set; }
        public int itemType { get; set; }
        public int itemSubType { get; set; }
        public int classType { get; set; }
        public int defaultDamageType { get; set; }
        public long hash { get; set; }
        public Stats stats { get; set; }
    }

    public class Displayproperties
    {
        public string description { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public bool hasIcon { get; set; }
    }

    public class Backgroundcolor
    {
        public int colorHash { get; set; }
        public int red { get; set; }
        public int green { get; set; }
        public int blue { get; set; }
        public int alpha { get; set; }
    }

    public class Inventory
    {
        public int maxStackSize { get; set; }
        public long bucketTypeHash { get; set; }
        public int recoveryBucketTypeHash { get; set; }
        public long tierTypeHash { get; set; }
        public bool isInstanceItem { get; set; }
        public bool nonTransferrableOriginal { get; set; }
        public string tierTypeName { get; set; }
        public int tierType { get; set; }
        public string expirationTooltip { get; set; }
        public string expiredInActivityMessage { get; set; }
        public string expiredInOrbitMessage { get; set; }
        public bool suppressExpirationWhenObjectivesComplete { get; set; }
        public string stackUniqueLabel { get; set; }
    }

    public class Stats
    {
        public bool disablePrimaryStatDisplay { get; set; }
        public Stats1 stats { get; set; }
        public bool hasDisplayableStats { get; set; }
        public int primaryBaseStatHash { get; set; }
    }

    public class Stats1
    {
    }

    public class Cost
    {
        public int quantity { get; set; }
        public Displayproperties1 displayProperties { get; set; }
        public Backgroundcolor1 backgroundColor { get; set; }
        public string itemTypeDisplayName { get; set; }
        public string itemTypeAndTierDisplayName { get; set; }
        public Inventory1 inventory { get; set; }
        public int[] itemCategoryHashes { get; set; }
        public int itemType { get; set; }
        public int itemSubType { get; set; }
        public int classType { get; set; }
        public int defaultDamageType { get; set; }
        public long hash { get; set; }
    }

    public class Displayproperties1
    {
        public string description { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public bool hasIcon { get; set; }
    }

    public class Backgroundcolor1
    {
        public int colorHash { get; set; }
        public int red { get; set; }
        public int green { get; set; }
        public int blue { get; set; }
        public int alpha { get; set; }
    }

    public class Inventory1
    {
        public string stackUniqueLabel { get; set; }
        public int maxStackSize { get; set; }
        public long bucketTypeHash { get; set; }
        public int recoveryBucketTypeHash { get; set; }
        public long tierTypeHash { get; set; }
        public bool isInstanceItem { get; set; }
        public bool nonTransferrableOriginal { get; set; }
        public string tierTypeName { get; set; }
        public int tierType { get; set; }
        public string expirationTooltip { get; set; }
        public string expiredInActivityMessage { get; set; }
        public string expiredInOrbitMessage { get; set; }
        public bool suppressExpirationWhenObjectivesComplete { get; set; }
    }

    public class Category
    {
        public int displayCategoryIndex { get; set; }
        public int[] itemIndexes { get; set; }
    }

}
