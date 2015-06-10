﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TMD.Web.LocalEbayIntegrationWS {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://toymarketdata.com/integrations/ebay/v1/", ConfigurationName="LocalEbayIntegrationWS.ITmdEbayIntegrationService")]
    public interface ITmdEbayIntegrationService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://toymarketdata.com/integrations/ebay/v1/ITmdEbayIntegrationService/StartEba" +
            "yLoad", ReplyAction="http://toymarketdata.com/integrations/ebay/v1/ITmdEbayIntegrationService/StartEba" +
            "yLoadResponse")]
        void StartEbayLoad(string username, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://toymarketdata.com/integrations/ebay/v1/ITmdEbayIntegrationService/StartEba" +
            "yLoad", ReplyAction="http://toymarketdata.com/integrations/ebay/v1/ITmdEbayIntegrationService/StartEba" +
            "yLoadResponse")]
        System.Threading.Tasks.Task StartEbayLoadAsync(string username, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITmdEbayIntegrationServiceChannel : TMD.Web.LocalEbayIntegrationWS.ITmdEbayIntegrationService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TmdEbayIntegrationServiceClient : System.ServiceModel.ClientBase<TMD.Web.LocalEbayIntegrationWS.ITmdEbayIntegrationService>, TMD.Web.LocalEbayIntegrationWS.ITmdEbayIntegrationService {
        
        public TmdEbayIntegrationServiceClient() {
        }
        
        public TmdEbayIntegrationServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TmdEbayIntegrationServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TmdEbayIntegrationServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TmdEbayIntegrationServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void StartEbayLoad(string username, string password) {
            base.Channel.StartEbayLoad(username, password);
        }
        
        public System.Threading.Tasks.Task StartEbayLoadAsync(string username, string password) {
            return base.Channel.StartEbayLoadAsync(username, password);
        }
    }
}