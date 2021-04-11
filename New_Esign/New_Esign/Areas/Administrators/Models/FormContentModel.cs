namespace New_Esign.Areas.Administrators.Models
{
    public class FormContentModel
    {
        public int FormID { get; set; }
        public string InputName { get; set; }
        public string InputNameEN { get; set; }
        public string InputNameVI { get; set; }
        public string InputNameCH { get; set; }
        public string InputType { get; set; }
        public int InputIndex { get; set; }
        public bool IsRequired { get; set; }
        public FormContentModel()
        {
            this.FormID = 0;
            this.InputName = "";
            this.InputNameEN = "";
            this.InputNameVI = "";
            this.InputNameCH = "";
            this.InputType = "";
            this.InputIndex = 1;
            this.IsRequired = false;
        }
        public FormContentModel(int _FormID, string _InputName, string _InputNameEN, string _InputNameVI, string _InputNameCH, string _InputType, int _InputIndex, bool _IsRequired = false)
        {
            this.FormID = _FormID;
            this.InputName = _InputName;
            this.InputNameEN = _InputNameEN;
            this.InputNameVI = _InputNameVI;
            this.InputNameCH = _InputNameCH;
            this.InputType = _InputType;
            this.InputIndex = _InputIndex;
            this.IsRequired = _IsRequired;
        }
        public FormContentModel(int _FormID, string _InputName, string _InputType, int _InputIndex, bool _IsRequired = false)
        {
            this.FormID = _FormID;
            this.InputName = _InputName;
            this.InputNameEN = LanguageHelper.GetResource(this.InputName,LanguageHelper.languageEN);
            this.InputNameVI = LanguageHelper.GetResource(this.InputName, LanguageHelper.languageVI);
            this.InputNameCH = LanguageHelper.GetResource(this.InputName, LanguageHelper.languageCH);
            this.InputType = _InputType;
            this.InputIndex = _InputIndex;
            this.IsRequired = _IsRequired;
        }
    }
}