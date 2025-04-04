﻿// Copyright © 2021-Present Neuroglia SRL. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License"),
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Neuroglia.AsyncApi.FluentBuilders.v3;

/// <summary>
/// Defines the fundamentals of a service used to build <see cref="V3MessageTraitDefinition"/>s
/// </summary>
/// <typeparam name="TBuilder">The type of <see cref="IV3MessageTraitDefinitionBuilder{TBuilder, TTrait}"/> to return for chaining purposes</typeparam>
/// <typeparam name="TTrait">The type of <see cref="V3MessageTraitDefinition"/> to build</typeparam>
public interface IV3MessageTraitDefinitionBuilder<TBuilder, TTrait>
    : IReferenceableComponentDefinitionBuilder<TTrait>
    where TBuilder : IV3MessageTraitDefinitionBuilder<TBuilder, TTrait>
    where TTrait : V3MessageTraitDefinition
{

    /// <summary>
    /// Configures the <see cref="V3MessageTraitDefinition"/> to use the specified headers schema
    /// </summary>
    /// <param name="setup">An <see cref="Action{T}"/> used to setup the <see cref="V3SchemaDefinition"/> to use</param>
    /// <returns>The configured <see cref="IV3MessageTraitDefinitionBuilder{TBuilder, TTrait}"/></returns>
    TBuilder WithHeadersSchema(Action<IV3SchemaDefinitionBuilder> setup);

    /// <summary>
    /// Configures the <see cref="V3MessageTraitDefinition"/> to use the specified correlation id
    /// </summary>
    /// <param name="setup">An <see cref="Action{T}"/> used to configure the  correlation id to use</param>
    /// <returns>The configured <see cref="IV3MessageTraitDefinitionBuilder{TBuilder, TTrait}"/></returns>
    TBuilder WithCorrelationId(Action<IV3CorrelationIdDefinitionBuilder> setup);

    /// <summary>
    /// Configures the <see cref="V3MessageTraitDefinition"/> to build to use the specified content type
    /// </summary>
    /// <param name="contentType">The content type to use</param>
    /// <returns>The configured <see cref="IV3MessageTraitDefinitionBuilder{TBuilder, TTrait}"/></returns>
    TBuilder WithContentType(string? contentType);

    /// <summary>
    /// Configures the <see cref="V3MessageTraitDefinition"/> to build to use the specified content type
    /// </summary>
    /// <param name="name">The name to use</param>
    /// <returns>The configured <see cref="IV3MessageTraitDefinitionBuilder{TBuilder, TTrait}"/></returns>
    TBuilder WithName(string? name);

    /// <summary>
    /// Configures the <see cref="V3MessageTraitDefinition"/> to build to use the specified title
    /// </summary>
    /// <param name="title">The title to use</param>
    /// <returns>The configured <see cref="IV3MessageTraitDefinitionBuilder{TBuilder, TTrait}"/></returns>
    TBuilder WithTitle(string? title);

    /// <summary>
    /// Configures the <see cref="V3MessageTraitDefinition"/> to build to use the specified summary
    /// </summary>
    /// <param name="summary">The summary to use</param>
    /// <returns>The configured <see cref="IV3MessageTraitDefinitionBuilder{TBuilder, TTrait}"/></returns>
    TBuilder WithSummary(string? summary);

    /// <summary>
    /// Configures the <see cref="V3MessageTraitDefinition"/> to build to use the specified description
    /// </summary>
    /// <param name="description">The description to use</param>
    /// <returns>The configured <see cref="IV3MessageTraitDefinitionBuilder{TBuilder, TTrait}"/></returns>
    TBuilder WithDescription(string? description);

    /// <summary>
    /// Marks the <see cref="V3MessageTraitDefinition"/> to build with the specified tag
    /// </summary>
    /// <param name="setup">An <see cref="Action{T}"/> used to setup the tag to use</param>
    /// <returns>The configured <see cref="IV3MessageTraitDefinitionBuilder{TBuilder, TTrait}"/></returns>
    TBuilder WithTag(Action<IV3TagDefinitionBuilder> setup);

    /// <summary>
    /// Adds the specified external documentation to the <see cref="V3MessageTraitDefinition"/> to build
    /// </summary>
    /// <param name="setup">An <see cref="Action{T}"/> used to setup the <see cref="V3ExternalDocumentationDefinition"/> to use</param>
    /// <returns>The configured <see cref="IV3MessageTraitDefinitionBuilder{TBuilder, TTrait}"/></returns>
    TBuilder WithExternalDocumentation(Action<IV3ExternalDocumentationDefinitionBuilder> setup);

    /// <summary>
    /// Adds the specified <see cref="IMessageBindingDefinition"/> to the <see cref="V3MessageTraitDefinition"/> to build
    /// </summary>
    /// <param name="binding">The <see cref="IMessageBindingDefinition"/> to add</param>
    /// <returns>The configured <see cref="IV3MessageTraitDefinitionBuilder{TBuilder, TTrait}"/></returns>
    TBuilder WithBinding(IMessageBindingDefinition binding);

    /// <summary>
    /// Configures the <see cref="V3MessageTraitDefinition"/> to use the specified <see cref="MessageBindingDefinitionCollection"/>
    /// </summary>
    /// <param name="setup">An <see cref="Action{T}"/> used to setup the <see cref="MessageBindingDefinitionCollection"/> to use</param>
    /// <returns>The configured <see cref="IV3MessageTraitDefinitionBuilder{TBuilder, TTrait}"/></returns>
    TBuilder WithBindings(Action<IMessageBindingDefinitionCollectionBuilder> setup);

    /// <summary>
    /// Adds the specified example to the <see cref="V3MessageTraitDefinition"/> to build
    /// </summary>
    /// <param name="setup">An <see cref="Action{T}"/> used to setup the example to add</param>
    /// <returns>The configured <see cref="IV3MessageTraitDefinitionBuilder{TBuilder, TTrait}"/></returns>
    TBuilder WithExample(Action<IV3MessageExampleDefinitionBuilder> setup);

    /// <summary>
    /// Builds the configured <see cref="V3MessageTraitDefinition"/>
    /// </summary>
    /// <returns>A new <see cref="V3MessageTraitDefinition"/></returns>
    TTrait Build();

}

/// <summary>
/// Defines the fundamentals of a service used to build <see cref="V3MessageTraitDefinition"/>s
/// </summary>
public interface IV3MessageTraitDefinitionBuilder
    : IV3MessageTraitDefinitionBuilder<IV3MessageTraitDefinitionBuilder, V3MessageTraitDefinition>
{



}
