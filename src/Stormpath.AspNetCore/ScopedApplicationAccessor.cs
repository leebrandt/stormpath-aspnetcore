﻿// <copyright file="ScopedApplicationAccessor.cs" company="Stormpath, Inc.">
// Copyright (c) 2016 Stormpath, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

using Microsoft.AspNetCore.Http;
using Stormpath.SDK.Application;
using Stormpath.SDK.Sync;

namespace Stormpath.AspNetCore
{
    internal sealed class ScopedApplicationAccessor
    {
        public ScopedApplicationAccessor(IHttpContextAccessor httpContextAccessor)
        {
            var clientAccessor = new ScopedClientAccessor(httpContextAccessor);
            var client = clientAccessor.Item;

            if (client == null)
            {
                return;
            }

            var configurationAccessor = new ScopedConfigurationAccessor(httpContextAccessor);
            var config = configurationAccessor.Item;

            if (config == null)
            {
                return;
            }

            Item = client.GetApplication(config.Application.Href);
        }

        public IApplication Item { get; }
    }
}
