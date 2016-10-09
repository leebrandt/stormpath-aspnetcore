﻿// <copyright file="ScopedClientAccessor.cs" company="Stormpath, Inc.">
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
using Stormpath.Owin.Abstractions;
using Stormpath.SDK.Client;

namespace Stormpath.AspNetCore
{
    internal sealed class ScopedClientAccessor
    {
        private readonly SafeContextAccessor _contextAccessor;

        public ScopedClientAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = new SafeContextAccessor(httpContextAccessor, OwinKeys.StormpathClient);
        }

        public IClient Item => _contextAccessor.Item as IClient;
    }
}
