using System;
using System.Collections.Generic;
using System.Text;

namespace Natro_Backend.Models.Integration.RDAP.Response
{
    public class WhoisResponse
    {
        public Rootobject Rootobject { get; set; }
        public Securedns Securedns { get; set; }
        public Event Event { get; set; }
        public Link Link { get; set; }
        public Nameserver Nameserver { get; set; }
        public Notice Notice { get; set; }
        public Link1 Link1 { get; set; }
        public Entity Entity { get; set; }
        public Publicid Publicid { get; set; }
        public Entity1 Entity1 { get; set; }
        public Remark Remark { get; set; }
    }

    public class Rootobject
    {
        public string objectClassName { get; set; }
        public string handle { get; set; }
        public string ldhName { get; set; }
        public string[] status { get; set; }
        public Event[] events { get; set; }
        public Securedns secureDNS { get; set; }
        public Link[] links { get; set; }
        public Nameserver[] nameservers { get; set; }
        public string[] rdapConformance { get; set; }
        public Notice[] notices { get; set; }
        public Entity[] entities { get; set; }
    }

    public class Securedns
    {
        public bool delegationSigned { get; set; }
    }

    public class Event
    {
        public string eventAction { get; set; }
        public DateTime eventDate { get; set; }
    }

    public class Link
    {
        public string value { get; set; }
        public string rel { get; set; }
        public string href { get; set; }
        public string type { get; set; }
    }

    public class Nameserver
    {
        public string objectClassName { get; set; }
        public string ldhName { get; set; }
    }

    public class Notice
    {
        public string title { get; set; }
        public string[] description { get; set; }
        public Link1[] links { get; set; }
    }

    public class Link1
    {
        public string href { get; set; }
        public string type { get; set; }
    }

    public class Entity
    {
        public string objectClassName { get; set; }
        public string handle { get; set; }
        public string[] roles { get; set; }
        public Publicid[] publicIds { get; set; }
        public object[] vcardArray { get; set; }
        public Entity1[] entities { get; set; }
        public Remark[] remarks { get; set; }
    }

    public class Publicid
    {
        public string type { get; set; }
        public string identifier { get; set; }
    }

    public class Entity1
    {
        public string objectClassName { get; set; }
        public string[] roles { get; set; }
        public object[] vcardArray { get; set; }
    }

    public class Remark
    {
        public string title { get; set; }
        public string type { get; set; }
        public string[] description { get; set; }
    }
}
