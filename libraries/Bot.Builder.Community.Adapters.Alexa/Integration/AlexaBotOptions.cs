﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Bot.Builder.Community.Adapters.Alexa.Integration.AspNet.Core;
using Microsoft.Bot.Builder;

namespace Bot.Builder.Community.Adapters.Alexa.Integration
{
    /// <summary>
    /// Contains settings that your ASP.NET application uses to initialize the <see cref="BotAdapter"/>
    /// that it adds to the HTTP request pipeline.
    /// </summary>
    /// <seealso cref="ApplicationBuilderExtensions"/>
    public class AlexaBotOptions
    {
        private readonly List<IMiddleware> _middleware;
        private readonly AlexaBotPaths _paths;

        /// <summary>
        /// Creates a <see cref="AlexaBotOptions"/> object.
        /// </summary>
        public AlexaBotOptions()
        {
            _middleware = new List<IMiddleware>();
            _paths = new AlexaBotPaths();

            AlexaOptions = new AlexaOptions();
        }

        /// <summary>
        /// The middleware collection with which to initialize the adapter.
        /// </summary>
        public IList<IMiddleware> Middleware { get => _middleware; }

        public AlexaBotPaths Paths { get => _paths; }

        public AlexaOptions AlexaOptions { get; set; }
    }
}
