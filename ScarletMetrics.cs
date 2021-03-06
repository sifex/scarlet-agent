﻿using System;
using System.Net;
using System.Collections.Specialized;
using System.Windows.Forms;
using WebSocketSharp;
using MinimalJson;

namespace Scarlet
{
    public class ScarletMetrics
    {
        private string MetricsWSURL = "scarlet.australianarmedforces.org";
        private string MetricsWSPort = "9090";
        private WebSocket metricsws;

        /* WS */
        public ScarletMetrics()
        {
            metricsws = new WebSocket("ws://" + MetricsWSURL + ":" + MetricsWSPort);

            metricsws.Connect();

            metricsws.OnOpen += (sender, e) =>
            {
                // Metrics - On Connection to the Metrics WS Reporting Server
                // Need to include username / IP in here as well.
                metricsws.Send("connected");
            };

        }

        public void Send(string message)
        {
            JsonObject jsonMessage = new JsonObject();
            jsonMessage.add("type", "metrics").add("message", message);
            metricsws.Send(jsonMessage.ToString());
        }
    }
}
