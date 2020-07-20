using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Desktop.Win.ViewModel
{
    public class PasswordInfoVM
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public static ObservableCollection<PasswordInfoVM> GetPasswordInfo()
        {
            return new ObservableCollection<PasswordInfoVM>
            {
                new PasswordInfoVM {Name = "asdasd", Login = "asdasdasd", Password = "asdasdasd"},
                new PasswordInfoVM {Name = "ksdfksmd", Login = "asdasdasd", Password = "asdasdasd"},
                new PasswordInfoVM {Name = "afmadsmfcasd", Login = "asdasdasd", Password = "asdasdasd"},
                new PasswordInfoVM {Name = "kdmafkma", Login = "asdasdasd", Password = "asdasdasd"},
                new PasswordInfoVM {Name = "masdfkladfk", Login = "asdasdasd", Password = "asdasdasd"},
                new PasswordInfoVM {Name = "lds,m;flme", Login = "asdasdasd", Password = "asdasdasd"},
                new PasswordInfoVM {Name = ";ldmf;lqmew", Login = "asdasdasd", Password = "asdasdasd"},
                new PasswordInfoVM {Name = ",dmflkwme", Login = "asdasdasd", Password = "asdasdasd"},
                new PasswordInfoVM {Name = "amsfkmqwk", Login = "asdasdasd", Password = "asdasdasd"},
                new PasswordInfoVM {Name = " dmlkfewmm", Login = "asdasdasd", Password = "asdasdasd"}
            };
        }
    }
}
