using System;
using System.Collections.Generic;
using TestStack.White;
using TestStack.White.InputDevices; // для того, чтобы эмулировать нажатие кнопки клавиатуры
using TestStack.White.WindowsAPI; // вроде как хранит всякие кнопки клавиатуры
using TestStack.White.UIItems; // для взаимодействия с кнопками
using TestStack.White.UIItems.Finders; // для поиска поля ввода текста
using TestStack.White.UIItems.TreeItems; // для работы с деревьями (когда в окне несколько вложенных элементов)
using TestStack.White.UIItems.WindowItems; // для взаимодействия с окнами
using System.Windows.Automation; // чтобы работал ControlType.Edit в методе Add (чтобы можно было задать тип искомой кнопки)

namespace addressbook_tests_white
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string GROUPDELETEWINTITLE = "Delete group";

        public GroupHelper(ApplicationManager manager) : base(manager) { }

        public Window OpenGroupsDialog()
        {
            manager.MainWindow.Get<Button>("groupButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITLE);
        }

        public void CloseGroupsDialog(Window dialogue)
        {
            dialogue.Get<Button>("uxCloseAddressButton").Click();
        }


        public void Add(GroupData newGroup)
        {
            Window dialogue = OpenGroupsDialog();
            dialogue.Get<Button>("uxNewAddressButton").Click();

            // actions
            // находим в окне редактируемый элемент (он у нас единственный в окне)
            TextBox textBox = (TextBox) dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));

            // вводим имя группы
            textBox.Enter(newGroup.Name);

            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            CloseGroupsDialog(dialogue);
        }

        public void Remove(int index)
        {
            Window dialogue = OpenGroupsDialog();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            TreeNode first = root.Nodes[index];
            first.Select();
            dialogue.Get<Button>("uxDeleteAddressButton").Click();
            Window deleteWin = manager.MainWindow.ModalWindow(GROUPWINTITLE);
            deleteWin.Get<Button>("uxOKAddressButton").Click();
            CloseGroupsDialog(dialogue);
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            Window dialogue = OpenGroupsDialog();
            // получаем деревья с открытого диалогового окна
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            // получаем корневой элемент (он всего 1 из-за структуры тестируемого окна)
            TreeNode root = tree.Nodes[0];
            // обходим элементы корневого элемента, читаем из них текст и добавляем группы с соответствующими именами в список
            foreach (TreeNode item in root.Nodes)
            {
                list.Add(new GroupData() {
                            Name = item.Text
                        });
            }

            CloseGroupsDialog(dialogue);

            return list;
        }

        public void CreateDefaultGroup()
        {           
            GroupData defaultGroup = new GroupData() { Name = "Default name" };

            Add(defaultGroup);
        }


    }
}