using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guild_online
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Api
    {
        public string commit { get; set; }
        public string release { get; set; }
        public int version { get; set; }
    }

    public class Guild
    {
        public bool active { get; set; }
        public string description { get; set; }
        public string disband_condition { get; set; }
        public string disband_date { get; set; }
        public string founded { get; set; }
        public List<Guildhall> guildhalls { get; set; }
        public string homepage { get; set; }
        public bool in_war { get; set; }
        public List<Invite> invites { get; set; }
        public string logo_url { get; set; }
        public List<Member> members { get; set; }
        public int members_invited { get; set; }
        public int members_total { get; set; }
        public string name { get; set; }
        public bool open_applications { get; set; }
        public int players_offline { get; set; }
        public int players_online { get; set; }
        public string world { get; set; }
    }

    public class Guildhall
    {
        public string name { get; set; }
        public string paid_until { get; set; }
        public string world { get; set; }
    }

    public class Information
    {
        public Api api { get; set; }
        public Status status { get; set; }
        public string timestamp { get; set; }
    }

    public class Invite
    {
        public string date { get; set; }
        public string name { get; set; }
    }

    public class Member
    {
        public string joined { get; set; }
        public int level { get; set; }
        public string name { get; set; }
        public string rank { get; set; }
        public string status { get; set; }
        public string title { get; set; }
        public string vocation { get; set; }
    }

    public class TibiaData
    {
        public Guild Guild { get; set; }
        public Information information { get; set; }
    }

    public class Status
    {
        public int error { get; set; }
        public int http_code { get; set; }
        public string message { get; set; }
    }


}
