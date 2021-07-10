﻿/*
 * Copyright © 2021 Neuroglia SPRL. All rights reserved.
 * <p>
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * <p>
 * http://www.apache.org/licenses/LICENSE-2.0
 * <p>
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Neuroglia.AsyncApi.Sdk.Services.FluentBuilders;
using Neuroglia.AsyncApi.Sdk.Services.IO;
using Neuroglia.AsyncApi.Sdk.Services.Validation;
using Neuroglia.Serialization;
using YamlDotNet.Serialization;

namespace Neuroglia.AsyncApi.Sdk
{

    /// <summary>
    /// Defines extensions for <see cref="IServiceCollection"/>s
    /// </summary>
    public static class IServiceCollectionExtensions
    {

        /// <summary>
        /// Adds and configures Async API services (<see cref="Serialization.ISerializer"/>s, <see cref="IAsyncApiDocumentReader"/>, <see cref="IAsyncApiDocumentWriter"/>, ...)
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to configure</param>
        /// <returns>The configured <see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddAsyncApi(this IServiceCollection services)
        {
            services.AddNewtonsoftJsonSerializer();
            services.AddYamlDotNetSerializer(
                serializer => serializer
                    .IncludeNonPublicProperties()
                    .WithTypeConverter(new JTokenSerializer())
                    .WithTypeConverter(new StringEnumSerializer())
                    .WithEmissionPhaseObjectGraphVisitor(args => new ChainedObjectGraphVisitor(args.InnerVisitor)),
                deserializer => { });
            services.AddHttpClient();
            services.AddSingleton<IAsyncApiDocumentReader, AsyncApiDocumentReader>();
            services.AddSingleton<IAsyncApiDocumentWriter, AsyncApiDocumentWriter>();
            services.AddTransient<IAsyncApiDocumentBuilder, AsyncApiDocumentBuilder>();
            services.AddValidatorsFromAssemblyContaining<AsyncApiDocumentValidator>();
            return services;
        }

    }

}
