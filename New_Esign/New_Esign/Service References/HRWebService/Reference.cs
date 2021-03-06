//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace New_Esign.HRWebService {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="HRWebService.ElistQuerySoap")]
    public interface ElistQuerySoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_ChangeData", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ByUserID_ChangeData(string EmployeeID, string DepartmentID, string ChangeDate, string CompanyCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_ChangeData", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_ChangeDataAsync(string EmployeeID, string DepartmentID, string ChangeDate, string CompanyCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_ExtData", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ByUserID_ExtData(string EmployeeID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_ExtData", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_ExtDataAsync(string EmployeeID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ByUserID(string EmployeeID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ByUserIDAsync(string EmployeeID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UsersSearch", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet UsersSearch(string Key);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UsersSearch", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> UsersSearchAsync(string Key);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserName", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ByUserName(string UserName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserName", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ByUserNameAsync(string UserName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByAgent", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ByAgent(string Agent_OU, string Agent_ID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByAgent", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ByAgentAsync(string Agent_OU, string Agent_ID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByAgent4Site", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ByAgent4Site(string Agent_OU, string Agent_ID, string Site);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByAgent4Site", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ByAgent4SiteAsync(string Agent_OU, string Agent_ID, string Site);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ExploreEmployee", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ExploreEmployee(string CompanyCode, string OU_CODE, int Level);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ExploreEmployee", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ExploreEmployeeAsync(string CompanyCode, string OU_CODE, int Level);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByDepartment", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ByDepartment(string DepartID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByDepartment", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ByDepartmentAsync(string DepartID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByNotesID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ByNotesID(string NotesID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByNotesID", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ByNotesIDAsync(string NotesID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_Govern", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ByUserID_Govern(string EmployeeID, string CompanyCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_Govern", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_GovernAsync(string EmployeeID, string CompanyCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_Inferior", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ByUserID_Inferior(string EmployeeID, string CompanyCode, string OU_CODE);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_Inferior", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_InferiorAsync(string EmployeeID, string CompanyCode, string OU_CODE);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_Manager", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ByUserID_Manager(string EmployeeID, string Level, string Trace);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_Manager", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_ManagerAsync(string EmployeeID, string Level, string Trace);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByOUCode_Assistant", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ByOUCode_Assistant(string CompanyCode, string OUCode, string Level);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByOUCode_Assistant", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ByOUCode_AssistantAsync(string CompanyCode, string OUCode, string Level);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByOUCode_Manager", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ByOUCode_Manager(string CompanyCode, string OUCode, string Level);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByOUCode_Manager", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ByOUCode_ManagerAsync(string CompanyCode, string OUCode, string Level);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByAssistantID_OU", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ByAssistantID_OU(string AssistantID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByAssistantID_OU", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ByAssistantID_OUAsync(string AssistantID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByManagerID_OU", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ByManagerID_OU(string ManagerID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByManagerID_OU", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ByManagerID_OUAsync(string ManagerID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_FindSuperManager_byAbnormal", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ByUserID_FindSuperManager_byAbnormal(string UserID, string SystemName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_FindSuperManager_byAbnormal", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_FindSuperManager_byAbnormalAsync(string UserID, string SystemName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_FindAgentSite", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool ByUserID_FindAgentSite(string UserID, string Site);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_FindAgentSite", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> ByUserID_FindAgentSiteAsync(string UserID, string Site);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_FindWorkflowAgent", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ByUserID_FindWorkflowAgent(string UserID, string FindDepartment, string Site);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_FindWorkflowAgent", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_FindWorkflowAgentAsync(string UserID, string FindDepartment, string Site);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_FindAgent", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ByUserID_FindAgent(string UserID, string FindDepartment);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_FindAgent", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_FindAgentAsync(string UserID, string FindDepartment);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_Agent", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ByUserID_Agent(string UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_Agent", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_AgentAsync(string UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_DirectInferior", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ByUserID_DirectInferior(string EmployeeID, string CompanyCode, string OU_CODE);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_DirectInferior", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_DirectInferiorAsync(string EmployeeID, string CompanyCode, string OU_CODE);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_Abnormal_Manager", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ByUserID_Abnormal_Manager(string EmployeeID, string Level, string JobTitle, string UpStep);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_Abnormal_Manager", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_Abnormal_ManagerAsync(string EmployeeID, string Level, string JobTitle, string UpStep);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_Abnormal_Manager_New", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ByUserID_Abnormal_Manager_New(string EmployeeID, string Level, string JobTitle, string UpStep, string JobStep);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_Abnormal_Manager_New", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_Abnormal_Manager_NewAsync(string EmployeeID, string Level, string JobTitle, string UpStep, string JobStep);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_SiteManager", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ByUserID_SiteManager(string EmployeeID, string Level, string Trace);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_SiteManager", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_SiteManagerAsync(string EmployeeID, string Level, string Trace);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_Site_Manager", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ByUserID_Site_Manager(string EmployeeID, string Level, string JobTitle, string UpStep);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_Site_Manager", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_Site_ManagerAsync(string EmployeeID, string Level, string JobTitle, string UpStep);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_Site_Manager_New", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ByUserID_Site_Manager_New(string EmployeeID, string Level, string JobTitle, string UpStep, string JobStep);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_Site_Manager_New", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_Site_Manager_NewAsync(string EmployeeID, string Level, string JobTitle, string UpStep, string JobStep);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_SiteGovern", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ByUserID_SiteGovern(string EmployeeID, string CompanyCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_SiteGovern", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_SiteGovernAsync(string EmployeeID, string CompanyCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_SiteInferior", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ByUserID_SiteInferior(string EmployeeID, string CompanyCode, string OU_CODE);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_SiteInferior", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_SiteInferiorAsync(string EmployeeID, string CompanyCode, string OU_CODE);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_SiteDirectInferior", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ByUserID_SiteDirectInferior(string EmployeeID, string CompanyCode, string OU_CODE);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_SiteDirectInferior", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_SiteDirectInferiorAsync(string EmployeeID, string CompanyCode, string OU_CODE);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_FindSuperManager_bySite", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet ByUserID_FindSuperManager_bySite(string UserID, string SystemName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ByUserID_FindSuperManager_bySite", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_FindSuperManager_bySiteAsync(string UserID, string SystemName);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ElistQuerySoapChannel : New_Esign.HRWebService.ElistQuerySoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ElistQuerySoapClient : System.ServiceModel.ClientBase<New_Esign.HRWebService.ElistQuerySoap>, New_Esign.HRWebService.ElistQuerySoap {
        
        public ElistQuerySoapClient() {
        }
        
        public ElistQuerySoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ElistQuerySoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ElistQuerySoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ElistQuerySoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet ByUserID_ChangeData(string EmployeeID, string DepartmentID, string ChangeDate, string CompanyCode) {
            return base.Channel.ByUserID_ChangeData(EmployeeID, DepartmentID, ChangeDate, CompanyCode);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_ChangeDataAsync(string EmployeeID, string DepartmentID, string ChangeDate, string CompanyCode) {
            return base.Channel.ByUserID_ChangeDataAsync(EmployeeID, DepartmentID, ChangeDate, CompanyCode);
        }
        
        public System.Data.DataSet ByUserID_ExtData(string EmployeeID) {
            return base.Channel.ByUserID_ExtData(EmployeeID);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_ExtDataAsync(string EmployeeID) {
            return base.Channel.ByUserID_ExtDataAsync(EmployeeID);
        }
        
        public System.Data.DataSet ByUserID(string EmployeeID) {
            return base.Channel.ByUserID(EmployeeID);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ByUserIDAsync(string EmployeeID) {
            return base.Channel.ByUserIDAsync(EmployeeID);
        }
        
        public System.Data.DataSet UsersSearch(string Key) {
            return base.Channel.UsersSearch(Key);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> UsersSearchAsync(string Key) {
            return base.Channel.UsersSearchAsync(Key);
        }
        
        public System.Data.DataSet ByUserName(string UserName) {
            return base.Channel.ByUserName(UserName);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ByUserNameAsync(string UserName) {
            return base.Channel.ByUserNameAsync(UserName);
        }
        
        public System.Data.DataSet ByAgent(string Agent_OU, string Agent_ID) {
            return base.Channel.ByAgent(Agent_OU, Agent_ID);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ByAgentAsync(string Agent_OU, string Agent_ID) {
            return base.Channel.ByAgentAsync(Agent_OU, Agent_ID);
        }
        
        public System.Data.DataSet ByAgent4Site(string Agent_OU, string Agent_ID, string Site) {
            return base.Channel.ByAgent4Site(Agent_OU, Agent_ID, Site);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ByAgent4SiteAsync(string Agent_OU, string Agent_ID, string Site) {
            return base.Channel.ByAgent4SiteAsync(Agent_OU, Agent_ID, Site);
        }
        
        public System.Data.DataSet ExploreEmployee(string CompanyCode, string OU_CODE, int Level) {
            return base.Channel.ExploreEmployee(CompanyCode, OU_CODE, Level);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ExploreEmployeeAsync(string CompanyCode, string OU_CODE, int Level) {
            return base.Channel.ExploreEmployeeAsync(CompanyCode, OU_CODE, Level);
        }
        
        public System.Data.DataSet ByDepartment(string DepartID) {
            return base.Channel.ByDepartment(DepartID);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ByDepartmentAsync(string DepartID) {
            return base.Channel.ByDepartmentAsync(DepartID);
        }
        
        public System.Data.DataSet ByNotesID(string NotesID) {
            return base.Channel.ByNotesID(NotesID);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ByNotesIDAsync(string NotesID) {
            return base.Channel.ByNotesIDAsync(NotesID);
        }
        
        public System.Data.DataSet ByUserID_Govern(string EmployeeID, string CompanyCode) {
            return base.Channel.ByUserID_Govern(EmployeeID, CompanyCode);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_GovernAsync(string EmployeeID, string CompanyCode) {
            return base.Channel.ByUserID_GovernAsync(EmployeeID, CompanyCode);
        }
        
        public System.Data.DataSet ByUserID_Inferior(string EmployeeID, string CompanyCode, string OU_CODE) {
            return base.Channel.ByUserID_Inferior(EmployeeID, CompanyCode, OU_CODE);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_InferiorAsync(string EmployeeID, string CompanyCode, string OU_CODE) {
            return base.Channel.ByUserID_InferiorAsync(EmployeeID, CompanyCode, OU_CODE);
        }
        
        public System.Data.DataSet ByUserID_Manager(string EmployeeID, string Level, string Trace) {
            return base.Channel.ByUserID_Manager(EmployeeID, Level, Trace);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_ManagerAsync(string EmployeeID, string Level, string Trace) {
            return base.Channel.ByUserID_ManagerAsync(EmployeeID, Level, Trace);
        }
        
        public System.Data.DataSet ByOUCode_Assistant(string CompanyCode, string OUCode, string Level) {
            return base.Channel.ByOUCode_Assistant(CompanyCode, OUCode, Level);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ByOUCode_AssistantAsync(string CompanyCode, string OUCode, string Level) {
            return base.Channel.ByOUCode_AssistantAsync(CompanyCode, OUCode, Level);
        }
        
        public System.Data.DataSet ByOUCode_Manager(string CompanyCode, string OUCode, string Level) {
            return base.Channel.ByOUCode_Manager(CompanyCode, OUCode, Level);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ByOUCode_ManagerAsync(string CompanyCode, string OUCode, string Level) {
            return base.Channel.ByOUCode_ManagerAsync(CompanyCode, OUCode, Level);
        }
        
        public System.Data.DataSet ByAssistantID_OU(string AssistantID) {
            return base.Channel.ByAssistantID_OU(AssistantID);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ByAssistantID_OUAsync(string AssistantID) {
            return base.Channel.ByAssistantID_OUAsync(AssistantID);
        }
        
        public System.Data.DataSet ByManagerID_OU(string ManagerID) {
            return base.Channel.ByManagerID_OU(ManagerID);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ByManagerID_OUAsync(string ManagerID) {
            return base.Channel.ByManagerID_OUAsync(ManagerID);
        }
        
        public System.Data.DataSet ByUserID_FindSuperManager_byAbnormal(string UserID, string SystemName) {
            return base.Channel.ByUserID_FindSuperManager_byAbnormal(UserID, SystemName);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_FindSuperManager_byAbnormalAsync(string UserID, string SystemName) {
            return base.Channel.ByUserID_FindSuperManager_byAbnormalAsync(UserID, SystemName);
        }
        
        public bool ByUserID_FindAgentSite(string UserID, string Site) {
            return base.Channel.ByUserID_FindAgentSite(UserID, Site);
        }
        
        public System.Threading.Tasks.Task<bool> ByUserID_FindAgentSiteAsync(string UserID, string Site) {
            return base.Channel.ByUserID_FindAgentSiteAsync(UserID, Site);
        }
        
        public System.Data.DataSet ByUserID_FindWorkflowAgent(string UserID, string FindDepartment, string Site) {
            return base.Channel.ByUserID_FindWorkflowAgent(UserID, FindDepartment, Site);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_FindWorkflowAgentAsync(string UserID, string FindDepartment, string Site) {
            return base.Channel.ByUserID_FindWorkflowAgentAsync(UserID, FindDepartment, Site);
        }
        
        public System.Data.DataSet ByUserID_FindAgent(string UserID, string FindDepartment) {
            return base.Channel.ByUserID_FindAgent(UserID, FindDepartment);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_FindAgentAsync(string UserID, string FindDepartment) {
            return base.Channel.ByUserID_FindAgentAsync(UserID, FindDepartment);
        }
        
        public System.Data.DataSet ByUserID_Agent(string UserID) {
            return base.Channel.ByUserID_Agent(UserID);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_AgentAsync(string UserID) {
            return base.Channel.ByUserID_AgentAsync(UserID);
        }
        
        public System.Data.DataSet ByUserID_DirectInferior(string EmployeeID, string CompanyCode, string OU_CODE) {
            return base.Channel.ByUserID_DirectInferior(EmployeeID, CompanyCode, OU_CODE);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_DirectInferiorAsync(string EmployeeID, string CompanyCode, string OU_CODE) {
            return base.Channel.ByUserID_DirectInferiorAsync(EmployeeID, CompanyCode, OU_CODE);
        }
        
        public System.Data.DataSet ByUserID_Abnormal_Manager(string EmployeeID, string Level, string JobTitle, string UpStep) {
            return base.Channel.ByUserID_Abnormal_Manager(EmployeeID, Level, JobTitle, UpStep);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_Abnormal_ManagerAsync(string EmployeeID, string Level, string JobTitle, string UpStep) {
            return base.Channel.ByUserID_Abnormal_ManagerAsync(EmployeeID, Level, JobTitle, UpStep);
        }
        
        public System.Data.DataSet ByUserID_Abnormal_Manager_New(string EmployeeID, string Level, string JobTitle, string UpStep, string JobStep) {
            return base.Channel.ByUserID_Abnormal_Manager_New(EmployeeID, Level, JobTitle, UpStep, JobStep);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_Abnormal_Manager_NewAsync(string EmployeeID, string Level, string JobTitle, string UpStep, string JobStep) {
            return base.Channel.ByUserID_Abnormal_Manager_NewAsync(EmployeeID, Level, JobTitle, UpStep, JobStep);
        }
        
        public System.Data.DataSet ByUserID_SiteManager(string EmployeeID, string Level, string Trace) {
            return base.Channel.ByUserID_SiteManager(EmployeeID, Level, Trace);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_SiteManagerAsync(string EmployeeID, string Level, string Trace) {
            return base.Channel.ByUserID_SiteManagerAsync(EmployeeID, Level, Trace);
        }
        
        public System.Data.DataSet ByUserID_Site_Manager(string EmployeeID, string Level, string JobTitle, string UpStep) {
            return base.Channel.ByUserID_Site_Manager(EmployeeID, Level, JobTitle, UpStep);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_Site_ManagerAsync(string EmployeeID, string Level, string JobTitle, string UpStep) {
            return base.Channel.ByUserID_Site_ManagerAsync(EmployeeID, Level, JobTitle, UpStep);
        }
        
        public System.Data.DataSet ByUserID_Site_Manager_New(string EmployeeID, string Level, string JobTitle, string UpStep, string JobStep) {
            return base.Channel.ByUserID_Site_Manager_New(EmployeeID, Level, JobTitle, UpStep, JobStep);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_Site_Manager_NewAsync(string EmployeeID, string Level, string JobTitle, string UpStep, string JobStep) {
            return base.Channel.ByUserID_Site_Manager_NewAsync(EmployeeID, Level, JobTitle, UpStep, JobStep);
        }
        
        public System.Data.DataSet ByUserID_SiteGovern(string EmployeeID, string CompanyCode) {
            return base.Channel.ByUserID_SiteGovern(EmployeeID, CompanyCode);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_SiteGovernAsync(string EmployeeID, string CompanyCode) {
            return base.Channel.ByUserID_SiteGovernAsync(EmployeeID, CompanyCode);
        }
        
        public System.Data.DataSet ByUserID_SiteInferior(string EmployeeID, string CompanyCode, string OU_CODE) {
            return base.Channel.ByUserID_SiteInferior(EmployeeID, CompanyCode, OU_CODE);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_SiteInferiorAsync(string EmployeeID, string CompanyCode, string OU_CODE) {
            return base.Channel.ByUserID_SiteInferiorAsync(EmployeeID, CompanyCode, OU_CODE);
        }
        
        public System.Data.DataSet ByUserID_SiteDirectInferior(string EmployeeID, string CompanyCode, string OU_CODE) {
            return base.Channel.ByUserID_SiteDirectInferior(EmployeeID, CompanyCode, OU_CODE);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_SiteDirectInferiorAsync(string EmployeeID, string CompanyCode, string OU_CODE) {
            return base.Channel.ByUserID_SiteDirectInferiorAsync(EmployeeID, CompanyCode, OU_CODE);
        }
        
        public System.Data.DataSet ByUserID_FindSuperManager_bySite(string UserID, string SystemName) {
            return base.Channel.ByUserID_FindSuperManager_bySite(UserID, SystemName);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> ByUserID_FindSuperManager_bySiteAsync(string UserID, string SystemName) {
            return base.Channel.ByUserID_FindSuperManager_bySiteAsync(UserID, SystemName);
        }
    }
}
