using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        public GroupData()
        {
        }

        public GroupData(string groupName)
        {
            GroupName = groupName;
        }

        public bool Equals(GroupData other)
        {
            if (other is null)
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return GroupName == other.GroupName;
        }

        public override int GetHashCode()
        {
            return GroupName.GetHashCode();
        }

        
        public override string ToString()
        {
            // возвращает строковое представление экземпляра класса GroupData
            return $"name = {GroupName}\nheader = {GroupHeader}\nfooter = {GroupFooter}";
        }

        public int CompareTo(GroupData other)
        {
            if (other is null)
            {
                return 1;
            }
            return GroupName.CompareTo(other.GroupName);
        }

        // по-хорошему в [] нужно написать и ограничения, но так как мы только читаме БД, этого не требуетсяя
        // строка с ограничениями:
        // [Column(Name = "group_name"), NotNull] - т.е. ограничение говорит, что нельзя в базу в это поле писать значение null
        [Column(Name = "group_name")]
        public string GroupName { get; set; }

        [Column(Name = "group_header")]
        public string GroupHeader { get; set; }

        [Column(Name = "group_footer")]
        public string GroupFooter { get; set; }

        [Column(Name = "group_id"), PrimaryKey, Identity] // PrimaryKey - уникальный ключ таблицы, Identity - по этому параметру происходит идентификация объектов
        public string Id { get; set; }

        public static List<GroupData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                // в скобочках - язык Linq
                return (from g in db.Groups select g).ToList();
            }
        }

        public List<ContactData> GetContacts()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts
                            from gcr in db.GCR.Where(p => p.GroupId == Id && p.ContactId == c.Id)
                                select c).Distinct().ToList();
            }
        }

    }
}
