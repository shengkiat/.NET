﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ActiveLearning.FormClient.TestUploadService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TestUploadService.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Upload", ReplyAction="http://tempuri.org/IService/UploadResponse")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="Message")]
        string Upload(byte[] Bytes, string FileName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Upload", ReplyAction="http://tempuri.org/IService/UploadResponse")]
        [return: System.ServiceModel.MessageParameterAttribute(Name="Message")]
        System.Threading.Tasks.Task<string> UploadAsync(byte[] Bytes, string FileName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : ActiveLearning.FormClient.TestUploadService.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<ActiveLearning.FormClient.TestUploadService.IService>, ActiveLearning.FormClient.TestUploadService.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Upload(byte[] Bytes, string FileName) {
            return base.Channel.Upload(Bytes, FileName);
        }
        
        public System.Threading.Tasks.Task<string> UploadAsync(byte[] Bytes, string FileName) {
            return base.Channel.UploadAsync(Bytes, FileName);
        }
    }
}
