namespace NewModel.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBConnectData : DbContext
    {
        public DBConnectData()
            : base("name=DBConnectData")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<APPROVE_SIGN> APPROVE_SIGN { get; set; }
        public virtual DbSet<Approver> Approvers { get; set; }
        public virtual DbSet<ApproverType> ApproverTypes { get; set; }
        public virtual DbSet<BU> BUs { get; set; }
        public virtual DbSet<DATA_APP_ESIGN> DATA_APP_ESIGN { get; set; }
        public virtual DbSet<DATA_DEPARTMENT> DATA_DEPARTMENTs { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<FormContent> FormContents { get; set; }
        public virtual DbSet<Form> Forms { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Site> Sites { get; set; }
        public virtual DbSet<SubmitSign> SubmitSigns { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Assign_Info> Assign_Info { get; set; }
        public virtual DbSet<AssignDetail_Info> AssignDetail_Info { get; set; }
        public virtual DbSet<EMODULEFUNCTION> EMODULEFUNCTIONs { get; set; }
        public virtual DbSet<EPERMISSION> EPERMISSIONs { get; set; }
        public virtual DbSet<FileDetail> FileDetails { get; set; }
        public virtual DbSet<FormSign> FormSigns { get; set; }
        public virtual DbSet<MasterData> MasterDatas { get; set; }
        public virtual DbSet<MasterData_FormType> MasterData_FormType { get; set; }
        public virtual DbSet<MasterData_POChange> MasterData_POChange { get; set; }
        public virtual DbSet<MasterData_Sign> MasterData_Sign { get; set; }
        public virtual DbSet<MaterialOut_Apply_D> MaterialOut_Apply_D { get; set; }
        public virtual DbSet<MaterialOut_Apply_D_Temp> MaterialOut_Apply_D_Temp { get; set; }
        public virtual DbSet<MaterialOut_Apply_H> MaterialOut_Apply_H { get; set; }
        public virtual DbSet<SystemConfig> SystemConfigs { get; set; }
        public virtual DbSet<User_History> User_History { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<FACTORY> FACTORies { get; set; }

        public virtual DbSet<Location_Fac> Location_Facs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.UserID)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.Telephone)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.CostNo)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.SiteID)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.ManagerEmpNo)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.ManagerEmail)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.Permission)
                .IsFixedLength();

            modelBuilder.Entity<Application>()
                .Property(e => e.UserID)
                .IsFixedLength();

            modelBuilder.Entity<Application>()
                .Property(e => e.SiteID)
                .IsFixedLength();

            modelBuilder.Entity<Application>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Application>()
                .Property(e => e.Telephone)
                .IsFixedLength();

            modelBuilder.Entity<Application>()
                .Property(e => e.DOU)
                .IsFixedLength();

            modelBuilder.Entity<Application>()
                .Property(e => e.status)
                .IsFixedLength();

            modelBuilder.Entity<Application>()
                .Property(e => e.states)
                .IsFixedLength();

            modelBuilder.Entity<Approver>()
                .Property(e => e.SiteID)
                .IsFixedLength();

            modelBuilder.Entity<Approver>()
                .Property(e => e.ApproverEmpNo)
                .IsFixedLength();

            modelBuilder.Entity<BU>()
                .Property(e => e.SiteID)
                .IsFixedLength();

            modelBuilder.Entity<BU>()
                .HasMany(e => e.Approvers)
                .WithRequired(e => e.BU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DATA_APP_ESIGN>()
                .Property(e => e.SiteID)
                .IsFixedLength();

            modelBuilder.Entity<DATA_APP_ESIGN>()
                .Property(e => e.DOU)
                .IsFixedLength();

            modelBuilder.Entity<DATA_APP_ESIGN>()
                .Property(e => e.ApplicantNo)
                .IsFixedLength();

            modelBuilder.Entity<DATA_APP_ESIGN>()
                .Property(e => e.Signer1No)
                .IsFixedLength();

            modelBuilder.Entity<DATA_APP_ESIGN>()
                .Property(e => e.Signer2No)
                .IsFixedLength();

            modelBuilder.Entity<DATA_APP_ESIGN>()
                .Property(e => e.Signer3No)
                .IsFixedLength();

            modelBuilder.Entity<DATA_APP_ESIGN>()
                .Property(e => e.Signer4No)
                .IsFixedLength();

            modelBuilder.Entity<DATA_APP_ESIGN>()
                .Property(e => e.Signer5No)
                .IsFixedLength();

            modelBuilder.Entity<DATA_APP_ESIGN>()
                .Property(e => e.Signer6No)
                .IsFixedLength();

            modelBuilder.Entity<DATA_APP_ESIGN>()
                .Property(e => e.Signer7No)
                .IsFixedLength();

            modelBuilder.Entity<DATA_APP_ESIGN>()
                .Property(e => e.Signer8No)
                .IsFixedLength();

            modelBuilder.Entity<DATA_APP_ESIGN>()
                .Property(e => e.Signer9No)
                .IsFixedLength();

            modelBuilder.Entity<DATA_APP_ESIGN>()
                .Property(e => e.Signer2NoAgent)
                .IsFixedLength();

            modelBuilder.Entity<DATA_APP_ESIGN>()
                .Property(e => e.Signer3NoAgent)
                .IsFixedLength();

            modelBuilder.Entity<DATA_APP_ESIGN>()
                .Property(e => e.Signer4NoAgent)
                .IsFixedLength();

            modelBuilder.Entity<DATA_APP_ESIGN>()
                .Property(e => e.Signer5NoAgent)
                .IsFixedLength();

            modelBuilder.Entity<DATA_APP_ESIGN>()
                .Property(e => e.Signer6NoAgent)
                .IsFixedLength();

            modelBuilder.Entity<DATA_APP_ESIGN>()
                .Property(e => e.Signer7NoAgent)
                .IsFixedLength();

            modelBuilder.Entity<DATA_APP_ESIGN>()
                .Property(e => e.Signer8NoAgent)
                .IsFixedLength();

            modelBuilder.Entity<DATA_APP_ESIGN>()
                .Property(e => e.Signer9NoAgent)
                .IsFixedLength();

            modelBuilder.Entity<Department>()
                .Property(e => e.Department1)
                .IsFixedLength();

            modelBuilder.Entity<Department>()
                .Property(e => e.CostNO)
                .IsFixedLength();

            modelBuilder.Entity<FormContent>()
                .Property(e => e.InputName)
                .IsFixedLength();

            modelBuilder.Entity<FormContent>()
                .Property(e => e.InputType)
                .IsFixedLength();

            modelBuilder.Entity<Form>()
                .Property(e => e.Site)
                .IsFixedLength();

            modelBuilder.Entity<Form>()
                .Property(e => e.Creator)
                .IsFixedLength();

            modelBuilder.Entity<Form>()
                .HasMany(e => e.FormSigns)
                .WithRequired(e => e.Form)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Language>()
                .Property(e => e.languageId)
                .IsFixedLength();

            modelBuilder.Entity<Language>()
                .HasOptional(e => e.Languages1)
                .WithRequired(e => e.Language1);

            modelBuilder.Entity<Language>()
                .HasMany(e => e.Resources)
                .WithRequired(e => e.Language)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Permission>()
                .Property(e => e.PermissionId)
                .IsFixedLength();

            modelBuilder.Entity<Resource>()
                .Property(e => e.languageId)
                .IsFixedLength();

            modelBuilder.Entity<Resource>()
                .Property(e => e.type)
                .IsFixedLength();

            modelBuilder.Entity<Site>()
                .Property(e => e.SiteID)
                .IsFixedLength();

            modelBuilder.Entity<Site>()
                .HasMany(e => e.Approvers)
                .WithRequired(e => e.Site)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Site>()
                .HasMany(e => e.BUs)
                .WithRequired(e => e.Site)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Assign_Info>()
                .Property(e => e.ModuleName)
                .IsUnicode(false);

            modelBuilder.Entity<Assign_Info>()
                .Property(e => e.ApplyNO)
                .IsUnicode(false);

            modelBuilder.Entity<Assign_Info>()
                .Property(e => e.Signer)
                .IsUnicode(false);

            modelBuilder.Entity<Assign_Info>()
                .Property(e => e.Signer_Type)
                .IsUnicode(false);

            modelBuilder.Entity<Assign_Info>()
                .Property(e => e.Agent)
                .IsUnicode(false);

            modelBuilder.Entity<Assign_Info>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Assign_Info>()
                .Property(e => e.Is_Deliver)
                .IsUnicode(false);

            modelBuilder.Entity<Assign_Info>()
                .Property(e => e.Deliver_Person)
                .IsUnicode(false);

            modelBuilder.Entity<Assign_Info>()
                .Property(e => e.back_person)
                .IsUnicode(false);

            modelBuilder.Entity<Assign_Info>()
                .Property(e => e.back_type)
                .IsUnicode(false);

            modelBuilder.Entity<Assign_Info>()
                .Property(e => e.actionitem)
                .IsUnicode(false);

            modelBuilder.Entity<Assign_Info>()
                .Property(e => e.SortNum)
                .IsUnicode(false);

            modelBuilder.Entity<Assign_Info>()
                .Property(e => e.respdep)
                .IsUnicode(false);

            modelBuilder.Entity<AssignDetail_Info>()
                .Property(e => e.ModuleName)
                .IsUnicode(false);

            modelBuilder.Entity<AssignDetail_Info>()
                .Property(e => e.ApplyNO)
                .IsUnicode(false);

            modelBuilder.Entity<AssignDetail_Info>()
                .Property(e => e.Signer)
                .IsUnicode(false);

            modelBuilder.Entity<AssignDetail_Info>()
                .Property(e => e.Signer_Type)
                .IsUnicode(false);

            modelBuilder.Entity<AssignDetail_Info>()
                .Property(e => e.Agent)
                .IsUnicode(false);

            modelBuilder.Entity<AssignDetail_Info>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<AssignDetail_Info>()
                .Property(e => e.Sign_Detail)
                .IsUnicode(false);

            modelBuilder.Entity<AssignDetail_Info>()
                .Property(e => e.Signer_IP)
                .IsUnicode(false);

            modelBuilder.Entity<AssignDetail_Info>()
                .Property(e => e.actionitem)
                .IsUnicode(false);

            modelBuilder.Entity<AssignDetail_Info>()
                .Property(e => e.respdep)
                .IsUnicode(false);

            modelBuilder.Entity<AssignDetail_Info>()
                .Property(e => e.SortNum)
                .IsUnicode(false);

            modelBuilder.Entity<EMODULEFUNCTION>()
                .Property(e => e.MODULENAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMODULEFUNCTION>()
                .Property(e => e.SECTIONNAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMODULEFUNCTION>()
                .Property(e => e.SECTIONNAME_EN)
                .IsUnicode(false);

            modelBuilder.Entity<EMODULEFUNCTION>()
                .Property(e => e.SECTIONSORTNO)
                .HasPrecision(18, 0);

            modelBuilder.Entity<EMODULEFUNCTION>()
                .Property(e => e.FUNCTIONNAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMODULEFUNCTION>()
                .Property(e => e.SORTNO)
                .HasPrecision(10, 0);

            modelBuilder.Entity<EMODULEFUNCTION>()
                .Property(e => e.Is_CJ)
                .IsUnicode(false);

            modelBuilder.Entity<EMODULEFUNCTION>()
                .Property(e => e.PROMPTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<EMODULEFUNCTION>()
                .Property(e => e.PROMPTNAME_EN)
                .IsUnicode(false);

            modelBuilder.Entity<EMODULEFUNCTION>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<EMODULEFUNCTION>()
                .Property(e => e.FUNCCATEGORY)
                .IsUnicode(false);

            modelBuilder.Entity<EMODULEFUNCTION>()
                .Property(e => e.FUNCFIGURE)
                .IsUnicode(false);

            modelBuilder.Entity<EMODULEFUNCTION>()
                .Property(e => e.FUNCVBFORM)
                .IsUnicode(false);

            modelBuilder.Entity<EMODULEFUNCTION>()
                .Property(e => e.FUNCDESC)
                .IsUnicode(false);

            modelBuilder.Entity<EMODULEFUNCTION>()
                .Property(e => e.WEBPAGE)
                .IsUnicode(false);

            modelBuilder.Entity<EMODULEFUNCTION>()
                .Property(e => e.NOTSHOW)
                .HasPrecision(2, 0);

            modelBuilder.Entity<EMODULEFUNCTION>()
                .Property(e => e.NEWWINDOW)
                .HasPrecision(2, 0);

            modelBuilder.Entity<EMODULEFUNCTION>()
                .Property(e => e.LUPBY)
                .IsUnicode(false);

            modelBuilder.Entity<EPERMISSION>()
                .Property(e => e.PERMISSIONTYPE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<EPERMISSION>()
                .Property(e => e.PERMISSIONNAME)
                .IsUnicode(false);

            modelBuilder.Entity<EPERMISSION>()
                .Property(e => e.FUNCTIONNAME)
                .IsUnicode(false);

            modelBuilder.Entity<EPERMISSION>()
                .Property(e => e.MODIFICATION)
                .HasPrecision(2, 0);

            modelBuilder.Entity<EPERMISSION>()
                .Property(e => e.LUPBY)
                .IsUnicode(false);

            modelBuilder.Entity<EPERMISSION>()
                .Property(e => e.Authority)
                .IsUnicode(false);

            modelBuilder.Entity<FileDetail>()
                .Property(e => e.FileName)
                .IsUnicode(false);

            modelBuilder.Entity<FormSign>()
                .Property(e => e.SignUser)
                .IsFixedLength();

            modelBuilder.Entity<MasterData>()
                .Property(e => e.DFSite)
                .IsUnicode(false);

            modelBuilder.Entity<MasterData>()
                .Property(e => e.Division)
                .IsUnicode(false);

            modelBuilder.Entity<MasterData>()
                .Property(e => e.Building)
                .IsUnicode(false);

            modelBuilder.Entity<MasterData>()
                .Property(e => e.Security_Guard_NO)
                .IsUnicode(false);

            modelBuilder.Entity<MasterData_FormType>()
                .Property(e => e.FormType)
                .IsUnicode(false);

            modelBuilder.Entity<MasterData_FormType>()
                .Property(e => e.DFSite)
                .IsUnicode(false);

            modelBuilder.Entity<MasterData_FormType>()
                .Property(e => e.ApplyType)
                .IsUnicode(false);

            modelBuilder.Entity<MasterData_FormType>()
                .Property(e => e.Security_Guard_NO)
                .IsUnicode(false);

            modelBuilder.Entity<MasterData_FormType>()
                .Property(e => e.IsValid)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterData_FormType>()
                .Property(e => e.IsManageNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterData_POChange>()
                .Property(e => e.F_Site)
                .IsUnicode(false);

            modelBuilder.Entity<MasterData_POChange>()
                .Property(e => e.BU)
                .IsUnicode(false);

            modelBuilder.Entity<MasterData_POChange>()
                .Property(e => e.Plant)
                .IsUnicode(false);

            modelBuilder.Entity<MasterData_POChange>()
                .Property(e => e.ChangeType)
                .IsUnicode(false);

            modelBuilder.Entity<MasterData_POChange>()
                .Property(e => e.WOCurrentStatus)
                .IsUnicode(false);

            modelBuilder.Entity<MasterData_POChange>()
                .Property(e => e.RespDep)
                .IsUnicode(false);

            modelBuilder.Entity<MasterData_POChange>()
                .Property(e => e.Submit_person)
                .IsUnicode(false);

            modelBuilder.Entity<MasterData_POChange>()
                .Property(e => e.Lastedit_Person)
                .IsUnicode(false);

            modelBuilder.Entity<MasterData_Sign>()
                .Property(e => e.DFSite)
                .IsUnicode(false);

            modelBuilder.Entity<MasterData_Sign>()
                .Property(e => e.Building)
                .IsUnicode(false);

            modelBuilder.Entity<MasterData_Sign>()
                .Property(e => e.Floor)
                .IsUnicode(false);

            modelBuilder.Entity<MasterData_Sign>()
                .Property(e => e.BU)
                .IsUnicode(false);

            modelBuilder.Entity<MasterData_Sign>()
                .Property(e => e.FormType)
                .IsUnicode(false);

            modelBuilder.Entity<MasterData_Sign>()
                .Property(e => e.F_empno)
                .IsUnicode(false);

            modelBuilder.Entity<MasterData_Sign>()
                .Property(e => e.F_Name)
                .IsUnicode(false);

            modelBuilder.Entity<MasterData_Sign>()
                .Property(e => e.PowerLeave)
                .IsUnicode(false);

            modelBuilder.Entity<MasterData_Sign>()
                .Property(e => e.Lasteditby)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_D>()
                .Property(e => e.ApplyNO)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_D>()
                .Property(e => e.M_Desc)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_D>()
                .Property(e => e.Unit)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_D>()
                .Property(e => e.Qty)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_D>()
                .Property(e => e.Rec_Depart)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_D>()
                .Property(e => e.LotCode)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_D>()
                .Property(e => e.IsDelete)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_D>()
                .Property(e => e.Lasteditby)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_D_Temp>()
                .Property(e => e.M_Desc)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_D_Temp>()
                .Property(e => e.Unit)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_D_Temp>()
                .Property(e => e.Qty)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_D_Temp>()
                .Property(e => e.Rec_Depart)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_D_Temp>()
                .Property(e => e.LotCode)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_H>()
                .Property(e => e.ApplyNO)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_H>()
                .Property(e => e.DFSite)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_H>()
                .Property(e => e.ApplyType)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_H>()
                .Property(e => e.Division)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_H>()
                .Property(e => e.ApplyDept)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_H>()
                .Property(e => e.ApplyPerson)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_H>()
                .Property(e => e.Emp_no)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_H>()
                .Property(e => e.Ext)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_H>()
                .Property(e => e.VisitTimeFrom)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_H>()
                .Property(e => e.VisitTimeTO)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_H>()
                .Property(e => e.ShipType)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_H>()
                .Property(e => e.Person_Empno)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_H>()
                .Property(e => e.PersonName)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_H>()
                .Property(e => e.TruckSize)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_H>()
                .Property(e => e.MLnumber_plate)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_H>()
                .Property(e => e.OtherTool)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_H>()
                .Property(e => e.Manager)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_H>()
                .Property(e => e.Manager_NO)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_H>()
                .Property(e => e.Boss)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_H>()
                .Property(e => e.Boss_NO)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_H>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_H>()
                .Property(e => e.SUbmit_person)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_H>()
                .Property(e => e.LastEdit_person)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_H>()
                .Property(e => e.Security_Guard_NO)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialOut_Apply_H>()
                .Property(e => e.AttachFileName)
                .IsUnicode(false);

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<User_History>()
                .Property(e => e.User_Id)
                .IsUnicode(false);

            modelBuilder.Entity<User_History>()
                .Property(e => e.User_Name)
                .IsUnicode(false);

            modelBuilder.Entity<User_History>()
                .Property(e => e.Action_Desc)
                .IsUnicode(false);

            modelBuilder.Entity<User_History>()
                .Property(e => e.Computer_IP)
                .IsUnicode(false);

            modelBuilder.Entity<User_History>()
                .Property(e => e.Computer_Name)
                .IsUnicode(false);

            modelBuilder.Entity<User_History>()
                .Property(e => e.Computer_OS)
                .IsUnicode(false);

            modelBuilder.Entity<User_History>()
                .Property(e => e.Computer_IE)
                .IsUnicode(false);

            modelBuilder.Entity<User_History>()
                .Property(e => e.Action_Type)
                .IsUnicode(false);

            modelBuilder.Entity<User_History>()
                .Property(e => e.Groupid)
                .IsUnicode(false);

            modelBuilder.Entity<User_History>()
                .Property(e => e.ServerIP)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.DFSite)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PassWord)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Dept)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Emp_NO)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.mailbox)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.division)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.CostNO)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.purpose)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.IsConfirm)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.IPAddress)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LockStatus)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PassWord1)
                .IsUnicode(false);
        }
    }
}
