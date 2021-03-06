﻿using System;
using uhttpsharp;
using Laurus.TaskBoss.Core.Interfaces;

namespace Laurus.TaskBoss.Core
{
    public class HttpListener : IHttpListener
    {
        public HttpListener(ILog log, IHandlerFactory handlerFactory)
        {
            _log = log;
            _handlerFactory = handlerFactory;
        }

        void IHttpListener.Listen(int port)
        {
            HttpServer.Instance.Port = port;
            try
            {
                HttpServer.Instance.StartUp(_handlerFactory);
            }
            catch (Exception e)
            {
                _log.Error("Exception starting http server {0}", e.Message);
            }
        }

        private ILog _log;
        private IHandlerFactory _handlerFactory;
    }
}
