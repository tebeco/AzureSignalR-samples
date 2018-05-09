// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Microsoft.Azure.SignalR.Samples.ChatRoom
{
    public class Chat : Hub
    {
        public Task BroadcastMessageAsync(string name, string message)
        {
            //This call is not awaited on purpose but Invoking `BroadcastMessageAsync` need to be awaited
            return Clients.All.SendAsync("broadcastMessage", name, message);
        }

        public Task EchoAsync(string name, string message)
        {
            //This call is not awaited on purpose but Invoking `EchoAsync` need to be awaited
            return Clients.Client(Context.ConnectionId).SendAsync("echo", name, message + " (echo from server)");
        }
    }
}
