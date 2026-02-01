using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems; // для взаимодействия с кнопками
using TestStack.White.UIItems.WindowItems; // для взаимодействия с окнами



namespace addressbook_tests_white
{
    public class ApplicationManager
    {
        public static string WINTITLE = "Free Address Book";

        private GroupHelper groupHelper;

        public ApplicationManager()
        {
            // запускаем приложение
            Application app = Application.Launch(@"c:\0.Mine\Addressbook_test\DesktopApp\AddressBook.exe");
            // выбираем окно приложения (ожидания до его появления выполняются автоматически)
            MainWindow = app.GetWindow(WINTITLE);

            groupHelper = new GroupHelper(this);
        }

        public void Stop()
        {
            // нажимаем на кнопку в окне по ее локатору (уникальному идентификатору)
            MainWindow.Get<Button>("uxExitAddressButton").Click(); 
        }

        // создаем свойство, чтобы открытое окно приложения было доступно в других классах и методах
        public Window MainWindow { get; private set; }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }
    }
}
