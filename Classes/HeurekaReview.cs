using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace app.Classes
{ 
    
  
    public class HeurekaReview
    {
     
        [XmlRoot]
        public class review
        {
            [XmlElement]
            public uint rating_id { get; set; }

            [XmlElement]
            public string source { get; set; }

            [XmlElement]
            public uint unix_timestamp { get; set; }

            [XmlElement]
            public decimal total_rating { get; set; }

            [XmlElement]
            public decimal recommends { get; set; }

            [XmlElement]
            public decimal pickup_time { get; set; }

            [XmlElement]
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool pickup_timeSpecified { get; set; }

            [XmlElement]
            public decimal pickup_quality { get; set; }

            [XmlElement]
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool pickup_qualitySpecified { get; set; }

            [XmlElement]
            public decimal delivery_time { get; set; }

            [XmlElement]
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool delivery_timeSpecified { get; set; }

            [XmlElement]
            public decimal transport_quality { get; set; }

            [XmlElement]
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool transport_qualitySpecified { get; set; }

            [XmlElement]
            public decimal web_usability { get; set; }

            [XmlElement]
            public decimal communication { get; set; }

            [XmlElement]
            public string pros { get; set; }

            [XmlElement]
            public string cons { get; set; }

            [XmlElement]
            public string summary { get; set; }

            [XmlElement]
            public string order_id { get; set; }

            [XmlElement]
            public string reaction { get; set; }
        }
    }


    public class HeurekaStepClass
    {

        public bool Finished { get; set; }
        public string apiKey { get; set; }
    }











    public class HeurekaProductReview
    {

        /// <remarks/>
        [XmlRoot]
        public class product
        {

            [XmlElement]
            public string product_name { get; set; }

            [XmlElement]
            public string url { get; set; }

            [XmlElement]
            public decimal cena { get; set; }

            [XmlElement]
            public decimal price { get; set; }

            [XmlElement]
            public string order_id { get; set; }

            [XmlElement]
            public productReviews reviews { get; set; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class productReviews
        {

            [XmlElement]
            public productReviewsReview review { get; set; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class productReviewsReview
        {

            [XmlElement]
            public uint rating_id { get; set; }

            [XmlElement]
            public uint unix_timestamp { get; set; }

            [XmlElement]
            public decimal rating { get; set; }

            [XmlElement]
            public string pros { get; set; }

            [XmlElement]
            public decimal recommends { get; set; }

            [XmlElement]
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool recommendsSpecified { get; set; }

            [XmlElement]
            public string summary { get; set; }
        }

    }



}
