using MockingUsers;
using Moq;

namespace MockingUsersTest
{
    public class UserManagerTest
    {

        private MockRepository mockRepository;
        private UserManager userManager;
        private Mock<UserDatabase> userDatabase;

        //Construktor
        //Setting up stuff before each Test
        public UserManagerTest()
        {
            //Skapa ett objekt av Mock-klassen. Gör den Strict
            mockRepository = new MockRepository(MockBehavior.Strict);

            //Skapa userManager
            userManager = new UserManager();

            //Skapa ett Mockat objekt av klassen UserDatabase.
            //Spara den i userDatabase attribut
            userDatabase = mockRepository.Create<UserDatabase>();

            //Placera mockat objekt inuti objektet som skall anropas vid test, aka UserManager
            userManager.UserDatabase = userDatabase.Object;
        }

        [Fact]
        public void LogginWithCorrectPassword()
        {
            //Setup av Mock
            userDatabase.Setup(userDatabase => userDatabase.GetUserById(3))
                .Returns(new User(3, "Marcus", "12345"));
            /*
            userDatabase.Setup(userDatabase => userDatabase.GetUserById(4))
                .Returns(new User(4, "Niklas", "ABCDE"));
            */
            string resp = userManager.Login(3, "12345");

            //Assert
            Assert.Equal("Inloggning Successfull!", resp);
            Assert.Equal("Marcus", userManager.CurrentUser.Username);

            //Kontrollera att GetUserById(3) har blivit anroppad
            userDatabase.Verify(userDatabase => userDatabase.GetUserById(3));

            //Kontroll av samtliga SetUps med det mockade objecket
            userDatabase.VerifyAll();
        }

        [Fact]
        public void SaveUser_Successful()
        {
            //Setup av Mock
            userDatabase.Setup(userDatabase => userDatabase.GetUserById(15))
                .Returns((User)null);

            User testUser = new User(15, "Cihan", "Circus");
            userDatabase.Setup(userDatabase => userDatabase.SaveNewUser(testUser));

            //Utför testet
            string resp = userManager.SaveUser(testUser);

            //Verify
            userDatabase.Verify(userDatabase => userDatabase.SaveNewUser(testUser));
            userDatabase.Verify(userDatabase => userDatabase.GetUserById(15));

            //Assert
            Assert.Equal("Save successful", resp);

            /*
            //Skapa ett UserObjekt
            User user = null;
            userManager.SaveUser(user);
            userDatabase.Verify(userDatabase => userDatabase.SaveNewUser(user));
            */
        }

        [Fact]
        public void SaveUserExistsInDB()
        {
            //Setup av Mock
            userDatabase.Setup(userDatabase => userDatabase.GetUserById(3))
                .Returns(new User(3, "Marcus", "12345"));

            User testUser = new User(3, "Niklas", "ABCDE");

            //Utför testet
            string resp = userManager.SaveUser(testUser);

            //Verify
            userDatabase.Verify(userDatabase => userDatabase.GetUserById(3));

            //Assert
            Assert.Equal("User with that id already exists.", resp);
        }
    }
}