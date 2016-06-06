﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ActiveLearning.Web.UploadContentService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UploadContentService.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/InstructorUploadContent", ReplyAction="http://tempuri.org/IService/InstructorUploadContentResponse")]
        ActiveLearning.Web.UploadContentService.InstructorUploadContentResponse InstructorUploadContent(ActiveLearning.Web.UploadContentService.InstructorUploadContentRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/InstructorUploadContent", ReplyAction="http://tempuri.org/IService/InstructorUploadContentResponse")]
        System.Threading.Tasks.Task<ActiveLearning.Web.UploadContentService.InstructorUploadContentResponse> InstructorUploadContentAsync(ActiveLearning.Web.UploadContentService.InstructorUploadContentRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/InstructorReviseContent", ReplyAction="http://tempuri.org/IService/InstructorReviseContentResponse")]
        ActiveLearning.Web.UploadContentService.InstructorReviseContentResponse InstructorReviseContent(ActiveLearning.Web.UploadContentService.InstructorReviseContentRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/InstructorReviseContent", ReplyAction="http://tempuri.org/IService/InstructorReviseContentResponse")]
        System.Threading.Tasks.Task<ActiveLearning.Web.UploadContentService.InstructorReviseContentResponse> InstructorReviseContentAsync(ActiveLearning.Web.UploadContentService.InstructorReviseContentRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AdminAcceptContent", ReplyAction="http://tempuri.org/IService/AdminAcceptContentResponse")]
        ActiveLearning.Web.UploadContentService.AdminAcceptContentResponse AdminAcceptContent(ActiveLearning.Web.UploadContentService.AdminAcceptContentRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AdminAcceptContent", ReplyAction="http://tempuri.org/IService/AdminAcceptContentResponse")]
        System.Threading.Tasks.Task<ActiveLearning.Web.UploadContentService.AdminAcceptContentResponse> AdminAcceptContentAsync(ActiveLearning.Web.UploadContentService.AdminAcceptContentRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AdminCommentContent", ReplyAction="http://tempuri.org/IService/AdminCommentContentResponse")]
        ActiveLearning.Web.UploadContentService.AdminCommentContentResponse AdminCommentContent(ActiveLearning.Web.UploadContentService.AdminCommentContentRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/AdminCommentContent", ReplyAction="http://tempuri.org/IService/AdminCommentContentResponse")]
        System.Threading.Tasks.Task<ActiveLearning.Web.UploadContentService.AdminCommentContentResponse> AdminCommentContentAsync(ActiveLearning.Web.UploadContentService.AdminCommentContentRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="InstructorUploadContent", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class InstructorUploadContentRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public int InstructorSid;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public int CourseSid;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string FileName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public byte[] FileBytes;
        
        public InstructorUploadContentRequest() {
        }
        
        public InstructorUploadContentRequest(int InstructorSid, int CourseSid, string FileName, byte[] FileBytes) {
            this.InstructorSid = InstructorSid;
            this.CourseSid = CourseSid;
            this.FileName = FileName;
            this.FileBytes = FileBytes;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="InstructorUploadContentResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class InstructorUploadContentResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string Message;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public int ContentSid;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public bool ContentUploadedSuccessfully;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public string ContentStatus;
        
        public InstructorUploadContentResponse() {
        }
        
        public InstructorUploadContentResponse(string Message, int ContentSid, bool ContentUploadedSuccessfully, string ContentStatus) {
            this.Message = Message;
            this.ContentSid = ContentSid;
            this.ContentUploadedSuccessfully = ContentUploadedSuccessfully;
            this.ContentStatus = ContentStatus;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="InstructorReviseContent", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class InstructorReviseContentRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public int CourseSid;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public int InstructorSid;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public byte[] FileBytes;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public string FileName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=4)]
        public int ContentSid;
        
        public InstructorReviseContentRequest() {
        }
        
        public InstructorReviseContentRequest(int CourseSid, int InstructorSid, byte[] FileBytes, string FileName, int ContentSid) {
            this.CourseSid = CourseSid;
            this.InstructorSid = InstructorSid;
            this.FileBytes = FileBytes;
            this.FileName = FileName;
            this.ContentSid = ContentSid;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="InstructorReviseContentResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class InstructorReviseContentResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public bool RevisedSuccessfully;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string Message;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string ContentStatus;
        
        public InstructorReviseContentResponse() {
        }
        
        public InstructorReviseContentResponse(bool RevisedSuccessfully, string Message, string ContentStatus) {
            this.RevisedSuccessfully = RevisedSuccessfully;
            this.Message = Message;
            this.ContentStatus = ContentStatus;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AdminAcceptContent", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class AdminAcceptContentRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public int ContentSid;
        
        public AdminAcceptContentRequest() {
        }
        
        public AdminAcceptContentRequest(int ContentSid) {
            this.ContentSid = ContentSid;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AdminAcceptContentResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class AdminAcceptContentResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public bool AcceptedSuccessfully;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string Message;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string ContentStatus;
        
        public AdminAcceptContentResponse() {
        }
        
        public AdminAcceptContentResponse(bool AcceptedSuccessfully, string Message, string ContentStatus) {
            this.AcceptedSuccessfully = AcceptedSuccessfully;
            this.Message = Message;
            this.ContentStatus = ContentStatus;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AdminCommentContent", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class AdminCommentContentRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public int ContentSid;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string Remark;
        
        public AdminCommentContentRequest() {
        }
        
        public AdminCommentContentRequest(int ContentSid, string Remark) {
            this.ContentSid = ContentSid;
            this.Remark = Remark;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AdminCommentContentResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class AdminCommentContentResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public bool CommentedSuccessfully;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string Message;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string ContentStatus;
        
        public AdminCommentContentResponse() {
        }
        
        public AdminCommentContentResponse(bool CommentedSuccessfully, string Message, string ContentStatus) {
            this.CommentedSuccessfully = CommentedSuccessfully;
            this.Message = Message;
            this.ContentStatus = ContentStatus;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : ActiveLearning.Web.UploadContentService.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<ActiveLearning.Web.UploadContentService.IService>, ActiveLearning.Web.UploadContentService.IService {
        
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
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ActiveLearning.Web.UploadContentService.InstructorUploadContentResponse ActiveLearning.Web.UploadContentService.IService.InstructorUploadContent(ActiveLearning.Web.UploadContentService.InstructorUploadContentRequest request) {
            return base.Channel.InstructorUploadContent(request);
        }
        
        public string InstructorUploadContent(int InstructorSid, int CourseSid, string FileName, byte[] FileBytes, out int ContentSid, out bool ContentUploadedSuccessfully, out string ContentStatus) {
            ActiveLearning.Web.UploadContentService.InstructorUploadContentRequest inValue = new ActiveLearning.Web.UploadContentService.InstructorUploadContentRequest();
            inValue.InstructorSid = InstructorSid;
            inValue.CourseSid = CourseSid;
            inValue.FileName = FileName;
            inValue.FileBytes = FileBytes;
            ActiveLearning.Web.UploadContentService.InstructorUploadContentResponse retVal = ((ActiveLearning.Web.UploadContentService.IService)(this)).InstructorUploadContent(inValue);
            ContentSid = retVal.ContentSid;
            ContentUploadedSuccessfully = retVal.ContentUploadedSuccessfully;
            ContentStatus = retVal.ContentStatus;
            return retVal.Message;
        }
        
        public System.Threading.Tasks.Task<ActiveLearning.Web.UploadContentService.InstructorUploadContentResponse> InstructorUploadContentAsync(ActiveLearning.Web.UploadContentService.InstructorUploadContentRequest request) {
            return base.Channel.InstructorUploadContentAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ActiveLearning.Web.UploadContentService.InstructorReviseContentResponse ActiveLearning.Web.UploadContentService.IService.InstructorReviseContent(ActiveLearning.Web.UploadContentService.InstructorReviseContentRequest request) {
            return base.Channel.InstructorReviseContent(request);
        }
        
        public bool InstructorReviseContent(int CourseSid, int InstructorSid, byte[] FileBytes, string FileName, int ContentSid, out string Message, out string ContentStatus) {
            ActiveLearning.Web.UploadContentService.InstructorReviseContentRequest inValue = new ActiveLearning.Web.UploadContentService.InstructorReviseContentRequest();
            inValue.CourseSid = CourseSid;
            inValue.InstructorSid = InstructorSid;
            inValue.FileBytes = FileBytes;
            inValue.FileName = FileName;
            inValue.ContentSid = ContentSid;
            ActiveLearning.Web.UploadContentService.InstructorReviseContentResponse retVal = ((ActiveLearning.Web.UploadContentService.IService)(this)).InstructorReviseContent(inValue);
            Message = retVal.Message;
            ContentStatus = retVal.ContentStatus;
            return retVal.RevisedSuccessfully;
        }
        
        public System.Threading.Tasks.Task<ActiveLearning.Web.UploadContentService.InstructorReviseContentResponse> InstructorReviseContentAsync(ActiveLearning.Web.UploadContentService.InstructorReviseContentRequest request) {
            return base.Channel.InstructorReviseContentAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ActiveLearning.Web.UploadContentService.AdminAcceptContentResponse ActiveLearning.Web.UploadContentService.IService.AdminAcceptContent(ActiveLearning.Web.UploadContentService.AdminAcceptContentRequest request) {
            return base.Channel.AdminAcceptContent(request);
        }
        
        public bool AdminAcceptContent(int ContentSid, out string Message, out string ContentStatus) {
            ActiveLearning.Web.UploadContentService.AdminAcceptContentRequest inValue = new ActiveLearning.Web.UploadContentService.AdminAcceptContentRequest();
            inValue.ContentSid = ContentSid;
            ActiveLearning.Web.UploadContentService.AdminAcceptContentResponse retVal = ((ActiveLearning.Web.UploadContentService.IService)(this)).AdminAcceptContent(inValue);
            Message = retVal.Message;
            ContentStatus = retVal.ContentStatus;
            return retVal.AcceptedSuccessfully;
        }
        
        public System.Threading.Tasks.Task<ActiveLearning.Web.UploadContentService.AdminAcceptContentResponse> AdminAcceptContentAsync(ActiveLearning.Web.UploadContentService.AdminAcceptContentRequest request) {
            return base.Channel.AdminAcceptContentAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ActiveLearning.Web.UploadContentService.AdminCommentContentResponse ActiveLearning.Web.UploadContentService.IService.AdminCommentContent(ActiveLearning.Web.UploadContentService.AdminCommentContentRequest request) {
            return base.Channel.AdminCommentContent(request);
        }
        
        public bool AdminCommentContent(int ContentSid, string Remark, out string Message, out string ContentStatus) {
            ActiveLearning.Web.UploadContentService.AdminCommentContentRequest inValue = new ActiveLearning.Web.UploadContentService.AdminCommentContentRequest();
            inValue.ContentSid = ContentSid;
            inValue.Remark = Remark;
            ActiveLearning.Web.UploadContentService.AdminCommentContentResponse retVal = ((ActiveLearning.Web.UploadContentService.IService)(this)).AdminCommentContent(inValue);
            Message = retVal.Message;
            ContentStatus = retVal.ContentStatus;
            return retVal.CommentedSuccessfully;
        }
        
        public System.Threading.Tasks.Task<ActiveLearning.Web.UploadContentService.AdminCommentContentResponse> AdminCommentContentAsync(ActiveLearning.Web.UploadContentService.AdminCommentContentRequest request) {
            return base.Channel.AdminCommentContentAsync(request);
        }
    }
}