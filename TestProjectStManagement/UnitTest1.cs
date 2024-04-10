//using StudentManagement.Models;
//namespace TestProjectStManagement
//{
//    public class test_Unit
//    {
//        //Test case 1: Test the function to retrieve all student information in the system
//        [Fact]
//        public void GetAllStudent()
//        {
//            //Arrage
//            bool getResult = false;
//            StudentInformationManagement studentInformationManagement = new StudentInformationManagement();

//            //Act
//            List<IStudent> stuList = studentInformationManagement.GetStudents(string.Empty, string.Empty);

//            //Assert
//            if(stuList.Count == 4)
//            {
//                getResult = true;
//            }
//            Assert.True(getResult);
            
//        }

//        //Test case 2: Test the student search function by ID when the student ID is valid
//        [Fact]
//        public void GetStudentbyID()
//        {
//            // Arrange
//            StudentInformationManagement studentInformationManagement = new StudentInformationManagement();

//            // Act
//            List<IStudent> filteredStudents = studentInformationManagement.GetStudents("BD00234", string.Empty);

//            // Assert
//            Assert.True(filteredStudents.Any(student => student.IdStudent == "BD00234"));
//            Assert.Equal(1, filteredStudents.Count);
//        }

//        //Test case 3: Test the function of adding students when student information is valid
//        [Fact]
//        public void AddStudentWhenInformationValid()
//        {
//            // Arrange
//            Student newStudent = new Student("BD00400", "IT", "Le Viet Hoang", new DateTime(2004, 11, 16), "male", "0814254442", "Quang Binh", "hoang19876mail.com", 0);
//            StudentInformationManagement studentInformationManagement = new StudentInformationManagement();
//            int count = studentInformationManagement.GetStudents(string.Empty, string.Empty).Count;
//            int originStuListCount = count;

//            //Act
//            List<IStudent> stuListAfterAdd = studentInformationManagement.AddStudent(newStudent);

//            //Assert
//            Assert.True(stuListAfterAdd.Any(student => student.IdStudent == "BD00400"));
//            Assert.Equal(originStuListCount + 1, stuListAfterAdd.Count);

//        }
//        //Test case 4: Test the function of adding students when student information is empty or invalid
//        [Fact]
//        public void AddStudentWhenInformationInValid()
//        {
//            // Arrange
//            Student newStudent = new Student(string.Empty, "IT", "Le Viet Hoang", new DateTime(2004, 11, 16), "male", string.Empty, "Quang Binh", "hoang19876mail.com", -3);
//            StudentInformationManagement studentInformationManagement = new StudentInformationManagement();
//            int count = studentInformationManagement.GetStudents(string.Empty, string.Empty).Count;
//            int originStuListCount = count;

//            //Act
//            List<IStudent> stuListAfterAdd = studentInformationManagement.AddStudent(newStudent);

//            //Assert
//            Assert.Equal(count, stuListAfterAdd.Count);
//        }
//        //Test case 5: Test the student deletion function when the student id to be deleted is valid
//        [Fact]
//        public void RemoveStudentWhenInformationValid() {
//            // Arrange
//            StudentInformationManagement studentInformationManagement = new StudentInformationManagement();
//            int count = studentInformationManagement.GetStudents(string.Empty, string.Empty).Count;
//            int originStuListCount = count;

//            //Act
//            List<IStudent> stuListAfterRemove = studentInformationManagement.DeleteStudent("BD00436");

//            //Assert
//            Assert.False(stuListAfterRemove.Any(student => student.IdStudent == "BD00436"));
//            Assert.Equal(originStuListCount - 1, stuListAfterRemove.Count);
//        }

//        //Test case 6: Test the student deletion function when the student id to be deleted is empty or invalid
//        [Fact]
//        public void RemoveStudentWhenInformationInValid()
//        {
//            // Arrange
//            StudentInformationManagement studentInformationManagement = new StudentInformationManagement();
//            int count = studentInformationManagement.GetStudents(string.Empty, string.Empty).Count;
//            int originStuListCount = count;

//            //Act
//            List<IStudent> stuListAfterRemove = studentInformationManagement.DeleteStudent("dsada");

//            //Assert
//            Assert.Equal(originStuListCount, stuListAfterRemove.Count);
//        }
//        //Test case 7: Update student information when the updated information is valid
//        [Fact]
//        public void UpdateStudentWhenInformationValid()
//        {
//            // Arrange
//            bool resultUpdate = false;
//            StudentInformationManagement studentInformationManagement = new StudentInformationManagement();
//            Student updateStudent = new Student("BD00436", "IT", "Nguyen Van Quyet", new DateTime(2004, 11, 16), "male", "0814254442", "Quang Binh", "hoang19876mail.com", 0);


//            //Act
//            List<IStudent> updateList = studentInformationManagement.UpdateStudent(updateStudent);

//            //Assert
//            foreach (IStudent student in updateList)
//            {
//                if (student.IdStudent == "BD00436" && student.Name == "Nguyen Van Quyet")
//                {
//                    resultUpdate = true;
//                    break;
//                }
//            }

//            Assert.True(resultUpdate);
//        }
//    }
//    public class test_Integration
//    {
//        //Test case 8: Get course information only when successfully logged in with the admin role
//        [Fact]
//        public void GetCourseInformationWhenLoginSuccessfullyWithAdmin()
//        {
//            // Arrange
//            bool check = false;
//            Identity identity = new Identity();

//            CourseInformationManagement courseInformationManagement = new CourseInformationManagement();
//            List<ICourse> couresList = null;

//            //Action
//            if (identity.Login("admin1", "Admin1@") == true)
//            {

//                couresList = courseInformationManagement.getCourseList(string.Empty, string.Empty, identity.GetRoleForUser("admin1"));

//            }

//            //Assert
//            if(couresList != null)
//            {
//                check = true;
//            }
//            Assert.True(check);

//        }

//        //Test case 9: Get course information when logged in as a student
//        [Fact]
//        public void GetCourseInformationWhenLoginWithStudentAcc()
//        {
//            // Arrange
//            bool check = false;
//            Identity identity = new Identity();

//            CourseInformationManagement courseInformationManagement = new CourseInformationManagement();
//            List<ICourse> couresList = null;

//            //Action
//            if (identity.Login("student1", "St1@") == true)
//            {

//                couresList = courseInformationManagement.getCourseList(string.Empty, string.Empty, identity.GetRoleForUser("student1"));

//            }

//            //Assert
//            if (couresList != null)
//            {
//                check = true;
//            }
//            Assert.False(check);

//        }
//        //Test 10 : Test adding courses when unable to successfully log in as admin
//        [Fact]
//        public void AddCourseWhenUnsuccessfulLoginAsAdmin()
//        {
//            // Arrange
//            bool check = false;
//            Identity identity = new Identity();
//            Course newCourse = new Course("Pt", "Photoshop", 12, "GD");

//            CourseInformationManagement courseInformationManagement = new CourseInformationManagement();
//            List<ICourse> couresList = null;

//            //Action
//            if(identity.Login("accountNotExits", "notExit@") == true)
//            {
//                couresList = courseInformationManagement.addCourse(newCourse, identity.GetRoleForUser("accountNotExits"));
//            }

//            //Assert
//            if (couresList == null)
//            {
//                check = true;
//            }
//            Assert.True(check);
//        }
//    }
//}