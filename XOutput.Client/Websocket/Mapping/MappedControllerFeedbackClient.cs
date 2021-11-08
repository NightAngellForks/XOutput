﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XOutput.Serialization;
using XOutput.Websocket.Emulation;

namespace XOutput.Websocket.Mapping
{
    public class MappedControllerFeedbackClient : WebsocketJsonClient
    {
        public event InputDeviceFeedbackReceived FeedbackReceived;

        public MappedControllerFeedbackClient(MessageReader messageReader, MessageWriter messageWriter, WebSocketHelper webSocketHelper, Uri baseUri) : base(messageReader, messageWriter, webSocketHelper, baseUri)
        {

        }

        public async Task ConnectAsync(string id)
        {
            await base.ConnectAsync("MappedConttroller/" + id);
        }

        protected override void ProcessMessage(MessageBase message)
        {
            if (message is ControllerInputResponse)
            {
                var feedbackMessage = message as ControllerInputResponse;
                FeedbackReceived?.Invoke(this, new InputDeviceFeedbackReceivedEventArgs
                {
                    InputValues = feedbackMessage.Sources.Select(s => new ControllerSourceValue { Id = s.Id, Value = s.Value }).ToList(),
                    ForceFeedbacks = feedbackMessage.Targets.Select(t => new ControllerTargetValue { Id = t.Id, Value = t.Value }).ToList(),
                });
            }
        }
    }

    public delegate void InputDeviceFeedbackReceived(object sender, InputDeviceFeedbackReceivedEventArgs args);

    public class InputDeviceFeedbackReceivedEventArgs
    {
        public List<ControllerSourceValue> InputValues { get; set; }
        public List<ControllerTargetValue> ForceFeedbacks { get; set; }
    }
}
