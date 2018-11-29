using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEntityFramework.Model
{
    public class SingletonModel
    {
        private static SingletonModel instance;
        private StudentContext db;

        public ObservableCollection<Student> StudentsList { get; }

        private SingletonModel()
        {
            db = new StudentContext();
            StudentsList = new ObservableCollection<Student>(db.Students);            
        }

        public static SingletonModel GetInstance()
        {
            if (instance == null)
                instance = new SingletonModel();

            return instance;
        }

        public static byte[] GetImageBytes(string imageFilePath)
        {
            if (imageFilePath == String.Empty || imageFilePath == null)
                return null;
            return File.ReadAllBytes(imageFilePath); ;
        }

        public void AddNewStudent(Student student)
        {           
            student.Id = db.Students.Local.Last().Id + 1;
            StudentsList.Add(student);
            db.Students.Add(student);
            db.SaveChangesAsync();
        }

        public void DeleteStudent(Student student)
        {
            StudentsList.Remove(student);
            db.Students.Remove(student);
            db.SaveChangesAsync();
        }

        public async Task UpdateStudentDataAsync(Student student, bool updateOnlyPhoto = false)
        {
            if (updateOnlyPhoto)
            {
                StudentsList.RemoveAt(student.Id - 1);
                StudentsList.Insert(student.Id - 1, student);
            }

            var studentData = await db.Students.FindAsync(student.Id);                               
            studentData = student;
            await db.SaveChangesAsync();
        }       
    }
}
