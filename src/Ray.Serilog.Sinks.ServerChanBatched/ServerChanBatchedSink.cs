﻿using System;
using System.Threading.Tasks;
using Ray.Serilog.Sinks.Batched;
using Serilog.Events;

namespace Ray.Serilog.Sinks.ServerChanBatched
{
    public class ServerChanBatchedSink : BatchedSink
    {
        private readonly string _scKey;

        public ServerChanBatchedSink(
            string scKey,
            Predicate<LogEvent> predicate,
            bool sendBatchesAsOneMessages,
            IFormatProvider formatProvider,
            LogEventLevel minimumLogEventLevel
            ) : base(predicate, sendBatchesAsOneMessages, formatProvider, minimumLogEventLevel)
        {
            _scKey = scKey;
        }

        protected override IPushService PushService => new ServerChanApiClient(_scKey);

        public override void Dispose()
        {
            //todo
        }
    }
}
