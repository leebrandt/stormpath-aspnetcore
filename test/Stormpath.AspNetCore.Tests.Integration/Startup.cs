// <copyright file="Startup.cs" company="Stormpath, Inc.">
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

using System.Net.Http;
using FluentAssertions;
using Microsoft.AspNet.TestHost;
using Xunit;

namespace Stormpath.AspNetCore.Tests.Integration
{
    public class Startup
    {
        [Fact]
        public void Constructing_default_client()
        {
            var client = CreateTestServerWithOptions(options: null);

            client.Should().NotBeNull();
        }

        private static HttpClient CreateTestServerWithOptions(object options)
        {
            var server = new TestServer(TestServer.CreateBuilder()
                .UseServices(services =>
                {
                    services.AddStormpath(options);
                })
                .UseStartup(app =>
                {
                    app.UseStormpath();
                }));

            return server.CreateClient();
        }
    }
}
