using System;
using System.Collections.Generic;
using System.Text;

namespace TravelEntities.CustomEntities
{
    public class CombinedModel
    {
        
        public CombinedModel()
        {
            SearchHotels = new SearchHotels();
            DisplayHotels = new List<DisplayHotels>();
        }
        public SearchHotels SearchHotels { get; set; }

        public List<DisplayHotels> DisplayHotels { get; set; }
    }
}
