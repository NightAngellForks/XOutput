﻿using System;
using System.Collections.Generic;
using XOutput.Message.Mappable;
using XOutput.Websocket.Xbox;
using XOutput.Websocket.Common;
using XOutput.Websocket.Ds4;
using XOutput.Serialization;

namespace XOutput.Client
{
    public static class ClientConfiguration
    {
        public static MessageReader MessageReader()
        {
            Dictionary<string, Type> deserializationMapping = new Dictionary<string, Type>
            {
                { DebugRequest.MessageType,  typeof(DebugRequest) },
                { XboxFeedbackResponse.MessageType,  typeof(XboxFeedbackResponse) },
                { Ds4FeedbackResponse.MessageType,  typeof(Ds4FeedbackResponse) },
                { MappableDeviceDetailsRequest.MessageType,  typeof(MappableDeviceDetailsRequest) },
                { MappableDeviceInputRequest.MessageType,  typeof(MappableDeviceInputRequest) },
            };
            return new MessageReader(deserializationMapping);
        }

        public static MessageWriter MessageWriter()
        {
            return new MessageWriter();
        }
    }
}
