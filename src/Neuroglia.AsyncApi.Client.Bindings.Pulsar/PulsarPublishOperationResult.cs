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

using DotPulsar;

namespace Neuroglia.AsyncApi.Client.Bindings.Pulsar;

/// <summary>
/// Represents an object used to describe the result of a Pulsar publish operation
/// </summary>
/// <param name="messageId">The id of the produced message</param>
public class PulsarPublishOperationResult(MessageId? messageId = null)
    : AsyncApiPublishOperationResult
{

    /// <summary>
    /// Gets the id of the produced message
    /// </summary>
    public virtual MessageId? MessageId { get; } = messageId;

    /// <summary>
    /// Gets/sets the <see cref="System.Exception"/>, if any, that occurred during publishing
    /// </summary>
    public virtual Exception? Exception { get; init; }

    /// <inheritdoc/>
    public override bool IsSuccessful => Exception == null;

}
