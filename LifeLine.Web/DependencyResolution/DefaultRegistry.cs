// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using LifeLine.Core.Interfaces;

namespace LifeLine.Web.DependencyResolution {
    using Infrastructure.Implementation;
    using Infrastructure.Service;
    using StructureMap;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;

    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            For<IDonationRepository>().Use<DonationRepository>();

            For<IDonationService>().Use<DonationService>()
                .Ctor<IDonationRepository>("donationRepository").Is(c => c.GetInstance<DonationRepository>()); ;

            For<ICampService>().Use<CampService>()
                .Ctor<ICampRepository>("campRepository").Is(c => c.GetInstance<CampRepository>()); ;
        }

        #endregion
    }
}