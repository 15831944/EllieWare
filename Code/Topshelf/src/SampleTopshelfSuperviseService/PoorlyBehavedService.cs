﻿// Copyright 2007-2012 Chris Patterson, Dru Sellers, Travis Smith, et. al.
//  
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace SampleTopshelfSuperviseService
{
    using System;
    using System.Threading;
    using Topshelf;
    using Topshelf.Logging;

    public class PoorlyBehavedService :
        ServiceControl
    {
        readonly LogWriter _log = HostLogger.Get<PoorlyBehavedService>();

        public bool Start(HostControl hostControl)
        {
            Console.WriteLine("I exhibit bad behavior, but I started on command.");

            ThreadPool.QueueUserWorkItem(x =>
            {
                Thread.Sleep(5000);

                _log.Info("Stopping for no particular reason");

                hostControl.Stop();

                //                _log.Info("Dying an ungraceful death");
                //
                //                throw new InvalidOperationException("Oh, what a world.");
            });

            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            Console.WriteLine("I'm not bad, I'm just coded that way. So I'm stopped.");

            return true;
        }
    }
}