﻿using Newtonsoft.Json;
using System.Runtime.Serialization;
using WotConverterCore.Extensions;
using WotConverterCore.Models.Common;

namespace WotConverterCore.Models.ThingModel
{
    public partial class Form
    {
        [JsonProperty("modbus:unitID")]
        public GenericStringInt? ModbusUnitId { get; set; }

        [JsonProperty("modbus:quantity")]
        public GenericStringInt? ModbusQuantity { get; set; }

        [JsonProperty("modbus:address")]
        public GenericStringInt? ModbusAddress { get; set; }

        [JsonProperty("modbus:pollingTime")]
        public GenericStringInt? ModbusPollingTime { get; set; }

        [JsonProperty("modbus:function")]
        public ModbusFunction? ModbusFunction { get; set; }

        [JsonProperty("modbus:entity")]
        public ModbusEntity? ModbusEntity { get; set; }

        [JsonProperty("modbus:zeroBasedAddressing")]
        public bool? ModbusZeroBaseaddressing { get; set; }

        //Should Serialize (Avoid empty objects during serialization)
        public bool ShouldSerializeModbusUnitId() => !ModbusUnitId.IsEmpty();
        public bool ShouldSerializeModbusQuantity() => !ModbusQuantity.IsEmpty();
        public bool ShouldSerializeModbusAddress() => !ModbusAddress.IsEmpty();
        public bool ShouldSerializeModbusPollingTime() => !ModbusPollingTime.IsEmpty();

    }


    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum ModbusEntity
    {
        [JsonIgnore]
        Unknown,

        [EnumMember(Value = "HoldingRegister")]
        Holdingregister,

        [EnumMember(Value = "DiscreteInput")]
        DiscreteInput,

        [EnumMember(Value = "InputRegister")]
        InputRegister,

        [EnumMember(Value = "Coil")]
        Coil
    };


    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum ModbusFunction
    {
        [JsonIgnore]
        Unknown,

        [EnumMember(Value = "readCoil")]
        Readcoil,

        [EnumMember(Value = "readDeviceVerification")]
        ReadDeviceVerification,

        [EnumMember(Value = "readDiscreteInput")]
        ReadDiscreteInput,

        [EnumMember(Value = "readHoldingRegisters")]
        ReadHoldingRegisters,

        [EnumMember(Value = "readInputRegisters")]
        ReadInputRegisters,

        [EnumMember(Value = "writeMultipleCoils")]
        WriteMultipleCoils,

        [EnumMember(Value = "writeMultipleHoldingRegisters")]
        WriteMultipleHoldingRegisters,

        [EnumMember(Value = "writeSingleCoil")]
        WriteSingleCoil,

        [EnumMember(Value = "writeSingleHoldingRegister")]
        WriteSingleHoldingRegister
    };

}
