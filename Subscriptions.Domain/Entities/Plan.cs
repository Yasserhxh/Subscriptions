using System.Collections.Generic;
using Subscriptions.Domain.Common;

namespace Subscriptions.Domain.Entities
{
    public class Plan
    {
    

        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string DefaultOfferName { get; set; }
        public App App { get; set; }
        public List<Feature> Features { get; set; }
        public List<Offer> Offers { get; set; }
        public Offer DefaultOffer { get; set; }
        public List<Subscription> Subscriptions { get; set; }
    }
}