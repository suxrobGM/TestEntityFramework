using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using TestEntityFramework.Model;

namespace TestEntityFramework.ViewModel
{
    public class AddNewStudentViewModel : BindableBase
    {
        private string studentName;
        private string studentSurname;
        private int studentGroup;
        private int studentAge;
        private string imagePath;
        private string studentCollege;
        private DateTime studentDateBirth;
        private SingletonModel model;

        public DelegateCommand AddButtonCommand { get; }
        public DelegateCommand UploadPhotoCommand { get; }

        public string StudentName
        {
            get => studentName;
            set
            {
                studentName = value;
                RaisePropertyChanged(nameof(StudentName));
            }
        }
        public string StudentSurname
        {
            get => studentSurname;
            set
            {
                studentSurname = value;
                RaisePropertyChanged(nameof(StudentSurname));
            }
        }
        public DateTime StudentDateBirth
        {
            get => studentDateBirth;
            set
            {
                studentDateBirth = value;
                RaisePropertyChanged(nameof(StudentDateBirth));
            }
        }
        public int StudentAge
        {
            get => studentAge;
            set
            {
                studentAge = value;
                RaisePropertyChanged(nameof(StudentAge));
            }
        }
        public int StudentGroup
        {
            get => studentGroup;
            set
            {
                studentGroup = value;
                RaisePropertyChanged(nameof(StudentGroup));
            }
        }
        public string ImagePath
        {
            get => imagePath;
            set
            {
                imagePath = value;
                RaisePropertyChanged(nameof(ImagePath));
            }
        }

        public string StudentCollege
        {
            get => studentCollege;
            set
            {
                studentCollege = value;
                RaisePropertyChanged(nameof(StudentCollege));
            }
        }

        public AddNewStudentViewModel()
        {
            model = SingletonModel.GetInstance();

            AddButtonCommand = new DelegateCommand(() =>
            {
                if(studentName != "" && studentSurname != "" && studentGroup > 0 && studentAge > 0 )
                {
                    model.AddNewStudent(new Student { Name = studentName, Surname = studentSurname, DateBirth = studentDateBirth, Age = studentAge, Group = studentGroup, College = studentCollege, Photo = SingletonModel.GetImageBytes(imagePath) });
                }              
            });

            UploadPhotoCommand = new DelegateCommand(() =>
            {
                var fileDialog = new System.Windows.Forms.OpenFileDialog();
                fileDialog.Title = "Select photo";
                fileDialog.Filter = "Jpeg files (*.jpg)|*.jpg|PNG files (*.png)|*.png|Bitmap image files (*.bmp)|*.bmp";
                fileDialog.ShowDialog();
                ImagePath = fileDialog.FileName;
            });
        }
    }
}
