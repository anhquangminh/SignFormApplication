namespace New_Esign.Areas.Administrators.Models
{
    public class FormSignModel
    {
        public int FormID { get; set; }
        public int SignStep { get; set; }
        public string SignUser { get; set; }
        public string SignDescription { get; set; }
        public FormSignModel()
        {
            this.FormID = 0;
            this.SignStep = 1;
            this.SignUser = "";
            this.SignDescription = "";
        }
        public FormSignModel(int _FormID, int _SignStep, string _SignUser, string _SignDescription)
        {
            this.FormID = _FormID;
            this.SignStep = _SignStep;
            this.SignUser = _SignUser;
            this.SignDescription = _SignDescription;
        }
    }
}