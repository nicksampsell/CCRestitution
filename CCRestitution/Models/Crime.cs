namespace CCRestitution.Models
{
    public class Crime : BaseEntity
    {
        public int Id { get; set; }
        public string? Law_Ordinal { get; set; }
        public string? Attempted_Class { get; set; }
        public string? Attempted_VF_Indicator { get; set; }
        public string? Attempted_NYS_Law_Category { get; set; }
        public string? Bus_Driver_Charge_Code { get; set; }
        public string? Sex_Offender_Registry_Code { get; set; }
        public string? NCIC_Code { get; set; }
        public string? UCR_Code { get; set; }
        public string? SAFIS_Crime_Cateory_Code { get; set; }
        public string? Offense_Category { get; set; }
        public string? JO_Indicator { get; set; }
        public string? JD_Indicator { get; set; }
        public string? IBR_Code { get; set; }
        public string? Maxi_Law_Description { get; set; }
        public string? Law_Description { get; set; }
        public string? Mini_Law_Description { get; set; }
        public string? Title { get; set; }
        public string? Section { get; set; }
        public string? Section13 { get; set; }
        public string? Sub_Section { get; set; }
        public string? Sub_Section13 { get; set; }
        public string? Degree { get; set; }
        public string? EFFECTIVE_DATE { get; set; }
        public string? REPEAL_DATE { get; set; }
        public string? FP_Offense { get; set; }
        public string? Unconst_Date { get; set; }
        public string? Weapon_Charge { get; set; }
        public string? Armed_VFO_Charge { get; set; }
        public string? Minors_Charge { get; set; }
        public string? Career_Criminal_Charge { get; set; }
        public string? INS_Charge { get; set; }
        public string? Non_Seal_Charge { get; set; }
        public string? Sub_Convict_Charge { get; set; }
        public string? Jail_Charge { get; set; }
        public string? Post_Convict_Charge { get; set; }
        public string? Auto_Strip_Charge { get; set; }
        public string? Full_Law_Description { get; set; }
        public string? NYS_Law_Category { get; set; }
        public string? VF_Indicator { get; set; }
        public string? Class { get; set; }
        public string? DNA_Indicator { get; set; }
        public string? Attempted_DNA_Indicator { get; set; }
        public string? Escape_Charge { get; set; }
        public string? Hate_Crime { get; set; }
        public string? Date_Invalidated { get; set; }
        public string? Terrorism_Indicator { get; set; }
        public string? DMV_VTCode { get; set; }
        public string? AO_Indicator { get; set; }
        public string? RTA_FP_Offense { get; set; }
        public string? MODIFIED_DATE { get; set; }
        public string? Civil_Confinement_Indicator { get; set; }
        public string? Attempted_CCI { get; set; }
        public string? Expanded_Law_Literal { get; set; }
        public string? Sexually_Motivated_Ind { get; set; }
        public string? MCDV_Charge_Indicator { get; set; }
        public string? RDLR_Indicator { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
