using System;


public class Customer_master
{
    public int entry_id { get; set; }
    public string user_id { get; set; }
    public string email_id1 { get; set; }
    public string email_id2 { get; set; }
    public string organisation_name { get; set; }
    public string contact_person { get; set; }
    public string mobile1 { get; set; }
    public string mobile2 { get; set; }
    public string mobile3 { get; set; }
    public string landline { get; set; }
    public string firm_type { get; set; }
    public string website { get; set; }
    public string sms_alert { get; set; }
    public string address_line1 { get; set; }
    public string address_line2 { get; set; }
    public string landmark { get; set; }
    public string city { get; set; }
    public string pin { get; set; }
    public string state { get; set; }
    public string Pan { get; set; }
    public int UserType_Id { get; set; }
    public string Status { get; set; }
    public string Gender { get; set; }
    public string Photo { get; set; }
}
public class Dsc_Master
{
    public int entry_Id { get; set; }
    public int Dsc_TypeId { get; set; }
    public string Dsc_No { get; set; }
    public string Status { get; set; }
    public int Dsc_RequestId { get; set; }
    public string AssignedUserId { get; set; }
    public DateTime entryDate { get; set; }
    public DateTime Assign_Date { get; set; }
    public DateTime ValidFrom { get; set; }
    public DateTime ValidTo { get; set; }
    public string AssignedById { get; set; }
    public string AssignedToId { get; set; }
    public string DSCSrNo { get; set; }
    public string DSCFrom { get; set; }
    public string URL { get; set; }
    public string Challenge_Passphase { get; set; }
    public string AuthCode { get; set; }
    public bool AddToken { get; set; }
    public string CustomerRemark { get; set; }
}
public class Dsc_Request
{
    public int entryId { get; set; }
    public int DscType_Id { get; set; }
    public decimal Total_DSC { get; set; }
    public string User_Id { get; set; }
    public string Status { get; set; }
    public DateTime RequestDate { get; set; }
    public DateTime ResponceDate { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentNo { get; set; }
    public string PaymentDescription { get; set; }
    public string Remark { get; set; }
    public DateTime entryDate { get; set; }
    public string PaymentType { get; set; }
    public decimal PaidAmount { get; set; }
    public decimal TotalAmt { get; set; }
    public decimal Balance { get; set; }
    public DateTime InstrumentDate { get; set; }
    public string Bank { get; set; }
    public string Branch { get; set; }
    public string Recieptimage { get; set; }
    public string RecieptNo { get; set; }
    public bool AddToken { get; set; }
    public decimal TokenAmt { get; set; }
}
public class Dsc_Typemaster
{
    public int entry_Id { get; set; }
    public string Dsc_Type { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime EntryDate { get; set; }
}
public class UserType_master
{
    public int entry_Id { get; set; }
    public string User_Type { get; set; }
    public string Code { get; set; }
}
public class USERS
{
    public int entry_id	 { get; set; }
    public string User_id	 { get; set; }
    public string email_id1 { get; set; }
    public string email_id2	 { get; set; }
    public string organisation_name	 { get; set; }
    public string contact_person	 { get; set; }
    public string mobile1	 { get; set; }
    public string mobile2  { get; set; }
    public string mobile3  { get; set; }
    public string landline	 { get; set; }
    public string firm_type	 { get; set; }
    public string website	 { get; set; }
    public string sms_alert	 { get; set; }
    public string address_line1	 { get; set; }
    public string address_line2	 { get; set; }
    public string landmark	 { get; set; }
    public string city	 { get; set; }
    public string pin  { get; set; }
    public string state	 { get; set; }
    public string Pan  { get; set; }
    public int UserType_Id	 { get; set; }
    public string Status	 { get; set; }
    public string Password  { get; set; }
    public string LastLogin  { get; set; }
    
}
public class user_master
{
    public int entry_id { get; set; }
    public string user_id { get; set; }
    public string passward { get; set; }
    public DateTime last_login { get; set; }
    public int User_TypeId { get; set; }
}
public class T01_Transection
{
    public long Id { get; set; }
    public string UserId { get; set; }
    public decimal PaidAmt { get; set; }
    public decimal TotalAmt { get; set; }
    public decimal BalAmt { get; set; }
    public string Perticular { get; set; }
    public DateTime EntryDate { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentType { get; set; }
    public DateTime InstrumentDate { get; set; }
    public string Bank { get; set; }
    public string Branch { get; set; }
    public string Reciept { get; set; }
    public string Status { get; set; }
    public int DSCRequestId { get; set; }
    public string RecieptNo { get; set; }
    public bool AddToken { get; set; }
    public decimal TokenAmt { get; set; }
    public string PyamentNo { get; set; }
    public string AdminRemark { get; set; }
}
public class CustomerDoc
{
    public string UserId { get; set; }
    public string Photo { get; set; }
    public string Pan { get; set; }
    public string Address { get; set; }
    public string TIN_ST2 { get; set; }
    public string Authority { get; set; }
    public string ITR { get; set; }
    public string Bank_Statement { get; set; }
    public string OtherDoc { get; set; }
}
public class ReqStatus
{
    public int entryId { get; set; }
    public int DScReqId { get; set; }
    public string Status { get; set; }
    public string UserId { get; set; }
    public string DSCFrom { get; set; }
    public string URL { get; set; }
    public string ReqStatu { get; set; }
    public string Remark { get; set; }
    public string DSCSrNo { get; set; }
}
public class D01_UserDSCPrice
{
    public string UserId { get; set; }
    public decimal Ind_Class_2_Sign { get; set; }
    public decimal Org_Class_2_Sign { get; set; }
    public decimal Ind_Class_2_Com { get; set; }
    public decimal Org_Class_2_Com { get; set; }
    public decimal Ind_Class_3_Sign { get; set; }
    public decimal Org_Class_3_Sign { get; set; }
    public decimal Ind_Class_3_Com { get; set; }
    public decimal Org_Class_3_Com { get; set; }
    public decimal DGPT_1Y { get; set; }
    public decimal DGPT_2Y { get; set; }
    public decimal Token { get; set; }
    public bool TaxApplied { get; set; }
}
public class M02_TaxMaster
{
    public int TaxId { get; set; }
    public string Tax { get; set; }
    public decimal value { get; set; }
    public bool IsActive { get; set; }
    public bool IsAppliedOnToken { get; set; }
}
public class M04_RemarkMaster
{
    public int Id { get; set; }
    public string Remark { get; set; }
    public string Description { get; set; }
}
public class T02_Transection
{
    public int T01_Id { get; set; }
    public string TaxHead { get; set; }
    public decimal Value { get; set; }
    public bool IsTokenTax { get; set; }
}
public class T03_Transection
{
    public int T01_Id { get; set; }
    public string ITEMName { get; set; }
    public decimal Value { get; set; }
    public bool IsToken { get; set; }
    public int Qty { get; set; }
}