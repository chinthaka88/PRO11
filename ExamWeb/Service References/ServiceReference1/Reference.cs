﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExamWeb.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IExamService")]
    public interface IExamService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExamService/GetExams", ReplyAction="http://tempuri.org/IExamService/GetExamsResponse")]
        DTO.ExaminationDTO[] GetExams();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExamService/GetExams", ReplyAction="http://tempuri.org/IExamService/GetExamsResponse")]
        System.Threading.Tasks.Task<DTO.ExaminationDTO[]> GetExamsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IExamServiceChannel : ExamWeb.ServiceReference1.IExamService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ExamServiceClient : System.ServiceModel.ClientBase<ExamWeb.ServiceReference1.IExamService>, ExamWeb.ServiceReference1.IExamService {
        
        public ExamServiceClient() {
        }
        
        public ExamServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ExamServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ExamServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ExamServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public DTO.ExaminationDTO[] GetExams() {
            return base.Channel.GetExams();
        }
        
        public System.Threading.Tasks.Task<DTO.ExaminationDTO[]> GetExamsAsync() {
            return base.Channel.GetExamsAsync();
        }
    }
}
