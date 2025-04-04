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

namespace Neuroglia.AsyncApi.Validation.v3;

/// <summary>
/// Represents the service used to validate <see cref="V3ReferenceDefinition"/>s
/// </summary>
/// <typeparam name="TComponent">The type of <see cref="ReferenceableComponentDefinition"/> to resolve the <see cref="V3ReferenceDefinition"/> for</typeparam>
public class V3ReferenceValidator<TComponent>
    : AbstractValidator<V3ReferenceDefinition>
    where TComponent : ReferenceableComponentDefinition
{

    /// <inheritdoc/>
    public V3ReferenceValidator(V3AsyncApiDocument? document = null)
    {
        this.Document = document;
        this.RuleFor(r => r.Reference)
            .NotEmpty();
        this.RuleFor(r => r.Reference)
            .Must(ReferenceExistingComponent);
    }

    /// <summary>
    /// Gets the <see cref="V3AsyncApiDocument"/> to validate
    /// </summary>
    protected V3AsyncApiDocument? Document { get; }

    /// <summary>
    /// Determines whether or not the specified reference points to an existing component 
    /// </summary>
    /// <param name="reference">The reference to check</param>
    /// <returns>A boolean indicating whether or not the specified reference points to an existing component </returns>
    protected virtual bool ReferenceExistingComponent(string reference)
    {
        if (this.Document == null) return true;
        if (string.IsNullOrWhiteSpace(reference)) return false;
        var component = this.Document.Dereference(reference);
        return component != null && component is TComponent;
    }

}