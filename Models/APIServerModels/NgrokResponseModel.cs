﻿using System;
using System.Collections.Generic;

namespace Models.APIServerModels
{
    public class NgrokResponseModel
    {
        public class Endpoint
        {
            public string id { get; set; }
            public string uri { get; set; }
        }

        public class Root
        {
            public List<Tunnel> tunnels { get; set; }
            public string uri { get; set; }
            public object next_page_uri { get; set; }
        }

        public class Tunnel
        {
            public string id { get; set; }
            public string public_url { get; set; }
            public DateTime started_at { get; set; }
            public string proto { get; set; }
            public string region { get; set; }
            public TunnelSession tunnel_session { get; set; }
            public Endpoint endpoint { get; set; }
            public string forwards_to { get; set; }
        }

        public class TunnelSession
        {
            public string id { get; set; }
            public string uri { get; set; }
        }
    }
}
