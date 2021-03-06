//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace New_Esign.PostmanService {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PostmanService.PostmanServiceSoap")]
    public interface PostmanServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SendHaloMgs", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string SendHaloMgs(string _SystemName, string _DocNO, string _SignEmpNo, string _CallBackUrl, string _HaloMgs, string _JsonShowData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SendHaloMgs", ReplyAction="*")]
        System.Threading.Tasks.Task<string> SendHaloMgsAsync(string _SystemName, string _DocNO, string _SignEmpNo, string _CallBackUrl, string _HaloMgs, string _JsonShowData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SendHaloMgsWithScreenShot", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string SendHaloMgsWithScreenShot(string _SystemName, string _DocNO, string _SignEmpNo, string _CallBackUrl, bool _AllowForward, string _HaloMgs, string _JsonShowData, string _ScreenShotUrl);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SendHaloMgsWithScreenShot", ReplyAction="*")]
        System.Threading.Tasks.Task<string> SendHaloMgsWithScreenShotAsync(string _SystemName, string _DocNO, string _SignEmpNo, string _CallBackUrl, bool _AllowForward, string _HaloMgs, string _JsonShowData, string _ScreenShotUrl);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SendHaloMgsWithFreeSpace", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string SendHaloMgsWithFreeSpace(string _SystemName, string _DocNO, string _SignEmpNo, string _CallBackUrl, bool _AllowForward, string _HaloMgs, string _JsonShowData, string _ScreenShotUrl, string _FreeSpaceHtml);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SendHaloMgsWithFreeSpace", ReplyAction="*")]
        System.Threading.Tasks.Task<string> SendHaloMgsWithFreeSpaceAsync(string _SystemName, string _DocNO, string _SignEmpNo, string _CallBackUrl, bool _AllowForward, string _HaloMgs, string _JsonShowData, string _ScreenShotUrl, string _FreeSpaceHtml);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SendHaloMgsWithForward", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string SendHaloMgsWithForward(string _SystemName, string _DocNO, string _SignEmpNo, string _CallBackUrl, bool _AllowForward, string _HaloMgs, string _JsonShowData, string _ScreenShotUrl);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SendHaloMgsWithForward", ReplyAction="*")]
        System.Threading.Tasks.Task<string> SendHaloMgsWithForwardAsync(string _SystemName, string _DocNO, string _SignEmpNo, string _CallBackUrl, bool _AllowForward, string _HaloMgs, string _JsonShowData, string _ScreenShotUrl);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UpdateOrder", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UpdateOrder(string _DocNO, string _SignEmpNo, string _HaloMgs);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UpdateOrder", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UpdateOrderAsync(string _DocNO, string _SignEmpNo, string _HaloMgs);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetOrderStatus", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetOrderStatus(string _DocNO);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetOrderStatus", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetOrderStatusAsync(string _DocNO);
        
        // CODEGEN: Parameter '_ApprovalTime' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertSignHistory", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        New_Esign.PostmanService.InsertSignHistoryResponse InsertSignHistory(New_Esign.PostmanService.InsertSignHistoryRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/InsertSignHistory", ReplyAction="*")]
        System.Threading.Tasks.Task<New_Esign.PostmanService.InsertSignHistoryResponse> InsertSignHistoryAsync(New_Esign.PostmanService.InsertSignHistoryRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetEmpName", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetEmpName(string _EmpNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetEmpName", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetEmpNameAsync(string _EmpNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetEmpInfomation", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable GetEmpInfomation(string _EmpNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetEmpInfomation", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetEmpInfomationAsync(string _EmpNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetEmp_Agent", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable GetEmp_Agent(string _EmpNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetEmp_Agent", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetEmp_AgentAsync(string _EmpNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetEmpAgent", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetEmpAgent(string _EmpNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetEmpAgent", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetEmpAgentAsync(string _EmpNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetEmpLevel", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetEmpLevel(string _EmpNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetEmpLevel", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetEmpLevelAsync(string _EmpNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetEmpManagers", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetEmpManagers(string _EmpNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetEmpManagers", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetEmpManagersAsync(string _EmpNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetEmpMail", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetEmpMail(string _EmpNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetEmpMail", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetEmpMailAsync(string _EmpNo);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="InsertSignHistory", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class InsertSignHistoryRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string _OrderNo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string _ApproverId;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public string _ApproverTitle;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=3)]
        public string _ApproverSuggest;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=4)]
        public string _Status;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=5)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> _ApprovalTime;
        
        public InsertSignHistoryRequest() {
        }
        
        public InsertSignHistoryRequest(string _OrderNo, string _ApproverId, string _ApproverTitle, string _ApproverSuggest, string _Status, System.Nullable<System.DateTime> _ApprovalTime) {
            this._OrderNo = _OrderNo;
            this._ApproverId = _ApproverId;
            this._ApproverTitle = _ApproverTitle;
            this._ApproverSuggest = _ApproverSuggest;
            this._Status = _Status;
            this._ApprovalTime = _ApprovalTime;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="InsertSignHistoryResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class InsertSignHistoryResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public bool InsertSignHistoryResult;
        
        public InsertSignHistoryResponse() {
        }
        
        public InsertSignHistoryResponse(bool InsertSignHistoryResult) {
            this.InsertSignHistoryResult = InsertSignHistoryResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface PostmanServiceSoapChannel : New_Esign.PostmanService.PostmanServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PostmanServiceSoapClient : System.ServiceModel.ClientBase<New_Esign.PostmanService.PostmanServiceSoap>, New_Esign.PostmanService.PostmanServiceSoap {
        
        public PostmanServiceSoapClient() {
        }
        
        public PostmanServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PostmanServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PostmanServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PostmanServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string SendHaloMgs(string _SystemName, string _DocNO, string _SignEmpNo, string _CallBackUrl, string _HaloMgs, string _JsonShowData) {
            return base.Channel.SendHaloMgs(_SystemName, _DocNO, _SignEmpNo, _CallBackUrl, _HaloMgs, _JsonShowData);
        }
        
        public System.Threading.Tasks.Task<string> SendHaloMgsAsync(string _SystemName, string _DocNO, string _SignEmpNo, string _CallBackUrl, string _HaloMgs, string _JsonShowData) {
            return base.Channel.SendHaloMgsAsync(_SystemName, _DocNO, _SignEmpNo, _CallBackUrl, _HaloMgs, _JsonShowData);
        }
        
        public string SendHaloMgsWithScreenShot(string _SystemName, string _DocNO, string _SignEmpNo, string _CallBackUrl, bool _AllowForward, string _HaloMgs, string _JsonShowData, string _ScreenShotUrl) {
            return base.Channel.SendHaloMgsWithScreenShot(_SystemName, _DocNO, _SignEmpNo, _CallBackUrl, _AllowForward, _HaloMgs, _JsonShowData, _ScreenShotUrl);
        }
        
        public System.Threading.Tasks.Task<string> SendHaloMgsWithScreenShotAsync(string _SystemName, string _DocNO, string _SignEmpNo, string _CallBackUrl, bool _AllowForward, string _HaloMgs, string _JsonShowData, string _ScreenShotUrl) {
            return base.Channel.SendHaloMgsWithScreenShotAsync(_SystemName, _DocNO, _SignEmpNo, _CallBackUrl, _AllowForward, _HaloMgs, _JsonShowData, _ScreenShotUrl);
        }
        
        public string SendHaloMgsWithFreeSpace(string _SystemName, string _DocNO, string _SignEmpNo, string _CallBackUrl, bool _AllowForward, string _HaloMgs, string _JsonShowData, string _ScreenShotUrl, string _FreeSpaceHtml) {
            return base.Channel.SendHaloMgsWithFreeSpace(_SystemName, _DocNO, _SignEmpNo, _CallBackUrl, _AllowForward, _HaloMgs, _JsonShowData, _ScreenShotUrl, _FreeSpaceHtml);
        }
        
        public System.Threading.Tasks.Task<string> SendHaloMgsWithFreeSpaceAsync(string _SystemName, string _DocNO, string _SignEmpNo, string _CallBackUrl, bool _AllowForward, string _HaloMgs, string _JsonShowData, string _ScreenShotUrl, string _FreeSpaceHtml) {
            return base.Channel.SendHaloMgsWithFreeSpaceAsync(_SystemName, _DocNO, _SignEmpNo, _CallBackUrl, _AllowForward, _HaloMgs, _JsonShowData, _ScreenShotUrl, _FreeSpaceHtml);
        }
        
        public string SendHaloMgsWithForward(string _SystemName, string _DocNO, string _SignEmpNo, string _CallBackUrl, bool _AllowForward, string _HaloMgs, string _JsonShowData, string _ScreenShotUrl) {
            return base.Channel.SendHaloMgsWithForward(_SystemName, _DocNO, _SignEmpNo, _CallBackUrl, _AllowForward, _HaloMgs, _JsonShowData, _ScreenShotUrl);
        }
        
        public System.Threading.Tasks.Task<string> SendHaloMgsWithForwardAsync(string _SystemName, string _DocNO, string _SignEmpNo, string _CallBackUrl, bool _AllowForward, string _HaloMgs, string _JsonShowData, string _ScreenShotUrl) {
            return base.Channel.SendHaloMgsWithForwardAsync(_SystemName, _DocNO, _SignEmpNo, _CallBackUrl, _AllowForward, _HaloMgs, _JsonShowData, _ScreenShotUrl);
        }
        
        public string UpdateOrder(string _DocNO, string _SignEmpNo, string _HaloMgs) {
            return base.Channel.UpdateOrder(_DocNO, _SignEmpNo, _HaloMgs);
        }
        
        public System.Threading.Tasks.Task<string> UpdateOrderAsync(string _DocNO, string _SignEmpNo, string _HaloMgs) {
            return base.Channel.UpdateOrderAsync(_DocNO, _SignEmpNo, _HaloMgs);
        }
        
        public string GetOrderStatus(string _DocNO) {
            return base.Channel.GetOrderStatus(_DocNO);
        }
        
        public System.Threading.Tasks.Task<string> GetOrderStatusAsync(string _DocNO) {
            return base.Channel.GetOrderStatusAsync(_DocNO);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        New_Esign.PostmanService.InsertSignHistoryResponse New_Esign.PostmanService.PostmanServiceSoap.InsertSignHistory(New_Esign.PostmanService.InsertSignHistoryRequest request) {
            return base.Channel.InsertSignHistory(request);
        }
        
        public bool InsertSignHistory(string _OrderNo, string _ApproverId, string _ApproverTitle, string _ApproverSuggest, string _Status, System.Nullable<System.DateTime> _ApprovalTime) {
            New_Esign.PostmanService.InsertSignHistoryRequest inValue = new New_Esign.PostmanService.InsertSignHistoryRequest();
            inValue._OrderNo = _OrderNo;
            inValue._ApproverId = _ApproverId;
            inValue._ApproverTitle = _ApproverTitle;
            inValue._ApproverSuggest = _ApproverSuggest;
            inValue._Status = _Status;
            inValue._ApprovalTime = _ApprovalTime;
            New_Esign.PostmanService.InsertSignHistoryResponse retVal = ((New_Esign.PostmanService.PostmanServiceSoap)(this)).InsertSignHistory(inValue);
            return retVal.InsertSignHistoryResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<New_Esign.PostmanService.InsertSignHistoryResponse> New_Esign.PostmanService.PostmanServiceSoap.InsertSignHistoryAsync(New_Esign.PostmanService.InsertSignHistoryRequest request) {
            return base.Channel.InsertSignHistoryAsync(request);
        }
        
        public System.Threading.Tasks.Task<New_Esign.PostmanService.InsertSignHistoryResponse> InsertSignHistoryAsync(string _OrderNo, string _ApproverId, string _ApproverTitle, string _ApproverSuggest, string _Status, System.Nullable<System.DateTime> _ApprovalTime) {
            New_Esign.PostmanService.InsertSignHistoryRequest inValue = new New_Esign.PostmanService.InsertSignHistoryRequest();
            inValue._OrderNo = _OrderNo;
            inValue._ApproverId = _ApproverId;
            inValue._ApproverTitle = _ApproverTitle;
            inValue._ApproverSuggest = _ApproverSuggest;
            inValue._Status = _Status;
            inValue._ApprovalTime = _ApprovalTime;
            return ((New_Esign.PostmanService.PostmanServiceSoap)(this)).InsertSignHistoryAsync(inValue);
        }
        
        public string GetEmpName(string _EmpNo) {
            return base.Channel.GetEmpName(_EmpNo);
        }
        
        public System.Threading.Tasks.Task<string> GetEmpNameAsync(string _EmpNo) {
            return base.Channel.GetEmpNameAsync(_EmpNo);
        }
        
        public System.Data.DataTable GetEmpInfomation(string _EmpNo) {
            return base.Channel.GetEmpInfomation(_EmpNo);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetEmpInfomationAsync(string _EmpNo) {
            return base.Channel.GetEmpInfomationAsync(_EmpNo);
        }
        
        public System.Data.DataTable GetEmp_Agent(string _EmpNo) {
            return base.Channel.GetEmp_Agent(_EmpNo);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetEmp_AgentAsync(string _EmpNo) {
            return base.Channel.GetEmp_AgentAsync(_EmpNo);
        }
        
        public string GetEmpAgent(string _EmpNo) {
            return base.Channel.GetEmpAgent(_EmpNo);
        }
        
        public System.Threading.Tasks.Task<string> GetEmpAgentAsync(string _EmpNo) {
            return base.Channel.GetEmpAgentAsync(_EmpNo);
        }
        
        public string GetEmpLevel(string _EmpNo) {
            return base.Channel.GetEmpLevel(_EmpNo);
        }
        
        public System.Threading.Tasks.Task<string> GetEmpLevelAsync(string _EmpNo) {
            return base.Channel.GetEmpLevelAsync(_EmpNo);
        }
        
        public string GetEmpManagers(string _EmpNo) {
            return base.Channel.GetEmpManagers(_EmpNo);
        }
        
        public System.Threading.Tasks.Task<string> GetEmpManagersAsync(string _EmpNo) {
            return base.Channel.GetEmpManagersAsync(_EmpNo);
        }
        
        public string GetEmpMail(string _EmpNo) {
            return base.Channel.GetEmpMail(_EmpNo);
        }
        
        public System.Threading.Tasks.Task<string> GetEmpMailAsync(string _EmpNo) {
            return base.Channel.GetEmpMailAsync(_EmpNo);
        }
    }
}
