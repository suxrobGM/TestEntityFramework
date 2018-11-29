using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Commands;
using TestEntityFramework.View;
using TestEntityFramework.Model;

namespace TestEntityFramework.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        private SingletonModel model; 
        private AddNewStudentWindow addNewStudentWindow;
        private Student dataGridSelectedStudent;
        private ObservableCollection<Student> students;

        public DelegateCommand OpenAddNewStudentWindowCommand { get; }
        public DelegateCommand DeleteStudentCommand { get; }
        public DelegateCommand UploadPhotoCommand { get; }
        public DelegateCommand SaveCommand { get; }
        public ObservableCollection<Student> Students
        {
            get => students;
            set
            {
                students = value;              
                RaisePropertyChanged(nameof(Students));
            }
        }
        public Student DataGridSelectedStudent
        {
            get => dataGridSelectedStudent;
            set
            {
                dataGridSelectedStudent = value;
                RaisePropertyChanged(nameof(DataGridSelectedStudent));
            }
        }

        public MainWindowViewModel()
        {
            model = SingletonModel.GetInstance();
            addNewStudentWindow = new AddNewStudentWindow();
            students = model.StudentsList;

            OpenAddNewStudentWindowCommand = new DelegateCommand(() =>
            {
                addNewStudentWindow.ShowDialog();
            });

            DeleteStudentCommand = new DelegateCommand(() =>
            {
                model.DeleteStudent(dataGridSelectedStudent);
            });

            UploadPhotoCommand = new DelegateCommand(async () =>
            {
                var fileDialog = new System.Windows.Forms.OpenFileDialog();
                fileDialog.Title = "Select photo";
                fileDialog.Filter = "Jpeg files (*.jpg)|*.jpg|PNG files (*.png)|*.png|Bitmap image files (*.bmp)|*.bmp";
                fileDialog.ShowDialog();

                if(fileDialog.FileName != null && fileDialog.FileName != "")
                {
                    dataGridSelectedStudent.Photo = SingletonModel.GetImageBytes(fileDialog.FileName);
                    await model.UpdateStudentDataAsync(dataGridSelectedStudent, true);
                }       
            });

            SaveCommand = new DelegateCommand(async () =>
            {
                foreach (var student in Students)
                {
                    await model.UpdateStudentDataAsync(student);
                }
            });
        }        
    }
}
